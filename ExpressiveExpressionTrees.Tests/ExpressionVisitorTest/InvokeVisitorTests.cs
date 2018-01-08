using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class InvokeVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e3 = Expression.Default(typeof(int));
            var e2 = Expression.Lambda(e3);
            var e1 = Expression.Invoke(e2);

            var replace = new Dictionary<Expression,Expression> {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1=>o1.Expression == e2);
            assert.ProductionHas(e1, o1=>o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1=>o1.Type == e1.Type);
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
            var e3 = Expression.Default(typeof(int));
            var e2 = Expression.Lambda(e3);
            var e1 = Expression.Invoke(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Lambda(e3) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
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
        public void Test003()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4);
            var e1 = Expression.Invoke(e2, e5);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1=>o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test004()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4);
            var e1 = Expression.Invoke(e2, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Lambda(e3, e4) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test005()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4);
            var e1 = Expression.Invoke(e2, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e5, Expression.Constant("ABC")}
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }


        [TestMethod]
        public void Test006()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4);
            var e1 = Expression.Invoke(e2, e5);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4) },
                {e5, Expression.Constant("ABC")}
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test007()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6);
            var e1 = Expression.Invoke(e2, e5, e7);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);

            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test008()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6);
            var e1 = Expression.Invoke(e2, e5, e7);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4, e6) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);

            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test009()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6);
            var e1 = Expression.Invoke(e2, e5, e7);

            var replace = new Dictionary<Expression, Expression>
            {
                {e5, Expression.Constant("ABC") }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test010()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6);
            var e1 = Expression.Invoke(e2, e5, e7);

            var replace = new Dictionary<Expression, Expression>
            {
                {e7, Expression.Constant("DEF") }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e7]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);

            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(replace[e7]);
            assert.WasNotProduced(e7);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test011()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6);
            var e1 = Expression.Invoke(e2, e5, e7);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4, e6) },
                {e5, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test012()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6);
            var e1 = Expression.Invoke(e2, e5, e7);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4, e6) },
                {e7, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e7]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);

            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(replace[e7]);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test013()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6);
            var e1 = Expression.Invoke(e2, e5, e7);

            var replace = new Dictionary<Expression, Expression>
            {
                {e5, Expression.Constant("ABC") },
                {e7, Expression.Constant("DEF") }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e7]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(replace[e7]);
            assert.WasNotProduced(e7);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test014()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6);
            var e1 = Expression.Invoke(e2, e5, e7);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4, e6) },
                {e5, Expression.Constant("ABC") },
                {e7, Expression.Constant("DEF") }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e7]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(replace[e7]);
            assert.WasNotProduced(e7);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test015()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1=> o1.Arguments[2] == e9);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test016()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4, e6, e8) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e9);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test017()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                { e5, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e9);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test018()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                {e7, Expression.Constant("DEF") }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e7]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e9);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(replace[e7]);
            assert.WasNotProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test019()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                {e9, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e9]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(replace[e9]);
            assert.WasNotProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test020()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4, e6, e8) },
                {e5, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e9);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test021()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4, e6, e8) },
                {e7, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e7]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e9);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(replace[e7]);
            assert.WasNotProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test022()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4, e6, e8) },
                {e9, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e9]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(replace[e9]);
            assert.WasNotProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }


        [TestMethod]
        public void Test023()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4, e6, e8) },
                {e5, Expression.Constant("ABC") },
                {e7, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e7]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e9);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(replace[e7]);
            assert.WasNotProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test024()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4, e6, e8) },
                {e5, Expression.Constant("ABC") },
                {e9, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e9]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(replace[e9]);
            assert.WasNotProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test025()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Lambda(e3, e4, e6, e8) },
                {e7, Expression.Constant("DEF") },
                {e9, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e7]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e9]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(replace[e7]);
            assert.WasNotProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(replace[e9]);
            assert.WasNotProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test026()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                { e5, Expression.Constant("ABC") },
                { e7, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e7]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e9);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(replace[e7]);
            assert.WasNotProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test027()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                { e5, Expression.Constant("ABC") },
                { e9, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e7);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e9]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(replace[e9]);
            assert.WasNotProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test028()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                { e5, Expression.Constant("ABC") },
                { e7, Expression.Constant("DEF") },
                { e9, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e7]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e9]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(replace[e7]);
            assert.WasNotProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(replace[e9]);
            assert.WasNotProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }

        [TestMethod]
        public void Test029()
        {
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Parameter(typeof(string));
            var e6 = Expression.Parameter(typeof(string));
            var e8 = Expression.Parameter(typeof(string));
            var e5 = Expression.Default(typeof(string));
            var e7 = Expression.Default(typeof(string));
            var e9 = Expression.Default(typeof(string));
            var e2 = Expression.Lambda(e3, e4, e6, e8);
            var e1 = Expression.Invoke(e2, e5, e7, e9);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Lambda(e3,e4,e6,e8) },
                { e5, Expression.Constant("ABC") },
                { e7, Expression.Constant("DEF") },
                { e9, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Expression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e7]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e9]);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            // lambda parameters currently not being visited
            assert.WasNotVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasNotVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasNotVisited(e8);
            assert.WasNotProduced(e8);

            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.WasVisited(e7);
            assert.WasProduced(replace[e7]);
            assert.WasNotProduced(e7);
            assert.WasVisited(e9);
            assert.WasProduced(replace[e9]);
            assert.WasNotProduced(e9);

            assert.TotalVisits(6);
            assert.TotalProduced(6);
        }
    }
}
