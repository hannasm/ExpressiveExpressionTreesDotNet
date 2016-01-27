using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveExpressionTrees
{
    public partial class ExpressionGenerator
    {
        public Expression<Func<T1>> WithType<T1>(Expression expr)
        {
            return Expression.Lambda<Func<T1>>(
                expr
            );
        }

        public Expression WithoutType<T1>(Expression<Func<T1>> expr) {
            return expr.Body;
        }

        public Expression FromAction(Expression<Action> expr)
        {
            return expr.Body;
        }

        public Expression<Func<T1>> FromFunc<T1>(Expression<Func<T1>> expr)
        {
            return expr;
        }
    }
}