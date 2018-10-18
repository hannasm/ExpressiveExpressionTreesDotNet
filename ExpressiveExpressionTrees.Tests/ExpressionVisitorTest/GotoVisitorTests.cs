using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class GotoVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var t1 = Expression.Label();
            var e1 = Expression.Goto(t1);

            var assert = ExpressionVisitorVerifierTool.Test(e1);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(null);
            assert.WasProduced(null);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test002() {
            var t1 = Expression.Label("testName");
            var e1 = Expression.Goto(t1);

            var assert = ExpressionVisitorVerifierTool.Test(e1);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(null);
            assert.WasProduced(null);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test003() {
            var t1 = Expression.Label(typeof(int), "testName");
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.Goto(t1, e2);

            var assert = ExpressionVisitorVerifierTool.Test(e1);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test004() {
            var e2 = Expression.Default(typeof(int));
            var t1 = Expression.Label(e2.Type);
            var e1 = Expression.Goto(t1, e2);

            var assert = ExpressionVisitorVerifierTool.Test(e1);

            assert.WasVisited(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e1);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test005() {
            var e2 = Expression.Default(typeof(int));
            var t1 = Expression.Label(e2.Type);
            var e1 = Expression.Goto(t1, e2);

            var assert = ExpressionVisitorVerifierTool.Test(e1);

            assert.WasVisited(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e1);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test006() {
            var e2 = Expression.Default(typeof(int));
            var t1 = Expression.Label(e2.Type);
            var e1 = Expression.Goto(t1, e2);

            var e2n = Expression.Constant(10, typeof(int));
            var replace = new Dictionary<Expression,Expression>() {
                { e2, e2n }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasVisited(e2);
            assert.WasNotProduced(e1);
            assert.WasNotProduced(e2);
            assert.WasProduced(e2n);
            assert.WasProduced(assert.Result);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
    }
}
