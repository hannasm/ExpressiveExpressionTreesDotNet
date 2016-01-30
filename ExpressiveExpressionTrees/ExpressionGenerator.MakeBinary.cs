using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Linq.Expressions;
using global::System.Text;

namespace ExpressiveExpressionTrees
{
#if EXPRESSIVE_EXPRESSION_TREES_ASSEMBLY
    public
#endif
    partial class ExpressionGenerator
    {
        public Expression<Func<bool>>  MakeEqualityComparison<T1,T2>(Expression<Func<T1>> left, Expression<Func<T2>> right)
        {
            var converted = ConvertExpressions(left, right);
            return WithType<bool>(Expression.Equal(converted.Left, converted.Right));
        }

        public Expression<Func<bool>> MakeNotEqualComparison<T1, T2>(Expression<Func<T1>> left, Expression<Func<T2>> right)
        {
            var converted = ConvertExpressions(left, right);
            return WithType<bool>(Expression.NotEqual(converted.Left, converted.Right));
        }

        public Expression MakeGreaterThanComparison<T1, T2>(Expression<Func<T1>> left, Expression<Func<T2>> right)
        {
            var converted = ConvertExpressions(left, right);
            return WithType<bool>(Expression.GreaterThan(converted.Left, converted.Right));
        }

        public Expression MakeGreaterThanOrEqualComparison<T1, T2>(Expression<Func<T1>> left, Expression<Func<T2>> right)
        {
            var converted = ConvertExpressions(left, right);
            return WithType<bool>(Expression.GreaterThanOrEqual(converted.Left, converted.Right));
        }

        public Expression MakeLessThanComparison<T1, T2>(Expression<Func<T1>> left, Expression<Func<T2>> right)
        {
            var converted = ConvertExpressions(left, right);
            return WithType<bool>(Expression.LessThan(converted.Left, converted.Right));
        }

        public Expression MakeLessThanOrEqualComparison<T1, T2>(Expression<Func<T1>> left, Expression<Func<T2>> right)
        {
            var converted = ConvertExpressions(left, right);
            return WithType<bool>(Expression.LessThanOrEqual(converted.Left, converted.Right));
        }

        public Expression MakeAnd<T1, T2>(Expression<Func<T1>> left, Expression<Func<T2>> right)
        {
            var converted = ConvertExpressions(left, right);
            return WithType<bool>(Expression.And(converted.Left, converted.Right));
        }

        public Expression MakeOr<T1, T2>(Expression<Func<T1>> left, Expression<Func<T2>> right)
        {
            var converted = ConvertExpressions(left, right);
            return WithType<bool>(Expression.Or(converted.Left, converted.Right));
        }

        public Expression MakeBinary<T1, T2>(Expression<Func<T1>> left, ExpressionType op, Expression<Func<T2>> right)
        {
            var converted = ConvertExpressions(left, right);
            return WithType<bool>(Expression.MakeBinary(op, converted.Left, converted.Right));
        }
    }
}
