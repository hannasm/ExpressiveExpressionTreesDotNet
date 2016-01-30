using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Linq.Expressions;
using global::System.Text;
using global::System.Threading.Tasks;
using ExpressiveExpressionTrees.App_Packages.ExpressiveReflection;

namespace ExpressiveExpressionTrees
{
#if EXPRESSIVE_EXPRESSION_TREES_ASSEMBLY
    public
#endif
    partial class ExpressionGenerator
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

        public class NullConvertedExpressionResult {
            public NullConvertedExpressionResult(Expression left, Expression right)
            {
                Left = left;
                Right = right;
            }

            public readonly Expression Left;
            public readonly Expression Right;
        }
        /// <summary>
        /// Convert the type of two expressions to match if one is a nullable form of the other. It may be useful to detect and perform
        /// other valid implicit casts here as well.
        /// </summary>
        public NullConvertedExpressionResult ConvertExpressions<T1>(ref Expression<Func<T1>> expression1, ref Expression<Func<T1>> expression2)
        {
            // if both expressions are the same type no conversion required
            return new NullConvertedExpressionResult(expression1.Body, expression2.Body);
        }

        /// <summary>
        /// Convert the type of two expressions to match if one is a nullable form of the other's type. It may be useful to detect and perform
        /// other implicit casts 
        /// </summary>
        public NullConvertedExpressionResult ConvertExpressions<T1,T2>(Expression<Func<T1>>  expressionz1, Expression<Func<T2>>  expressionz2)
        {
            var left = expressionz1.Body;
            var right = expressionz2.Body;

            if (left.Type != right.Type)
            {
                var isNullable1 = Reflection.IsNullableType(left.Type);
                var isNullable2 = Reflection.IsNullableType(right.Type);
                if (isNullable1 || isNullable2)
                {
                    if (Reflection.MadeNonNullable(left.Type) == Reflection.MadeNonNullable(right.Type))
                    {
                        if (!isNullable1)
                        {
                            left = Expression.Convert(left, right.Type);
                        }
                        else if (!isNullable2)
                        {
                            right = Expression.Convert(right, left.Type);
                        }
                    }
                }
            }

            return new NullConvertedExpressionResult(left, right);
        }

        public Expression[] Split<T>(Expression<Func<T>>  expression, params ExpressionType[] binarySeparators)
        {
            var list = new List<Expression>();
            Split(expression.Body, list, binarySeparators);
            return list.ToArray();
        }

        public void Split(Expression expression, List<Expression> list, ExpressionType[] binarySeparators)
        {
            if (expression != null)
            {
                if (binarySeparators.Contains(expression.NodeType))
                {
                    var bex = expression as BinaryExpression;
                    if (bex != null)
                    {
                        Split(bex.Left, list, binarySeparators);
                        Split(bex.Right, list, binarySeparators);
                    }
                }
                else
                {
                    list.Add(expression);
                }
            }
        }

        /// <summary>
        /// Combine a sequence of expressions using a single binary operator.  At the cost of slightly slower performance,
        /// O(n*logn) instead of O(n),
        /// this join operation creates a balanced tree over the result. 
        /// 
        /// This tradeoff compared to the naiive unbalanced approachs, can prevent stack overflow issues ocurring during tree traversals
        /// at no more than several hundred elements.
        /// </summary>
        public Expression<Func<T>> Join<T>(IEnumerable<Expression> list, ExpressionType binarySeparator)
        {
            return WithType<T>(Join(list, binarySeparator));
        }

        /// <summary>
        /// Combine a sequence of expressions using a single binary operator.  At the cost of slightly slower performance,
        /// O(n*logn) instead of O(n),
        /// this join operation creates a balanced tree over the result. 
        /// 
        /// This tradeoff compared to the naiive unbalanced approachs, can prevent stack overflow issues ocurring during tree traversals
        /// at no more than several hundred elements.
        /// </summary>
        public Expression Join(IEnumerable<Expression> list, ExpressionType binarySeparator)
        {
            if (list == null) { return null; }
            Expression finalPredicate = null;
            while (true)
            {
                List<Expression> result = new List<Expression>();
                Expression remainder = null;
                foreach (var pred in list)
                {
                    if (remainder == null)
                    {
                        remainder = pred;
                    }
                    else
                    {
                        result.Add(Expression.OrElse(pred, remainder));
                        remainder = null;
                    }
                }
                if (remainder != null) { result.Add(remainder); }

                if (result.Count <= 1)
                {
                    if (result.Count == 1)
                    {
                        finalPredicate = result[0];
                    }
                    break;
                }

                list = result;
            }

            return finalPredicate;
        }
        
        /// <summary>
        /// Given a single IQueryable input sequence, perform two separate projections over that
        /// input (optionally performing separate complex type cocercion in the process), and then combine
        /// the result of those two projections into a single result.
        /// </summary>
        public IQueryable<T2> MultiProject<T1, T2, T3, T4, T5, T6>(
            IQueryable<T1> queryable,
            Expression<Func<T1, T3>> selector01,
            Expression<Func<T3, T5>> projector01,
            Expression<Func<T1, T4>> selector02,
            Expression<Func<T4, T6>> projector02,
            Expression<Func<T5, T6, T2>> combinator
        )
        {
            var projector = MultiProject(selector01, projector01, selector02, projector02, combinator);
            return queryable.Select(projector);
        }


        /// <summary>
        /// Given a single IQueryable input sequence, perform two separate projections over that
        /// input, and then combine
        /// the result of those two projections into a single result.
        /// </summary>
        public IQueryable<T2> MultiProject<T1, T2, T3, T4>(
            IQueryable<T1> queryable,
            Expression<Func<T1, T3>> projector01,
            Expression<Func<T1, T4>> projector02,
            Expression<Func<T3, T4, T2>> combinator
        )
        {
            var projector = MultiProject<T1, T2, T1, T1, T3, T4>(x=>x, projector01, x=>x, projector02, combinator);
            return queryable.Select(projector);
        }
        /// <summary>
        /// Given a single Expression<Func<t1>>, perform two separate coercions over the
        /// input, and then combine
        /// the result of those two separate coercions into a single result.
        /// </summary>
        public Expression<Func<T1, T2>> MultiProject<T1, T2, T3, T4>(
            Expression<Func<T1>> typeInference,
            Expression<Func<T1, T3>> projector01,
            Expression<Func<T1, T4>> projector02,
            Expression<Func<T3, T4, T2>> combinator
        )
        {
            return MultiProject<T1, T2, T1, T1, T3, T4>(x=>x, projector01, x=>x, projector02, combinator);
        }

        /// <summary>
        /// Given a single Expression<Func<t1>>, perform two separate coercions over the
        /// input (optionally performing separate complex type cocercion in the process), and then combine
        /// the result of those two separate coercions into a single result.
        /// </summary>
        public Expression<Func<T1, T2>> MultiProject<T1, T2, T3, T4, T5, T6>(
            Expression<Func<T1>> typeInference,
            Expression<Func<T1, T3>> selector01,
            Expression<Func<T3, T5>> projector01,
            Expression<Func<T1, T4>> selector02,
            Expression<Func<T4, T6>> projector02,
            Expression<Func<T5, T6, T2>> combinator
        )
        {
            return MultiProject(selector01, projector01, selector02, projector02, combinator);
        }

        /// <summary>
        /// Perform two separate coercions over a single input (optionally performing separate complex type cocercion in the process), 
        /// and then combine  the result of those two separate coercions into a single result.
        /// </summary>
        public Expression<Func<T1,T2>> MultiProject<T1, T2, T3, T4, T5, T6>(
            Expression<Func<T1, T3>> selector01,
            Expression<Func<T3, T5>> projector01,
            Expression<Func<T1, T4>> selector02,
            Expression<Func<T4, T6>> projector02,
            Expression<Func<T5, T6, T2>> combinator
        )
        {
            var param = Expression.Parameter(typeof(T1));

            var s1 = ExpressionReplacer.Search(selector01.Body).When(selector01.Parameters[0], replaceWith: param).GetResult();
            var p1 = ExpressionReplacer.Search(projector01.Body).When(projector01.Parameters[0], replaceWith: s1).GetResult();
            var s2 = ExpressionReplacer.Search(selector02.Body).When(selector02.Parameters[0], replaceWith: param).GetResult();
            var p2 = ExpressionReplacer.Search(projector02.Body).When(projector02.Parameters[0], replaceWith: s2).GetResult();

            var proj = ExpressionReplacer.Search(combinator.Body).
                When(combinator.Parameters[0], replaceWith: p1).
                When(combinator.Parameters[1], replaceWith: p2).
                GetResult();

            return Expression.Lambda<Func<T1, T2>>(
                proj,
                param
            );
        }
    }
}