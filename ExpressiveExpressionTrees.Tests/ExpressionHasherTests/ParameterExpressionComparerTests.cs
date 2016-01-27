using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionHasherTests
{

    [TestClass]
    public class ParameterExpressionHasherTests : CompareParameterBaseTests
    {
        public override bool AreEqual(Expression left, Expression right)
        {
            var lh = ExpressionHasher.Hash(left);
            var rh = ExpressionHasher.Hash(right);

            return lh.HashCode == rh.HashCode;
        }

        public override bool AreEqual(Dictionary<ParameterExpression, ParameterExpression> mapping, Expression left, Expression right)
        {
            return AreEqual(left, right);
        }

        [TestMethod]
        public virtual void Test003()
        {
            var xgr = new ExpressionGenerator();

            var expr1 = Expression.Parameter(typeof(int));
            var expr2 = Expression.Parameter(typeof(int));

            _assert.AreEqual(
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

            _assert.AreEqual(expr1, expr2);
        }
    }
}
