using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveExpressionTrees
{
    public class ExpressionReader
    {
        public LambdaExpression GetLambda(Expression e)
        {
            while (e != null) {
                if (e.NodeType == ExpressionType.Quote) {
                    e = ((UnaryExpression)e).Operand;
                }
                else if (e.NodeType == ExpressionType.Constant) {
                    e = ((ConstantExpression)e).Value as Expression;
                }
                else if (e.NodeType == ExpressionType.Lambda) {
                    return e as LambdaExpression;
                }
                else { break; }
            }
            return null;
        }

        public Expression StripConvert(Expression exp)
        {
            var convertExpr = exp as UnaryExpression;
            while (convertExpr != null)
            {
                switch (convertExpr.NodeType)
                {
                    case ExpressionType.Convert:
                    case ExpressionType.ConvertChecked:
                        exp = convertExpr.Operand;
                        convertExpr = exp as UnaryExpression;
                        break;
                    default:
                        convertExpr = null;
                        break;
                }
            }
            return exp;
        }

        public Type GetTrueUnderlyingType(Expression expression)
        {
            return StripConvert(expression).Type;
        }
    }
}
