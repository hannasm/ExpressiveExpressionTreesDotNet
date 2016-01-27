using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class ConditionalVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e2 = Expression.Parameter(typeof(bool));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Condition(e2, e3, e4);

            var replace = new Dictionary<Expression,Expression> {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1=>o1.Test == e2);
            assert.ProductionHas(e1, o1 => o1.IfTrue == e3);
            assert.ProductionHas(e1, o1 => o1.IfFalse == e4);
            assert.ProductionHas(e1, o1=>o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test002()
        {
            var e2 = Expression.Parameter(typeof(bool));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Condition(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(bool)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Test == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.IfTrue == e3);
            assert.ProductionHas(e1, o1 => o1.IfFalse == e4);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test003()
        {
            var e2 = Expression.Parameter(typeof(bool));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Condition(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Test == e2);
            assert.ProductionHas(e1, o1 => o1.IfTrue == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.IfFalse == e4);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test004()
        {
            var e2 = Expression.Parameter(typeof(bool));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Condition(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { e4, Expression.Parameter(typeof(int)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Test == e2);
            assert.ProductionHas(e1, o1 => o1.IfTrue == e3);
            assert.ProductionHas(e1, o1 => o1.IfFalse == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test005()
        {
            var e2 = Expression.Parameter(typeof(bool));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Condition(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(bool)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Test == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.IfTrue == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.IfFalse == e4);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test006()
        {
            var e2 = Expression.Parameter(typeof(bool));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Condition(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(bool)) },
                { e4, Expression.Parameter(typeof(int)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Test == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.IfTrue == e3);
            assert.ProductionHas(e1, o1 => o1.IfFalse == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test007()
        {
            var e2 = Expression.Parameter(typeof(bool));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Condition(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
                { e4, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Test == e2);
            assert.ProductionHas(e1, o1 => o1.IfTrue == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.IfFalse == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test008()
        {
            var e2 = Expression.Parameter(typeof(bool));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Condition(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(bool)) },
                { e3, Expression.Parameter(typeof(int)) },
                { e4, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Test == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.IfTrue == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.IfFalse == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
    }
}
