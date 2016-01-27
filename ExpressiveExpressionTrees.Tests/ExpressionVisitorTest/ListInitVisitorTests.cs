using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class ListInitVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3);

            var replace = new Dictionary<Expression,Expression> {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1=>o1.NewExpression == e2);
            assert.ProductionHas(e1, o1=>o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1=>o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1=>o1.Initializers[0].Arguments[0] == e3);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test002()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
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
        public void Test003()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
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
        public void Test004()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.New(typeof(List<string>)) },
                { e3, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
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
        public void Test005()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
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
        public void Test006()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
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
        public void Test007()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
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
        public void Test008()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == replace[e4]);
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
        public void Test009()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
                {e3, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
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
        public void Test010()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == replace[e4]);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test011()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant("ABC") },
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == replace[e4]);
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

        [TestMethod]
        public void Test012()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
                {e3, Expression.Constant("ABC") },
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == replace[e4]);
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
        public void Test013()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == e5);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test014()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == e5);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test015()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == e5);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test016()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == e5);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test017()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e5, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == replace[e5]);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test018()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
                {e3, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == e5);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test019()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == e5);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test020()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
                {e5, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == replace[e5]);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }


        [TestMethod]
        public void Test021()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
                {e3, Expression.Constant("ABC") },
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == e5);
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
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test022()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
                {e3, Expression.Constant("ABC") },
                {e5, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == replace[e5]);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test023()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(typeof(List<string>)) },
                {e3, Expression.Constant("ABC") },
                {e4, Expression.Constant("DEF") },
                {e5, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == replace[e5]);
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
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test024()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant("ABC") },
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == e5);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test025()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant("ABC") },
                {e5, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == replace[e5]);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test026()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant("ABC") },
                {e4, Expression.Constant("DEF") },
                {e5, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == replace[e5]);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test027()
        {
            var e2 = Expression.New(typeof(List<string>));
            var e3 = Expression.Default(typeof(string));
            var e4 = Expression.Default(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e1 = Expression.ListInit(e2, e3, e4, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("DEF") },
                {e5, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Initializers.Count == e1.Initializers.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments.Count == e1.Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments.Count == e1.Initializers[2].Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Initializers[2].Arguments[0] == replace[e5]);
            assert.WasNotProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }
    }
}
