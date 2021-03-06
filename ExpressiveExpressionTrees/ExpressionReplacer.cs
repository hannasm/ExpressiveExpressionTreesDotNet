﻿using global::System;
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
    class ExpressionReplacer
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

        public Expression GetResult()
        {
            if (_target == null) { throw new NullReferenceException("no target, perhaps you want ReplaceIn() instead"); }
            return ReplaceIn(_target);
        }

        public Expression ReplaceIn(Expression target)
        {
            if (target == null) { throw new ArgumentNullException("target"); }
            var visitor = new ExpressionReplacerVisitor(_replacements);
            return visitor.Replace(target);
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
