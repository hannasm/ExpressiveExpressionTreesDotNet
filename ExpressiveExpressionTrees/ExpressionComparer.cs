// Copyright (c) Microsoft Corporation.  All rights reserved.
// This source code is made available under the terms of the Microsoft Public License (MS-PL)

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExpressiveExpressionTrees
{
    public class ExpressionComparer
    {
        public ExpressionComparer() { }
        public ExpressionComparer(Func<object,object,bool> fnCompare) {
            this._fnCompare = fnCompare;
        }
        public ExpressionComparer(Dictionary<ParameterExpression, ParameterExpression> parameterScope)
        {
            this._parameterScope = parameterScope;
        }
        protected Func<object, object, bool> _fnCompare;
        protected Dictionary<ParameterExpression, ParameterExpression> _parameterScope;

        public bool AreEqual(Expression a, Expression b)
        {
            return AreEqual(_parameterScope, a, b, _fnCompare);
        }

        public bool AreEqual(Expression a, Expression b, Func<object, object, bool> fnCompare)
        {
            return AreEqual(_parameterScope, a, b, fnCompare);
        }

        public bool AreEqual(Dictionary<ParameterExpression, ParameterExpression> parameterScope, Expression a, Expression b)
        {
            return AreEqual(parameterScope, a, b, _fnCompare);
        }

        public bool AreEqual(Dictionary<ParameterExpression, ParameterExpression> parameterScope, Expression a, Expression b, Func<object, object, bool> fnCompare)
        {
            return new ExpressionComparerVisitor(parameterScope, fnCompare).Compare(a, b);
        }

    }
    /// <summary>
    /// Compare two expressions to determine if they are equivalent
    /// </summary>
    public class ExpressionComparerVisitor
    {
        Dictionary<ParameterExpression, ParameterExpression> parameterScope;
        Func<object, object, bool> fnCompare;

        public ExpressionComparerVisitor(
            Dictionary<ParameterExpression, ParameterExpression> parameterScope,
            Func<object, object, bool> fnCompare
            )
        {
            this.parameterScope = parameterScope ?? new Dictionary<ParameterExpression, ParameterExpression>();
            this.fnCompare = fnCompare;
        }

        protected Func<object, object, bool> FnCompare
        {
            get { return this.fnCompare; }
        }
        
        public virtual bool Compare(Expression a, Expression b)
        {
            if (a == b)
                return true;
            if (a == null || b == null)
                return false;
            if (a.NodeType != b.NodeType)
                return false;
            switch (a.NodeType)
            {
                case ExpressionType.Lambda:
                    // for lambda expressions we don't care about return type
                    // because sometimes we see custom delegate types
                    // with the exact same signature. Everything else will
                    // be compatible, so it's just a matter of 
                    // ignoring this field
                    // if all the arguments match and the return type matches
                    // we are good to go
                    break;
                default:
                    if (a.Type != b.Type)
                        return false;
                    break;
            }
            switch (a.NodeType)
            {
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.ArrayLength:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                case ExpressionType.UnaryPlus:
                case ExpressionType.Increment:
                case ExpressionType.Decrement:
                case ExpressionType.OnesComplement:
                case ExpressionType.IsTrue:
                case ExpressionType.IsFalse:
                case ExpressionType.Unbox:
                    return this.CompareUnary((UnaryExpression)a, (UnaryExpression)b);
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Coalesce:
                case ExpressionType.ArrayIndex:
                case ExpressionType.RightShift:
                case ExpressionType.LeftShift:
                case ExpressionType.ExclusiveOr:
                case ExpressionType.Power:
                    return this.CompareBinary((BinaryExpression)a, (BinaryExpression)b);
                case ExpressionType.TypeEqual:
                case ExpressionType.TypeIs:
                    return this.CompareTypeIs((TypeBinaryExpression)a, (TypeBinaryExpression)b);
                case ExpressionType.Conditional:
                    return this.CompareConditional((ConditionalExpression)a, (ConditionalExpression)b);
                case ExpressionType.Constant:
                    return this.CompareConstantAndCheckForRecursion((ConstantExpression)a, (ConstantExpression)b);
                case ExpressionType.Parameter:
                    return this.CompareParameter((ParameterExpression)a, (ParameterExpression)b);
                case ExpressionType.MemberAccess:
                    return this.CompareMemberAccess((MemberExpression)a, (MemberExpression)b);
                case ExpressionType.Call:
                    return this.CompareMethodCall((MethodCallExpression)a, (MethodCallExpression)b);
                case ExpressionType.Lambda:
                    return this.CompareLambda((LambdaExpression)a, (LambdaExpression)b);
                case ExpressionType.New:
                    return this.CompareNew((NewExpression)a, (NewExpression)b);
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    return this.CompareNewArray((NewArrayExpression)a, (NewArrayExpression)b);
                case ExpressionType.Invoke:
                    return this.CompareInvocation((InvocationExpression)a, (InvocationExpression)b);
                case ExpressionType.MemberInit:
                    return this.CompareMemberInit((MemberInitExpression)a, (MemberInitExpression)b);
                case ExpressionType.ListInit:
                    return this.CompareListInit((ListInitExpression)a, (ListInitExpression)b);
                case ExpressionType.Default:
                    return this.CompareDefault((DefaultExpression)a, (DefaultExpression)b);

                case ExpressionType.Assign:
                    goto default;
                case ExpressionType.Block:
                    goto default;
                case ExpressionType.DebugInfo:
                    goto default;
                case ExpressionType.Dynamic:
                    goto default;
                case ExpressionType.Extension:
                    goto default;
                case ExpressionType.Goto:
                    goto default;
                case ExpressionType.Index:
                    goto default;
                case ExpressionType.Label:
                    goto default;
                case ExpressionType.RuntimeVariables:
                    goto default;
                case ExpressionType.Loop:
                    goto default;
                case ExpressionType.Switch:
                    goto default;
                case ExpressionType.Throw:
                    goto default;
                case ExpressionType.Try:
                    goto default;
                case ExpressionType.AddAssign:
                case ExpressionType.AndAssign:
                case ExpressionType.DivideAssign:
                case ExpressionType.ExclusiveOrAssign:
                case ExpressionType.LeftShiftAssign:
                case ExpressionType.ModuloAssign:
                case ExpressionType.MultiplyAssign:
                case ExpressionType.OrAssign:
                case ExpressionType.PowerAssign:
                case ExpressionType.RightShiftAssign:
                case ExpressionType.SubtractAssign:
                case ExpressionType.AddAssignChecked:
                case ExpressionType.MultiplyAssignChecked:
                case ExpressionType.SubtractAssignChecked:
                    goto default;
                case ExpressionType.PreIncrementAssign:
                case ExpressionType.PreDecrementAssign:
                case ExpressionType.PostIncrementAssign:
                case ExpressionType.PostDecrementAssign:
                    goto default;
                default:
                    throw new Exception(string.Format("Unhandled expression type: '{0}'", a.NodeType));
            }
        }

        private bool CompareDefault(DefaultExpression a, DefaultExpression b)
        {
            return a.Type == b.Type;
        }

        protected virtual bool CompareUnary(UnaryExpression a, UnaryExpression b)
        {
            return a.Method == b.Method
                && a.IsLifted == b.IsLifted
                && a.IsLiftedToNull == b.IsLiftedToNull
                && this.Compare(a.Operand, b.Operand);
        }

        protected virtual bool CompareBinary(BinaryExpression a, BinaryExpression b)
        {
            return a.Method == b.Method
                && a.IsLifted == b.IsLifted
                && a.IsLiftedToNull == b.IsLiftedToNull
                && this.Compare(a.Left, b.Left)
                && this.Compare(a.Right, b.Right);
        }

        protected virtual bool CompareTypeIs(TypeBinaryExpression a, TypeBinaryExpression b)
        {
            return a.TypeOperand == b.TypeOperand
                && this.Compare(a.Expression, b.Expression);
        }

        protected virtual bool CompareConditional(ConditionalExpression a, ConditionalExpression b)
        {
            return this.Compare(a.Test, b.Test)
                && this.Compare(a.IfTrue, b.IfTrue)
                && this.Compare(a.IfFalse, b.IfFalse);
        }
        
        protected virtual bool CompareConstantAndCheckForRecursion(ConstantExpression a, ConstantExpression b)
        {
            var queryableA = a.Value as IQueryable;
            var queryableB = b.Value as IQueryable;

            // rewrite parameters for queryables nestled inside a constant expression
            if (queryableA != null || queryableB != null)
            {
                return CompareConstantExternalQueryable(queryableA, queryableB);
            }

            return CompareConstant(a, b);
        }

        protected virtual bool CompareConstantExternalQueryable(IQueryable a, IQueryable b)
        {
            if (a == null) {
                if (b == null) {
                    // This situation should not generally even be possible, because if neither A nor B is a queryable then this
                    // method won't be called
                    return true;
                }
                else { return false; }
            } else if (b==null) {
                return false;
            }

            if (a.Provider != null && b.Provider != null)
            {
                if (!object.Equals(a.Provider.GetType(), b.Provider.GetType()))
                {
                    return false;
                }
            }

            // some querys end up encoded as a recursive constant reference to itself,
            // which creates an infinite loop, so when that happens call the base compare instead
            var constA = a.Expression as ConstantExpression;
            var constB = b.Expression as ConstantExpression;
            if ((constA != null && constA.Value == a) || 
                (constB != null && constB.Value == b))
            {
                return CompareConstant(constA, constB);
            }
            else {
                return Compare(a.Expression, b.Expression);
            }

        }
        protected virtual bool CompareConstant(ConstantExpression a, ConstantExpression b)
        {
            if (this.fnCompare != null)
            {
                return this.fnCompare(a.Value, b.Value);
            }
            else
            {
                return object.Equals(a.Value, b.Value);
            }
        }

        protected virtual bool CompareParameter(ParameterExpression a, ParameterExpression b)
        {
            if (this.parameterScope != null)
            {
                ParameterExpression mapped;
                if (this.parameterScope.TryGetValue(a, out mapped))
                    return mapped == b;
            }
            return a == b;
        }

        protected virtual bool CompareMemberAccess(MemberExpression a, MemberExpression b)
        {
            return a.Member == b.Member
                && this.Compare(a.Expression, b.Expression);
        }

        protected virtual bool CompareMethodCall(MethodCallExpression a, MethodCallExpression b)
        {
            return a.Method == b.Method
                && this.Compare(a.Object, b.Object)
                && this.CompareExpressionList(a.Arguments, b.Arguments);
        }

        protected virtual bool CompareLambda(LambdaExpression a, LambdaExpression b)
        {
            int n = a.Parameters.Count;
            int i = 0;
            if (b.Parameters.Count != n)
                return false;
            try
            {
                // all must have same type
                for (; i < n; i++)
                {
                    if (a.Parameters[i].Type != b.Parameters[i].Type)
                        return false;
                    this.parameterScope.Add(a.Parameters[i], b.Parameters[i]);
                }
                return this.Compare(a.Body, b.Body);
            }
            finally
            {
                for(;i>0;i--) {
                    this.parameterScope.Remove(a.Parameters[i-1]);
                }
            }
        }

        protected virtual bool CompareNew(NewExpression a, NewExpression b)
        {
            return a.Constructor == b.Constructor
                && this.CompareExpressionList(a.Arguments, b.Arguments)
                && this.CompareMemberList(a.Members, b.Members);
        }

        protected virtual bool CompareExpressionList(ReadOnlyCollection<Expression> a, ReadOnlyCollection<Expression> b)
        {
            if (a == b)
                return true;
            if (a == null || b == null)
                return false;
            if (a.Count != b.Count)
                return false;
            for (int i = 0, n = a.Count; i < n; i++)
            {
                if (!this.Compare(a[i], b[i]))
                    return false;
            }
            return true;
        }

        protected virtual bool CompareMemberList(ReadOnlyCollection<MemberInfo> a, ReadOnlyCollection<MemberInfo> b)
        {
            if (a == b)
                return true;
            if (a == null || b == null) {
                // i dont' think it's possible to trigger this condition because the Type has to be different for one member list 
                // to be null and the other to not be null, e.g. one anonymous type and one concrete type
                return false;
            }
            if (a.Count != b.Count)
                return false;
            for (int i = 0, n = a.Count; i < n; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }

        protected virtual bool CompareNewArray(NewArrayExpression a, NewArrayExpression b)
        {
            return this.CompareExpressionList(a.Expressions, b.Expressions);
        }

        protected virtual bool CompareInvocation(InvocationExpression a, InvocationExpression b)
        {
            return this.Compare(a.Expression, b.Expression)
                && this.CompareExpressionList(a.Arguments, b.Arguments);
        }

        protected virtual bool CompareMemberInit(MemberInitExpression a, MemberInitExpression b)
        {
            return this.Compare(a.NewExpression, b.NewExpression)
                && this.CompareBindingList(a.Bindings, b.Bindings);
        }

        protected virtual bool CompareBindingList(ReadOnlyCollection<MemberBinding> a, ReadOnlyCollection<MemberBinding> b)
        {
            if (a == b)
                return true;
            if (a == null || b == null)
                return false;
            if (a.Count != b.Count)
                return false;
            for (int i = 0, n = a.Count; i < n; i++)
            {
                if (!this.CompareBinding(a[i], b[i]))
                    return false;
            }
            return true;
        }

        protected virtual bool CompareBinding(MemberBinding a, MemberBinding b)
        {
            if (a == b)
                return true;
            if (a == null || b == null)
                return false;
            if (a.BindingType != b.BindingType)
                return false;
            if (a.Member != b.Member)
                return false;
            switch (a.BindingType)
            {
                case MemberBindingType.Assignment:
                    return this.CompareMemberAssignment((MemberAssignment)a, (MemberAssignment)b);
                case MemberBindingType.ListBinding:
                    return this.CompareMemberListBinding((MemberListBinding)a, (MemberListBinding)b);
                case MemberBindingType.MemberBinding:
                    return this.CompareMemberMemberBinding((MemberMemberBinding)a, (MemberMemberBinding)b);
                default:
                    throw new Exception(string.Format("Unhandled binding type: '{0}'", a.BindingType));
            }
        }

        protected virtual bool CompareMemberAssignment(MemberAssignment a, MemberAssignment b)
        {
            return a.Member == b.Member
                && this.Compare(a.Expression, b.Expression);
        }

        protected virtual bool CompareMemberListBinding(MemberListBinding a, MemberListBinding b)
        {
            return a.Member == b.Member
                && this.CompareElementInitList(a.Initializers, b.Initializers);
        }

        protected virtual bool CompareMemberMemberBinding(MemberMemberBinding a, MemberMemberBinding b)
        {
            return a.Member == b.Member
                && this.CompareBindingList(a.Bindings, b.Bindings);
        }

        protected virtual bool CompareListInit(ListInitExpression a, ListInitExpression b)
        {
            return this.Compare(a.NewExpression, b.NewExpression)
                && this.CompareElementInitList(a.Initializers, b.Initializers);
        }

        protected virtual bool CompareElementInitList(ReadOnlyCollection<ElementInit> a, ReadOnlyCollection<ElementInit> b)
        {
            if (a == b)
                return true;
            if (a == null || b == null)
                return false;
            if (a.Count != b.Count)
                return false;
            for (int i = 0, n = a.Count; i < n; i++)
            {
                if (!this.CompareElementInit(a[i], b[i]))
                    return false;
            }
            return true;
        }

        protected virtual bool CompareElementInit(ElementInit a, ElementInit b)
        {
            return a.AddMethod == b.AddMethod
                && this.CompareExpressionList(a.Arguments, b.Arguments);
        }
    }
}