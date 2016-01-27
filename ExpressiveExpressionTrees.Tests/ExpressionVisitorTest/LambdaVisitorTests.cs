using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class LambdaVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.Lambda(e2);

            var replace = new Dictionary<Expression,Expression> {

            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1=>o1.Body == e1.Body);
            assert.ProductionHas(e1, o1=>o1.TailCall == e1.TailCall);
            assert.ProductionHas(e1, o1=>o1.Parameters.Count == e1.Parameters.Count);
            assert.ProductionHas(e1, o1=>o1.Name == e1.Name);
            assert.ProductionHas(e1, o1=>o1.ReturnType == e1.ReturnType);
            assert.ProductionHas(e1, o1=>o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
        [TestMethod]
        public void Test002()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.Lambda(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Parameter(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Body == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.TailCall == e1.TailCall);
            assert.ProductionHas(e1, o1 => o1.Parameters.Count == e1.Parameters.Count);
            assert.ProductionHas(e1, o1 => o1.Name == e1.Name);
            assert.ProductionHas(e1, o1 => o1.ReturnType == e1.ReturnType);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test003()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e1 = Expression.Lambda(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {

            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Body == e1.Body);
            assert.ProductionHas(e1, o1 => o1.TailCall == e1.TailCall);
            assert.ProductionHas(e1, o1 => o1.Parameters.Count == e1.Parameters.Count);
            assert.ProductionHas(e1, o1 => o1.Parameters[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Name == e1.Name);
            assert.ProductionHas(e1, o1 => o1.ReturnType == e1.ReturnType);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasNotVisited(e3);
            assert.WasNotProduced(e3);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }


        [TestMethod]
        public void Test004()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e1 = Expression.Lambda(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Body == e1.Body);
            assert.ProductionHas(e1, o1 => o1.TailCall == e1.TailCall);
            assert.ProductionHas(e1, o1 => o1.Parameters.Count == e1.Parameters.Count);

            // TODO: This is how the code is right now, it doesn't replace the parameter, but maybe it should?
            assert.ProductionHas(e1, o1 => o1.Parameters[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Name == e1.Name);
            assert.ProductionHas(e1, o1 => o1.ReturnType == e1.ReturnType);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasNotVisited(e3);
            assert.WasNotProduced(e3);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
    }
}
