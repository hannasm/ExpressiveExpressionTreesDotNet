// Copyright (c) Microsoft Corporation.  All rights reserved.
// This source code is made available under the terms of the Microsoft Public License (MS-PL)

using System.Linq;
using global::System;
using global::System.Collections.Generic;
using global::System.Collections.ObjectModel;
using global::System.Linq.Expressions;
using global::System.Reflection;

namespace ExpressiveExpressionTrees
{
#if EXPRESSIVE_EXPRESSION_TREES_ASSEMBLY
    public
#endif
    abstract class ExpressionVisitor
    {
        protected ExpressionVisitor()
        {
        }

        protected virtual Expression Visit(Expression exp)
        {
            if (exp == null)
                return exp;
            switch (exp.NodeType)
            {
                case ExpressionType.Index:
                    return this.VisitIndexExpression((IndexExpression)exp);

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
                case ExpressionType.PreDecrementAssign:
                case ExpressionType.PostDecrementAssign:
                case ExpressionType.PreIncrementAssign:
                case ExpressionType.PostIncrementAssign:
                case ExpressionType.IsTrue:
                case ExpressionType.IsFalse:
                case ExpressionType.Unbox:
                    return this.VisitUnary((UnaryExpression)exp);

                case ExpressionType.Add:
                case ExpressionType.AddAssign:
                case ExpressionType.AddChecked:
                case ExpressionType.AddAssignChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractAssign:
                case ExpressionType.SubtractChecked:
                case ExpressionType.SubtractAssignChecked:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyAssign:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.MultiplyAssignChecked:
                case ExpressionType.Divide:
                case ExpressionType.DivideAssign:
                case ExpressionType.Modulo:
                case ExpressionType.ModuloAssign:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.AndAssign:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.OrAssign:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Coalesce:
                case ExpressionType.ArrayIndex:
                case ExpressionType.RightShift:
                case ExpressionType.RightShiftAssign:
                case ExpressionType.LeftShift:
                case ExpressionType.LeftShiftAssign:
                case ExpressionType.ExclusiveOr:
                case ExpressionType.ExclusiveOrAssign:
                case ExpressionType.Power:
                case ExpressionType.PowerAssign:
                case ExpressionType.Assign:
                    return this.VisitBinary((BinaryExpression)exp);
                case ExpressionType.TypeIs:
                    return this.VisitTypeIs((TypeBinaryExpression)exp);
                case ExpressionType.TypeEqual:
                    return this.VisitTypeEqual((TypeBinaryExpression)exp);
                case ExpressionType.Conditional:
                    return this.VisitConditional((ConditionalExpression)exp);
                case ExpressionType.Constant:
                    return this.VisitConstantAndCheckForRecursion((ConstantExpression)exp);
                case ExpressionType.Parameter:
                    return this.VisitParameter((ParameterExpression)exp);
                case ExpressionType.MemberAccess:
                    return this.VisitMemberAccess((MemberExpression)exp);
                case ExpressionType.Call:
                    return this.VisitMethodCall((MethodCallExpression)exp);
                case ExpressionType.Lambda:
                    return this.VisitLambda((LambdaExpression)exp);
                case ExpressionType.New:
                    return this.VisitNew((NewExpression)exp);
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    return this.VisitNewArray((NewArrayExpression)exp);
                case ExpressionType.Invoke:
                    return this.VisitInvocation((InvocationExpression)exp);
                case ExpressionType.MemberInit:
                    return this.VisitMemberInit((MemberInitExpression)exp);
                case ExpressionType.ListInit:
                    return this.VisitListInit((ListInitExpression)exp);
                case ExpressionType.Default:
                    return this.VisitDefault((DefaultExpression)exp);
                case ExpressionType.Block:
                    return this.VisitBlock((BlockExpression)exp);
                case ExpressionType.Try:
                    return this.VisitTry((TryExpression)exp);
                case ExpressionType.Goto:
                    return this.VisitGoto((GotoExpression)exp);
                case ExpressionType.Label:
                    return this.VisitLabel((LabelExpression)exp);
                default:
                    return this.VisitUnknown(exp);
            }
        }

        protected virtual Expression VisitLabel(LabelExpression exp) {
            var ndev = this.Visit(exp.DefaultValue);

            return this.UpdateLabel(exp, ndev);
        }
        protected LabelExpression UpdateLabel(LabelExpression exp, Expression newDefault) {
            if (exp.DefaultValue == newDefault) { return exp; }

            return Expression.Label(exp.Target, newDefault);
        }

        protected virtual Expression VisitGoto(GotoExpression exp) {
            var nval = this.Visit(exp.Value);

            return this.UpdateGotoExpression(exp, nval);
        }
        protected GotoExpression UpdateGotoExpression(GotoExpression exp, Expression newValue) {
            if (exp.Value == newValue) { return exp; }

            return Expression.Goto(exp.Target, newValue, exp.Type);
        }
        protected virtual Expression VisitTry(TryExpression exp) {
            var body = this.Visit(exp.Body);
            var cb = this.VisitCatchBlocks(exp.Handlers);
            var fault = this.Visit(exp.Fault);
            var fin = this.Visit(exp.Finally);

            return this.UpdateTry(exp, body, cb, fault, fin);
        }

        private Expression UpdateTry(TryExpression exp, Expression body, IEnumerable<CatchBlock> cb, Expression fault, Expression fin) {
            if (exp.Body == body && exp.Handlers == cb && exp.Fault == fault && exp.Finally == fin) { return exp; }

            if (fault != null) { throw new NotImplementedException("TryExpressions with faults not currently supported."); }

            if (cb != null) {
                return Expression.TryCatchFinally(body, fin, cb.ToArray());
            } else  {
                return Expression.TryFinally(body, fin);
            }
        }
        protected IEnumerable<CatchBlock> VisitCatchBlocks(ReadOnlyCollection<CatchBlock> cbs) {
            List<CatchBlock> r2 = null;
            for (int i = 0, n = cbs.Count; i < n ; i++) {
                var cb = cbs[i];
                var ncb = this.VisitCatchBlock(cb);

                if (r2 != null) { r2.Add(ncb); }
                else if (ncb != cb) {
                    r2 = new List<CatchBlock>();
                    for (int j =0 ; j< i; j++) {
                        r2.Add(cbs[j]);
                    }
                    r2.Add(ncb);
                }
            }
            if (r2 == null) { return cbs; }
            else { return r2.AsReadOnly(); }
        }

        protected virtual CatchBlock VisitCatchBlock(CatchBlock cb) {
            var ncbb = this.Visit(cb.Body);
            var nflt = this.Visit(cb.Filter);
            var nprm = (ParameterExpression)this.Visit(cb.Variable);

            return this.UpdateCatchBlock(cb, ncbb, nflt, nprm);
        }
        protected CatchBlock UpdateCatchBlock(CatchBlock cb, Expression newbody, Expression newFilter, ParameterExpression newVar) {
            if (cb.Body == newbody && cb.Filter == newFilter && cb.Variable == newVar) { return cb; }

            return Expression.Catch(newVar, newbody);
        }
        protected virtual Expression VisitTypeEqual(TypeBinaryExpression exp)
        {
            var result = this.Visit(exp.Expression);
            return UpdateTypeEqual(exp, result);
        }

        private Expression UpdateTypeEqual(TypeBinaryExpression exp, Expression result)
        {
            if (exp.Expression != result) {
                return Expression.TypeEqual(result, exp.TypeOperand);
            }
            return exp;
        }

        protected virtual ParameterExpression VisitVariableDefinition(ParameterExpression exp)
        {
            return (ParameterExpression)this.Visit(exp);
        }
        protected virtual Expression VisitBlock(BlockExpression blockExpression)
        {
            IEnumerable<Expression> exprs = blockExpression.Expressions;
            IEnumerable<ParameterExpression> vars = blockExpression.Variables;

            List<ParameterExpression> newVars = null;
            for (int i =0; i<blockExpression.Variables.Count;i++) {
                var newVar = VisitVariableDefinition(blockExpression.Variables[i]);
                if (newVars == null && newVar != blockExpression.Variables[i]) {
                    vars = newVars = new List<ParameterExpression>();
                    for (int j = 0; j < i; j++) {
                        newVars.Add(blockExpression.Variables[j]);
                    }
                }
                if (newVars != null) {
                    newVars.Add(newVar);
                }
            }

            List<Expression> newExprs = null;
            for (int i = 0; i < blockExpression.Expressions.Count; i++)
            {
                var newExpr = this.Visit(blockExpression.Expressions[i]);
                if (newExprs == null && newExpr != blockExpression.Expressions[i]) {
                    exprs = newExprs = new List<Expression>();
                    for (int j = 0; j < i ; j++) {
                        newExprs.Add(blockExpression.Expressions[j]);
                    }
                }
                if (newExprs != null) {
                    newExprs.Add(newExpr);
                }
            }

            return UpdateBlockExpression(blockExpression, exprs, vars);
        }
        protected virtual BlockExpression UpdateBlockExpression(BlockExpression exp, IEnumerable<Expression> expressions, IEnumerable<ParameterExpression> variables)
        {
            if (exp.Expressions != expressions ||
                exp.Variables != variables) {
                return Expression.Block(
                    variables, expressions
                );
            }
            return exp;
        }

        protected virtual Expression VisitIndexExpression(IndexExpression exp)
        {
            var obj = this.Visit(exp.Object);
            var args = this.VisitExpressionList(exp.Arguments);
            return this.UpdateIndexExpression(exp, obj, args);
        }
        protected virtual IndexExpression UpdateIndexExpression(IndexExpression exp, Expression obj, ReadOnlyCollection<Expression> args)
        {
            if (exp.Object != obj || exp.Arguments != args)
            {
                return Expression.MakeIndex(obj, exp.Indexer, args);
            }
            return exp;
        }
        protected virtual Expression VisitDefault(DefaultExpression exp)
        {
            return exp;
        }


        protected virtual Expression VisitUnknown(Expression expression)
        {
            throw new Exception(string.Format("Unhandled expression type: '{0}'", expression.NodeType));
        }

        protected virtual MemberBinding VisitBinding(MemberBinding binding)
        {
            switch (binding.BindingType)
            {
                case MemberBindingType.Assignment:
                    return this.VisitMemberAssignment((MemberAssignment)binding);
                case MemberBindingType.MemberBinding:
                    return this.VisitMemberMemberBinding((MemberMemberBinding)binding);
                case MemberBindingType.ListBinding:
                    return this.VisitMemberListBinding((MemberListBinding)binding);
                default:
                    throw new Exception(string.Format("Unhandled binding type '{0}'", binding.BindingType));
            }
        }

        protected virtual ElementInit VisitElementInitializer(ElementInit initializer)
        {
            ReadOnlyCollection<Expression> arguments = this.VisitExpressionList(initializer.Arguments);
            if (arguments != initializer.Arguments)
            {
                return Expression.ElementInit(initializer.AddMethod, arguments);
            }
            return initializer;
        }

        protected virtual Expression VisitUnary(UnaryExpression u)
        {
            Expression operand = this.Visit(u.Operand);
            return this.UpdateUnary(u, operand, u.Type, u.Method);
        }

        protected UnaryExpression UpdateUnary(UnaryExpression u, Expression operand, Type resultType, MethodInfo method)
        {
            if (u.Operand != operand || u.Type != resultType || u.Method != method)
            {
                return Expression.MakeUnary(u.NodeType, operand, resultType, method);
            }
            return u;
        }

        protected virtual Expression VisitBinary(BinaryExpression b)
        {
            Expression left = this.Visit(b.Left);
            Expression right = this.Visit(b.Right);
            Expression conversion = this.Visit(b.Conversion);
            return this.UpdateBinary(b, left, right, conversion, b.IsLiftedToNull, b.Method);
        }

        protected BinaryExpression UpdateBinary(BinaryExpression b, Expression left, Expression right, Expression conversion, bool isLiftedToNull, MethodInfo method)
        {
            if (left != b.Left || right != b.Right || conversion != b.Conversion || method != b.Method || isLiftedToNull != b.IsLiftedToNull)
            {
                if (b.NodeType == ExpressionType.Coalesce && b.Conversion != null)
                {
                    return Expression.Coalesce(left, right, conversion as LambdaExpression);
                }
                else
                {
                    return Expression.MakeBinary(b.NodeType, left, right, isLiftedToNull, method);
                }
            }
            return b;
        }

        protected virtual Expression VisitTypeIs(TypeBinaryExpression b)
        {
            Expression expr = this.Visit(b.Expression);
            return this.UpdateTypeIs(b, expr, b.TypeOperand);
        }

        protected TypeBinaryExpression UpdateTypeIs(TypeBinaryExpression b, Expression expression, Type typeOperand)
        {
            if (expression != b.Expression || typeOperand != b.TypeOperand)
            {
                return Expression.TypeIs(expression, typeOperand);
            }
            return b;
        }

        protected virtual Expression VisitConstantAndCheckForRecursion(ConstantExpression c)
        {
            return VisitConstant(c);
        }
        protected virtual Expression VisitConstant(ConstantExpression c)
        {
            return c;
        }

        protected virtual Expression VisitConditional(ConditionalExpression c)
        {
            Expression test = this.Visit(c.Test);
            Expression ifTrue = this.Visit(c.IfTrue);
            Expression ifFalse = this.Visit(c.IfFalse);
            return this.UpdateConditional(c, test, ifTrue, ifFalse);
        }

        protected ConditionalExpression UpdateConditional(ConditionalExpression c, Expression test, Expression ifTrue, Expression ifFalse)
        {
            if (test != c.Test || ifTrue != c.IfTrue || ifFalse != c.IfFalse)
            {
                return Expression.Condition(test, ifTrue, ifFalse);
            }
            return c;
        }

        protected virtual Expression VisitParameter(ParameterExpression p)
        {
            return p;
        }

        protected virtual Expression VisitMemberAccess(MemberExpression m)
        {
            Expression exp = this.Visit(m.Expression);
            return this.UpdateMemberAccess(m, exp, m.Member);
        }

        protected MemberExpression UpdateMemberAccess(MemberExpression m, Expression expression, MemberInfo member)
        {
            if (expression != m.Expression || member != m.Member)
            {
                return Expression.MakeMemberAccess(expression, member);
            }
            return m;
        }

        protected virtual Expression VisitMethodCall(MethodCallExpression m)
        {
            Expression obj = this.Visit(m.Object);
            IEnumerable<Expression> args = this.VisitExpressionList(m.Arguments);
            return this.UpdateMethodCall(m, obj, m.Method, args);
        }

        protected MethodCallExpression UpdateMethodCall(MethodCallExpression m, Expression obj, MethodInfo method, IEnumerable<Expression> args)
        {
            if (obj != m.Object || method != m.Method || args != m.Arguments)
            {
                return Expression.Call(obj, method, args);
            }
            return m;
        }

        protected virtual ReadOnlyCollection<Expression> VisitExpressionList(ReadOnlyCollection<Expression> original)
        {
            if (original != null)
            {
                List<Expression> list = null;
                for (int i = 0, n = original.Count; i < n; i++)
                {
                    Expression p = this.Visit(original[i]);
                    if (list != null)
                    {
                        list.Add(p);
                    }
                    else if (p != original[i])
                    {
                        list = new List<Expression>(n);
                        for (int j = 0; j < i; j++)
                        {
                            list.Add(original[j]);
                        }
                        list.Add(p);
                    }
                }
                if (list != null)
                {
                    return list.AsReadOnly();
                }
            }
            return original;
        }

        protected virtual ReadOnlyCollection<Expression> VisitMemberAndExpressionList(ReadOnlyCollection<MemberInfo> members, ReadOnlyCollection<Expression> original)
        {
            if (original != null)
            {
                List<Expression> list = null;
                for (int i = 0, n = original.Count; i < n; i++)
                {
                    Expression p = this.VisitMemberAndExpression(members != null ? members[i] : null, original[i]);
                    if (list != null)
                    {
                        list.Add(p);
                    }
                    else if (p != original[i])
                    {
                        list = new List<Expression>(n);
                        for (int j = 0; j < i; j++)
                        {
                            list.Add(original[j]);
                        }
                        list.Add(p);
                    }
                }
                if (list != null)
                {
                    return list.AsReadOnly();
                }
            }
            return original;
        }

        protected virtual Expression VisitMemberAndExpression(MemberInfo member, Expression expression)
        {
            return this.Visit(expression);
        }

        protected virtual MemberAssignment VisitMemberAssignment(MemberAssignment assignment)
        {
            Expression e = this.Visit(assignment.Expression);
            return this.UpdateMemberAssignment(assignment, assignment.Member, e);
        }

        protected MemberAssignment UpdateMemberAssignment(MemberAssignment assignment, MemberInfo member, Expression expression)
        {
            if (expression != assignment.Expression || member != assignment.Member)
            {
                return Expression.Bind(member, expression);
            }
            return assignment;
        }

        protected virtual MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding binding)
        {
            IEnumerable<MemberBinding> bindings = this.VisitBindingList(binding.Bindings);
            return this.UpdateMemberMemberBinding(binding, binding.Member, bindings);
        }

        protected MemberMemberBinding UpdateMemberMemberBinding(MemberMemberBinding binding, MemberInfo member, IEnumerable<MemberBinding> bindings)
        {
            if (bindings != binding.Bindings || member != binding.Member)
            {
                return Expression.MemberBind(member, bindings);
            }
            return binding;
        }

        protected virtual MemberListBinding VisitMemberListBinding(MemberListBinding binding)
        {
            IEnumerable<ElementInit> initializers = this.VisitElementInitializerList(binding.Initializers);
            return this.UpdateMemberListBinding(binding, binding.Member, initializers);
        }

        protected MemberListBinding UpdateMemberListBinding(MemberListBinding binding, MemberInfo member, IEnumerable<ElementInit> initializers)
        {
            if (initializers != binding.Initializers || member != binding.Member)
            {
                return Expression.ListBind(member, initializers);
            }
            return binding;
        }

        protected virtual IEnumerable<MemberBinding> VisitBindingList(ReadOnlyCollection<MemberBinding> original)
        {
            List<MemberBinding> list = null;
            for (int i = 0, n = original.Count; i < n; i++)
            {
                MemberBinding b = this.VisitBinding(original[i]);
                if (list != null)
                {
                    list.Add(b);
                }
                else if (b != original[i])
                {
                    list = new List<MemberBinding>(n);
                    for (int j = 0; j < i; j++)
                    {
                        list.Add(original[j]);
                    }
                    list.Add(b);
                }
            }
            if (list != null)
                return list;
            return original;
        }

        protected virtual IEnumerable<ElementInit> VisitElementInitializerList(ReadOnlyCollection<ElementInit> original)
        {
            List<ElementInit> list = null;
            for (int i = 0, n = original.Count; i < n; i++)
            {
                ElementInit init = this.VisitElementInitializer(original[i]);
                if (list != null)
                {
                    list.Add(init);
                }
                else if (init != original[i])
                {
                    list = new List<ElementInit>(n);
                    for (int j = 0; j < i; j++)
                    {
                        list.Add(original[j]);
                    }
                    list.Add(init);
                }
            }
            if (list != null)
                return list;
            return original;
        }

        protected virtual Expression VisitLambda(LambdaExpression lambda)
        {
            Expression body = this.Visit(lambda.Body);

            // TODO: Visit parameter list here?

            return this.UpdateLambda(lambda, lambda.Type, body, lambda.Parameters);
        }

        protected LambdaExpression UpdateLambda(LambdaExpression lambda, Type delegateType, Expression body, IEnumerable<ParameterExpression> parameters)
        {
            if (body != lambda.Body || parameters != lambda.Parameters || delegateType != lambda.Type)
            {
                return Expression.Lambda(delegateType, body, parameters);
            }
            return lambda;
        }

        protected virtual NewExpression VisitNew(NewExpression nex)
        {
            IEnumerable<Expression> args = this.VisitMemberAndExpressionList(nex.Members, nex.Arguments);
            return this.UpdateNew(nex, nex.Constructor, args, nex.Members);
        }

        protected NewExpression UpdateNew(NewExpression nex, ConstructorInfo constructor, IEnumerable<Expression> args, IEnumerable<MemberInfo> members)
        {
            if (args != nex.Arguments || constructor != nex.Constructor || members != nex.Members)
            {
                if (nex.Members != null)
                {
                    return Expression.New(constructor, args, members);
                }
                else
                {
                    return Expression.New(constructor, args);
                }
            }
            return nex;
        }

        protected virtual Expression VisitMemberInit(MemberInitExpression init)
        {
            NewExpression n = (NewExpression)this.Visit(init.NewExpression);
            IEnumerable<MemberBinding> bindings = this.VisitBindingList(init.Bindings);
            return this.UpdateMemberInit(init, n, bindings);
        }

        protected MemberInitExpression UpdateMemberInit(MemberInitExpression init, NewExpression nex, IEnumerable<MemberBinding> bindings)
        {
            if (nex != init.NewExpression || bindings != init.Bindings)
            {
                return Expression.MemberInit(nex, bindings);
            }
            return init;
        }

        protected virtual Expression VisitListInit(ListInitExpression init)
        {
            NewExpression n = (NewExpression)this.Visit(init.NewExpression);
            IEnumerable<ElementInit> initializers = this.VisitElementInitializerList(init.Initializers);
            return this.UpdateListInit(init, n, initializers);
        }

        protected ListInitExpression UpdateListInit(ListInitExpression init, NewExpression nex, IEnumerable<ElementInit> initializers)
        {
            if (nex != init.NewExpression || initializers != init.Initializers)
            {
                return Expression.ListInit(nex, initializers);
            }
            return init;
        }

        protected virtual Expression VisitNewArray(NewArrayExpression na)
        {
            IEnumerable<Expression> exprs = this.VisitExpressionList(na.Expressions);
            return this.UpdateNewArray(na, na.Type, exprs);
        }

        protected NewArrayExpression UpdateNewArray(NewArrayExpression na, Type arrayType, IEnumerable<Expression> expressions)
        {
            if (expressions != na.Expressions || na.Type != arrayType)
            {
                if (na.NodeType == ExpressionType.NewArrayInit)
                {
                    return Expression.NewArrayInit(arrayType.GetElementType(), expressions);
                }
                else
                {
                    return Expression.NewArrayBounds(arrayType.GetElementType(), expressions);
                }
            }
            return na;
        }

        protected virtual Expression VisitInvocation(InvocationExpression iv)
        {
            IEnumerable<Expression> args = this.VisitExpressionList(iv.Arguments);
            Expression expr = this.Visit(iv.Expression);
            return this.UpdateInvocation(iv, expr, args);
        }

        protected InvocationExpression UpdateInvocation(InvocationExpression iv, Expression expression, IEnumerable<Expression> args)
        {
            if (args != iv.Arguments || expression != iv.Expression)
            {
                return Expression.Invoke(expression, args);
            }
            return iv;
        }
    }
}
