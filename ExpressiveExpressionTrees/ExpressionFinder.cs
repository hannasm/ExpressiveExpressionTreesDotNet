using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Linq.Expressions;
using global::System.Text;
using global::System.Threading.Tasks;

namespace ExpressiveExpressionTrees
{
#if EXPRESSIVE_EXPRESSION_TREES_ASSEMBLY
    public
#endif
    class ExpressionFinder
    {
        public bool Exists (Expression needle, Expression haystack)
        {
            return new ExpressionFinderVisitor(needle).Exists(haystack);
        }

        private class ExpressionFinderVisitor : ExpressionVisitor
        {
            public ExpressionFinderVisitor(Expression needle) {
                _needle = needle;
            }
            public bool Found = false;
            private Expression _needle;

            public bool Exists(Expression expr) {
                Visit(expr);
                return Found;
            }

            protected override Expression Visit(Expression node)
            {
                if (Found || node == null) { return node; }
                if (node == _needle) {
                    Found = true;
                    return node;
                }

                return base.Visit(node);
            }
        }
    }
}
