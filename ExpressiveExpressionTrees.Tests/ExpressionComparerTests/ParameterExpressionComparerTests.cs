using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionComparerTests
{

    [TestClass]
    public class ParameterExpressionComparerTests : CompareParameterBaseTests
    {
        public override bool AreEqual(Expression left, Expression right)
        {
            var xc = new ExpressionComparer();

            return xc.AreEqual(left, right);
        }

        public override bool AreEqual(Dictionary<ParameterExpression, ParameterExpression> mapping, Expression left, Expression right)
        {
            var xc = new ExpressionComparer();

            return xc.AreEqual(mapping, left, right);
        }

        [TestMethod]
        public virtual void Test003()
        {
            var xgr = new ExpressionGenerator();

            var expr1 = Expression.Parameter(typeof(int));
            var expr2 = Expression.Parameter(typeof(int));

            _assert.AreNotEqual(
                new Dictionary<ParameterExpression, ParameterExpression> {
                    { expr1, expr1 }
                },
                expr1, expr2);
        }

        [TestMethod]
        public virtual void Test004()
        {

            var xgr = new ExpressionGenerator();

            var expr1 = Expression.Parameter(typeof(int));
            var expr2 = Expression.Parameter(typeof(int));

            _assert.AreNotEqual(expr1, expr2);
        }
    }
}
