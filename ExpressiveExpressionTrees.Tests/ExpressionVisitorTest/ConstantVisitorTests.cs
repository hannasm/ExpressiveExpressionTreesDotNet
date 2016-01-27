using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class ConstantVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e1 = Expression.Constant(null, typeof(object));

            var replace = new Dictionary<Expression,Expression> {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.TotalVisits(1);
            assert.TotalProduced(1);
        }

        [TestMethod]
        public void Test002()
        {
            var e1 = Expression.Constant(Expression.Parameter(typeof(string)), typeof(Expression));

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.TotalVisits(1);
            assert.TotalProduced(1);
        }


        [TestMethod]
        public void Test003()
        {
            var e1 = Expression.Constant(Enumerable.Range(0,2).Where(x=>x > 1).AsQueryable(), typeof(IQueryable));

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.TotalVisits(1);
            assert.TotalProduced(1);
        }
    }
}
