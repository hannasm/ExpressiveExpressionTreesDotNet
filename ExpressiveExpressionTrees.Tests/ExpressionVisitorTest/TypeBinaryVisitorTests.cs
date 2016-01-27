using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class TypeBinaryVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e2 = Expression.Parameter(typeof(object));
            var e1 = Expression.TypeEqual(e2, typeof(string));

            var replace = new Dictionary<Expression,Expression> {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1=>o1.Expression == e2);
            assert.ProductionHas(e1, o1=>o1.Type == e1.Type);
            assert.ProductionHas(e1, o1=>o1.TypeOperand == e1.TypeOperand);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
        [TestMethod]
        public void Test002()
        {
            var e2 = Expression.Parameter(typeof(object));
            var e1 = Expression.TypeEqual(e2, typeof(string));

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.TypeOperand == e1.TypeOperand);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test003()
        {
            var e2 = Expression.Parameter(typeof(object));
            var e1 = Expression.TypeIs(e2, typeof(string));

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.TypeOperand == e1.TypeOperand);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
        [TestMethod]
        public void Test004()
        {
            var e2 = Expression.Parameter(typeof(object));
            var e1 = Expression.TypeIs(e2, typeof(string));

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.TypeOperand == e1.TypeOperand);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
    }
}
