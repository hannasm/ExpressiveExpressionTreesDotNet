using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ExpressiveExpressionTrees
{
    public class ExpressionHasher : ExpressionVisitor
    {
        #region internals
        private int _hashCode = 0;

        protected ExpressionHasher()
        {
            _hashCode = 0;
        }

        public static ExpressionHasher Hash(Expression exp)
        {
            var hasher = new ExpressionHasher();
            hasher.Visit(exp);
            return hasher;
        }

        public int HashCode { get { return _hashCode; } }

        protected void Accumulate(int newValue)
        {
            unchecked {
                _hashCode *= 2;
                _hashCode += newValue;
            }
        }
        protected void Accumulate(bool newValue)
        {
            unchecked
            {
                _hashCode *= 2;
                _hashCode += newValue ? 1 : 0;
            }
        }
        private static readonly object _null = new object();
        //protected void Accumulate(Type value)
        //{
        //    if (value != null)
        //    {
        //        Accumulate(value.AssemblyQualifiedName);
        //    }
        //}
        protected void Accumulate(object value)
        {
            unchecked
            {
                _hashCode *= 2;
                _hashCode += (value ?? _null).GetHashCode();
            }
        }
        #endregion


        #region HashVisits
        protected override Expression Visit(Expression exp)
        {
            if (exp == null) { return exp; }

            Accumulate(exp.NodeType);
            switch (exp.NodeType)
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
                    Accumulate(exp.Type);
                    break;
            }
            Accumulate(exp.CanReduce);

            return base.Visit(exp);
        }

        protected override Expression VisitIndexExpression(IndexExpression exp)
        {
            Accumulate(exp.Indexer);

            return base.VisitIndexExpression(exp);
        }

        protected override Expression VisitTypeEqual(TypeBinaryExpression exp)
        {
            Accumulate(exp.TypeOperand);

            return base.VisitTypeEqual(exp);
        }

        protected override Expression VisitDefault(DefaultExpression exp)
        {
            return base.VisitDefault(exp);
        }

        protected override Expression VisitUnknown(Expression expression)
        {
            return base.VisitUnknown(expression);
        }

        protected override MemberBinding VisitBinding(MemberBinding binding)
        {
            Accumulate(binding.BindingType);
            return base.VisitBinding(binding);
        }

        protected override ElementInit VisitElementInitializer(ElementInit initializer)
        {
            Accumulate(initializer.AddMethod);
            return base.VisitElementInitializer(initializer);
        }

        protected override Expression VisitUnary(UnaryExpression u)
        {
            Accumulate(u.IsLifted);
            Accumulate(u.IsLiftedToNull);
            Accumulate(u.Method);
            return base.VisitUnary(u);
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            Accumulate(b.IsLifted);
            Accumulate(b.IsLiftedToNull);
            Accumulate(b.Method);
            return base.VisitBinary(b);
        }

        protected override Expression VisitTypeIs(TypeBinaryExpression b)
        {
            Accumulate(b.TypeOperand);
            return base.VisitTypeIs(b);
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            Accumulate(c.Value);
            return base.VisitConstant(c);
        }

        protected override Expression VisitConditional(ConditionalExpression c)
        {
            return base.VisitConditional(c);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            Accumulate(p.IsByRef);
            //Accumulate(p.Name); // SKIP THIS?
            return base.VisitParameter(p);
        }

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            Accumulate(m.Member);
            return base.VisitMemberAccess(m);
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            Accumulate(m.Method);
            return base.VisitMethodCall(m);
        }

        protected override ReadOnlyCollection<Expression> VisitExpressionList(ReadOnlyCollection<Expression> original)
        {
            Accumulate(original.Count);
            return base.VisitExpressionList(original);
        }

        protected override ReadOnlyCollection<Expression> VisitMemberAndExpressionList(ReadOnlyCollection<MemberInfo> members, ReadOnlyCollection<Expression> original)
        {
            if (members != null)
            {
                Accumulate(members.Count);
            }
            Accumulate(original.Count);
            return base.VisitMemberAndExpressionList(members, original);
        }

        protected override Expression VisitMemberAndExpression(MemberInfo member, Expression expression)
        {
            Accumulate(member);
            return base.VisitMemberAndExpression(member, expression);
        }

        protected override MemberAssignment VisitMemberAssignment(MemberAssignment assignment)
        {
            Accumulate(assignment.Member);
            return base.VisitMemberAssignment(assignment);
        }

        protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding binding)
        {
            Accumulate(binding.Member);
            return base.VisitMemberMemberBinding(binding);
        }

        protected override MemberListBinding VisitMemberListBinding(MemberListBinding binding)
        {
            Accumulate(binding.Member);
            return base.VisitMemberListBinding(binding);
        }

        protected override IEnumerable<MemberBinding> VisitBindingList(ReadOnlyCollection<MemberBinding> original)
        {
            Accumulate(original.Count);
            return base.VisitBindingList(original);
        }

        protected override IEnumerable<ElementInit> VisitElementInitializerList(ReadOnlyCollection<ElementInit> original)
        {
            Accumulate(original.Count);
            return base.VisitElementInitializerList(original);
        }

        protected override Expression VisitLambda(LambdaExpression lambda)
        {
            Accumulate(lambda.Parameters.Count);
            for (int i = 0, n = lambda.Parameters.Count; i < n; ++i)
            {
                this.Visit(lambda.Parameters[i]);
            }
            return base.VisitLambda(lambda);
        }

        protected override NewExpression VisitNew(NewExpression nex)
        {
            Accumulate(nex.Constructor);
            if (nex.Members != null)
            {
                for (int i = 0, n = nex.Members.Count; i < n; ++i)
                {
                    Accumulate(nex.Members[i]);
                }
            }
            return base.VisitNew(nex);
        }

        protected override Expression VisitMemberInit(MemberInitExpression init)
        {
            return base.VisitMemberInit(init);
        }

        protected override Expression VisitListInit(ListInitExpression init)
        {
            return base.VisitListInit(init);
        }


        protected override Expression VisitNewArray(NewArrayExpression na)
        {
            return base.VisitNewArray(na);
        }

        protected override Expression VisitInvocation(InvocationExpression iv)
        {
            return base.VisitInvocation(iv);
        }
        #endregion
    }
}
