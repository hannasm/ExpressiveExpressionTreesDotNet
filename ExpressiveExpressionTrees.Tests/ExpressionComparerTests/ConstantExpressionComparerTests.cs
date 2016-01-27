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
    public class ConstantExpressionComparerTests : CompareConstantBaseTests
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
        public virtual void Test007()
        {

            var object01 = Enumerable.Range(0, 1).AsQueryable();
            var object02 = Enumerable.Range(0, 1).AsQueryable();

            var constant01 = Expression.Constant(object01);
            var constant02 = Expression.Constant(object02);

            var xc = new ExpressionComparer();
            Assert.IsTrue(xc.AreEqual(constant01, constant02, (a, b) => (a == object01 && b == object02) || object.Equals(a, b)));
        }

        [TestMethod]
        public virtual void Test008()
        {

            var object01 = Enumerable.Range(0, 1).AsQueryable();
            var object02 = Enumerable.Range(0, 1).AsQueryable();

            var constant01 = Expression.Constant(object01.Where(i => i < 10));
            var constant02 = Expression.Constant(object02.Where(i => i < 10));

            var xc = new ExpressionComparer();
            Assert.IsTrue(xc.AreEqual(constant01, constant02, (a, b) => (a == object01 && b == object02) || object.Equals(a, b)));
        }
    }
}
