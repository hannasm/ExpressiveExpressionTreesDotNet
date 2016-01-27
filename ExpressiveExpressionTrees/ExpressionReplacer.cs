using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveExpressionTrees
{
    public class ExpressionReplacer
    {
        public ExpressionReplacer(Expression target) 
            : this(target, null)
        {
        }

        public ExpressionReplacer(Expression target, Dictionary<Expression, Expression> replacements)
        {
            _target = target;
            if (replacements == null) {
                replacements = new Dictionary<Expression, Expression>();
            }
            _replacements = replacements;
        }
        Dictionary<Expression, Expression> _replacements;
        Expression _target;

        public Expression GetResult() {
            return ReplaceIn(_target);
        }

        public Expression ReplaceIn(Expression target)
        {
            if (_target == null) { throw new ArgumentNullException("target"); }
            var visitor = new ExpressionReplacerVisitor(_replacements);
            return visitor.Replace(_target);
        }

        public ExpressionReplacer When(Expression find, Expression replaceWith)
        {
            _replacements.Add(find, replaceWith);
            return this;
        }

        public static ExpressionReplacer PrepareSearch() {
            return new ExpressionReplacer(null);
        }
        public static ExpressionReplacer Search(Expression target) {
            return new ExpressionReplacer(target);
        }

        public static Expression Replace(Expression target, Expression find, Expression replace)
        {
            return new ExpressionReplacer(target).When(find, replace).GetResult();
        }

        private class ExpressionReplacerVisitor : ExpressionVisitor
        {
            public ExpressionReplacerVisitor(Dictionary<Expression, Expression> replacements)
            {
                if (replacements == null)
                {
                    throw new ArgumentNullException("replacements");
                }
                _replacements = replacements;
            }

            public Expression Replace(Expression node) { return Visit(node); }
            private Dictionary<Expression, Expression> _replacements;
            protected override Expression Visit(Expression node)
            {
                if (node == null) {return node; }
                Expression result;
                if (!_replacements.TryGetValue(node, out result)) { 
                    return base.Visit(node);
                }
                return result;
            }
        }
    }
}
