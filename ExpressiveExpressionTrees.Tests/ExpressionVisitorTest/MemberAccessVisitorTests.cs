using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class MemberAccessVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e2 = Expression.Default(typeof(string));
            var e1 = Expression.MakeMemberAccess(e2, e2.Type.GetMember(nameof(string.Length))[0]);

            var replace = new Dictionary<Expression,Expression>() {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1=>o1.Expression == e2);
            assert.ProductionHas(e1, o1=>o1.Member == e1.Member);
            assert.ProductionHas(e1, o1=>o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test002()
        {
            var e2 = Expression.Default(typeof(string));
            var e1 = Expression.MakeMemberAccess(e2, e2.Type.GetMember(nameof(string.Length))[0]);

            var replace = new Dictionary<Expression, Expression>()
            {
                { e2, Expression.Default(typeof(string)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Member == e1.Member);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
    }
}
