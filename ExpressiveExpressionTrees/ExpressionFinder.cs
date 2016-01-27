using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveExpressionTrees
{
    public class ExpressionFinder
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
