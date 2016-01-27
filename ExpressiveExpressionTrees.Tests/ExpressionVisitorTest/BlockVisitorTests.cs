using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class BlockVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.Block(e2);

            var assert = ExpressionVisitorVerifierTool.Test(e1);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test002()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Block(e2, e3);

            var assert = ExpressionVisitorVerifierTool.Test(e1);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }


        [TestMethod]
        public void Test003()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.Block(e2, e3, e4);

            var assert = ExpressionVisitorVerifierTool.Test(e1);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
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
        public void Test004()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.Block(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression> {
                { e2, Expression.Default(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Variables == null || o1.Variables.Count == 0);
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
        public void Test005()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.Block(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression> {
                { e3, Expression.Default(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Variables == null || o1.Variables.Count == 0);
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
        public void Test006()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.Block(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression> {
                { e4, Expression.Default(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1=>o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == replace[e4]);
            assert.ProductionHas(e1, o1=>o1.Variables == null || o1.Variables.Count == 0);
            assert.ProductionHas(e1, o1=>o1.Type == e1.Type);
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
        public void Test007()
        {
            var varDefs = new[] {
                Expression.Parameter(typeof(int)),
                Expression.Parameter(typeof(int)),
                Expression.Parameter(typeof(int))
            };
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.Block(varDefs, e2, e3, e4);

            var replace = new Dictionary<Expression, Expression> {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Variables.Count == varDefs.Length);
            assert.ProductionHas(e1, o1 => o1.Variables[0] == varDefs[0]);
            assert.ProductionHas(e1, o1 => o1.Variables[1] == varDefs[1]);
            assert.ProductionHas(e1, o1 => o1.Variables[2] == varDefs[2]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(varDefs[0]);
            assert.WasProduced(varDefs[0]);
            assert.WasVisited(varDefs[1]);
            assert.WasProduced(varDefs[1]);
            assert.WasVisited(varDefs[2]);
            assert.WasProduced(varDefs[2]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(7);
            assert.TotalProduced(7);
        }

        [TestMethod]
        public void Test008()
        {
            var varDefs = new[] {
                Expression.Parameter(typeof(int)),
                Expression.Parameter(typeof(int)),
                Expression.Parameter(typeof(int))
            };
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.Block(varDefs, e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { varDefs[0], Expression.Parameter(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Variables.Count == varDefs.Length);
            assert.ProductionHas(e1, o1 => o1.Variables[0] == replace[varDefs[0]]);
            assert.ProductionHas(e1, o1 => o1.Variables[1] == varDefs[1]);
            assert.ProductionHas(e1, o1 => o1.Variables[2] == varDefs[2]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(varDefs[0]);
            assert.WasNotProduced(varDefs[0]);
            assert.WasProduced(replace[varDefs[0]]);
            assert.WasVisited(varDefs[1]);
            assert.WasProduced(varDefs[1]);
            assert.WasVisited(varDefs[2]);
            assert.WasProduced(varDefs[2]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(7);
            assert.TotalProduced(7);
        }

        [TestMethod]
        public void Test009()
        {
            var varDefs = new[] {
                Expression.Parameter(typeof(int)),
                Expression.Parameter(typeof(int)),
                Expression.Parameter(typeof(int))
            };
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.Block(varDefs, e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { varDefs[1], Expression.Parameter(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Variables.Count == varDefs.Length);
            assert.ProductionHas(e1, o1 => o1.Variables[0] == varDefs[0]);
            assert.ProductionHas(e1, o1 => o1.Variables[1] == replace[varDefs[1]]);
            assert.ProductionHas(e1, o1 => o1.Variables[2] == varDefs[2]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(varDefs[0]);
            assert.WasProduced(varDefs[0]);
            assert.WasVisited(varDefs[1]);
            assert.WasNotProduced(varDefs[1]);
            assert.WasProduced(replace[varDefs[1]]);
            assert.WasVisited(varDefs[2]);
            assert.WasProduced(varDefs[2]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(7);
            assert.TotalProduced(7);
        }

        [TestMethod]
        public void Test010()
        {
            var varDefs = new[] {
                Expression.Parameter(typeof(int)),
                Expression.Parameter(typeof(int)),
                Expression.Parameter(typeof(int))
            };
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.Block(varDefs, e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { varDefs[2], Expression.Parameter(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Variables.Count == varDefs.Length);
            assert.ProductionHas(e1, o1 => o1.Variables[0] == varDefs[0]);
            assert.ProductionHas(e1, o1 => o1.Variables[1] == varDefs[1]);
            assert.ProductionHas(e1, o1 => o1.Variables[2] == replace[varDefs[2]]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(varDefs[0]);
            assert.WasProduced(varDefs[0]);
            assert.WasVisited(varDefs[1]);
            assert.WasProduced(varDefs[1]);
            assert.WasVisited(varDefs[2]);
            assert.WasNotProduced(varDefs[2]);
            assert.WasProduced(replace[varDefs[2]]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(7);
            assert.TotalProduced(7);
        }

        [TestMethod]
        public void Test011()
        {
            var varDefs = new[] {
                Expression.Parameter(typeof(int))
            };
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.Block(varDefs, e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Variables.Count == varDefs.Length);
            assert.ProductionHas(e1, o1 => o1.Variables[0] == varDefs[0]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(varDefs[0]);
            assert.WasProduced(varDefs[0]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test012()
        {
            var varDefs = new[] {
                Expression.Parameter(typeof(int))
            };
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.Block(varDefs, e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { varDefs[0], Expression.Parameter(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Variables.Count == varDefs.Length);
            assert.ProductionHas(e1, o1 => o1.Variables[0] == replace[varDefs[0]]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(varDefs[0]);
            assert.WasNotProduced(varDefs[0]);
            assert.WasProduced(replace[varDefs[0]]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }
    }
}
