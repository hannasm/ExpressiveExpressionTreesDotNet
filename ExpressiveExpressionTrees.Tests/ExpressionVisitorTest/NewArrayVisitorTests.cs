using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class NewArrayVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e1 = Expression.NewArrayInit(typeof(string));

            var replace = new Dictionary<Expression,Expression> {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1=>o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1=>o1.Type == e1.Type);
            assert.TotalVisits(1);
            assert.TotalProduced(1);
        }

        [TestMethod]
        public void Test002()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1=>o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test003()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Default(typeof(string)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test004()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1=>o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test005()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test006()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Default(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test007()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(string)) },
                {e3, Expression.Default(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test008()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
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
        public void Test009()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(string)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test010()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Default(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
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
        public void Test011()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Default(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == replace[e4]);
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
        public void Test012()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(string)) },
                {e3, Expression.Default(typeof(string)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test013()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(string)) },
                {e4, Expression.Default(typeof(string)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test014()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Default(typeof(string)) },
                {e4, Expression.Default(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test015()
        {
            var e2 = Expression.Parameter(typeof(string));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(string));
            var e1 = Expression.NewArrayInit(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(string)) },
                {e3, Expression.Default(typeof(string)) },
                {e4, Expression.Default(typeof(string)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test016()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2);

            var replace = new Dictionary<Expression,Expression> {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1=>o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1=>o1.Expressions[0] == e2);
            assert.WasProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(e2);

            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test017()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);

            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
        [TestMethod]
        public void Test018()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.WasProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }
        [TestMethod]
        public void Test019()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }
        [TestMethod]
        public void Test020()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(2) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);

            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test021()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(1) },
                {e3, Expression.Constant(2) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);

            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test022()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
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
        public void Test023()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test025()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(2) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.WasNotProduced(e1);

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
        public void Test026()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant(3) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == replace[e4]);
            assert.WasNotProduced(e1);

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
        public void Test027()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(1) },
                {e3, Expression.Constant(2) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == e4);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test028()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(1) },
                {e4, Expression.Constant(3) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == replace[e4]);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test029()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(1) },
                {e3, Expression.Constant(2) },
                {e4, Expression.Constant(3) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == replace[e4]);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test030()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e1 = Expression.NewArrayBounds(typeof(string), e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(2) },
                {e4, Expression.Constant(3) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Expressions.Count == e1.Expressions.Count);
            assert.ProductionHas(e1, o1 => o1.Expressions[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Expressions[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Expressions[2] == replace[e4]);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
    }
}
