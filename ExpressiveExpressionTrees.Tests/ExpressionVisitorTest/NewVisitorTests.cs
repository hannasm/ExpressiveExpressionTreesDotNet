using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using System.Net.NetworkInformation;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class NewVisitorTests
    {
        class NewData {
            public NewData()
            { }

            public NewData(int val)
            { }
            public NewData(int val, string v2)
            { }
            public NewData(int val, string v2, bool v3)
            { }
        }
        [TestMethod]
        public void Test001()
        {
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new Type[] { })
            );

            var replace = new Dictionary<Expression,Expression> {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1=>o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1=>o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1=>(o1.Members == null && e1.Members == null) || o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1=>o1.Type == e1.Type);
            assert.TotalVisits(1);
            assert.TotalProduced(1);
        }
        [TestMethod]
        public void Test002()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int) }),
                e2
            );

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1=>o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
        [TestMethod]
        public void Test003()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int) }),
                e2
            );

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Default(typeof(int)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members == null && e1.Members == null ||
                                           o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
        [TestMethod]
        public void Test005()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string) }),
                e2, e3
            );

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1=>o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }
        [TestMethod]
        public void Test006()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string) }),
                e2, e3
            );

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Default(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
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
        public void Test007()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string) }),
                e2, e3
            );

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Default(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
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
        public void Test008()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string) }),
                e2, e3
            );

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Default(typeof(int)) },
                { e3, Expression.Default(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
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
        public void Test009()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(bool));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string), typeof(bool) }),
                e2, e3, e4
            );

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
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
        public void Test010()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(bool));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string), typeof(bool) }),
                e2, e3, e4
            );

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
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
        public void Test011()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(bool));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string), typeof(bool) }),
                e2, e3, e4
            );

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Default(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
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
        public void Test012()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(bool));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string), typeof(bool) }),
                e2, e3, e4
            );

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Default(typeof(bool)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
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
        public void Test013()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(bool));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string), typeof(bool) }),
                e2, e3, e4
            );

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(int)) },
                {e3, Expression.Default(typeof(string)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
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
        public void Test014()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(bool));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string), typeof(bool) }),
                e2, e3, e4
            );

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(int)) },
                {e4, Expression.Default(typeof(bool)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
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
        public void Test015()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(bool));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string), typeof(bool) }),
                e2, e3, e4
            );

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Default(typeof(string)) },
                {e4, Expression.Default(typeof(bool)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
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
        public void Test016()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Parameter(typeof(string));
            var e4 = Expression.Parameter(typeof(bool));
            var e1 = Expression.New(
                typeof(NewData).GetConstructor(new[] { typeof(int), typeof(string), typeof(bool) }),
                e2, e3, e4
            );

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(int)) },
                {e3, Expression.Default(typeof(string)) },
                {e4, Expression.Default(typeof(bool)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => (o1.Members == null && e1.Members == null) ||
                                           o1.Members.Count == e1.Members.Count);
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
        public void Test017()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l1 = xgr.FromFunc(l2, (v2) => new {
                EleOne = v2
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);

            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test018()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l1 = xgr.FromFunc(l2, (v2) => new {
                EleOne = v2
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);

            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test019()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l1 = xgr.FromFunc(l2, l3, (v2, v3) => new {
                EleOne = v2,
                EleTwo = v3
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);

            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test020()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l1 = xgr.FromFunc(l2, l3, (v2, v3) => new {
                EleOne = v2,
                EleTwo = v3
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Parameter(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);

            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test021()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l1 = xgr.FromFunc(l2, l3, (v2, v3) => new {
                EleOne = v2,
                EleTwo = v3
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Parameter(typeof(int)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);

            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test022()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l1 = xgr.FromFunc(l2, l3, (v2, v3) => new {
                EleOne = v2,
                EleTwo = v3
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Parameter(typeof(string)) },
                {e3, Expression.Parameter(typeof(int)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);

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
        public void Test023()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l4 = Expression.Lambda<Func<bool>>(Expression.Parameter(typeof(bool)));
            var e4 = l4.Body;
            var l1 = xgr.FromFunc(l2, l3, l4, (v2, v3, v4) => new {
                EleOne = v2,
                EleTwo = v3,
                ElemThree = v4,
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);
            assert.ProductionHas(e1, o1 => o1.Members[2] == e1.Members[2]);

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
        public void Test024()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l4 = Expression.Lambda<Func<bool>>(Expression.Parameter(typeof(bool)));
            var e4 = l4.Body;
            var l1 = xgr.FromFunc(l2, l3, l4, (v2, v3, v4) => new {
                EleOne = v2,
                EleTwo = v3,
                ElemThree = v4,
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Default(typeof(string)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);
            assert.ProductionHas(e1, o1 => o1.Members[2] == e1.Members[2]);

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
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l4 = Expression.Lambda<Func<bool>>(Expression.Parameter(typeof(bool)));
            var e4 = l4.Body;
            var l1 = xgr.FromFunc(l2, l3, l4, (v2, v3, v4) => new {
                EleOne = v2,
                EleTwo = v3,
                ElemThree = v4,
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Default(typeof(int)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);
            assert.ProductionHas(e1, o1 => o1.Members[2] == e1.Members[2]);

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
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l4 = Expression.Lambda<Func<bool>>(Expression.Parameter(typeof(bool)));
            var e4 = l4.Body;
            var l1 = xgr.FromFunc(l2, l3, l4, (v2, v3, v4) => new {
                EleOne = v2,
                EleTwo = v3,
                ElemThree = v4,
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e4, Expression.Default(typeof(bool)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);
            assert.ProductionHas(e1, o1 => o1.Members[2] == e1.Members[2]);

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
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l4 = Expression.Lambda<Func<bool>>(Expression.Parameter(typeof(bool)));
            var e4 = l4.Body;
            var l1 = xgr.FromFunc(l2, l3, l4, (v2, v3, v4) => new {
                EleOne = v2,
                EleTwo = v3,
                ElemThree = v4,
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Default(typeof(string)) },
                { e3, Expression.Default(typeof(int)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e4);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);
            assert.ProductionHas(e1, o1 => o1.Members[2] == e1.Members[2]);

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
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l4 = Expression.Lambda<Func<bool>>(Expression.Parameter(typeof(bool)));
            var e4 = l4.Body;
            var l1 = xgr.FromFunc(l2, l3, l4, (v2, v3, v4) => new {
                EleOne = v2,
                EleTwo = v3,
                ElemThree = v4,
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Default(typeof(string)) },
                { e4, Expression.Default(typeof(bool)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);
            assert.ProductionHas(e1, o1 => o1.Members[2] == e1.Members[2]);

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
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l4 = Expression.Lambda<Func<bool>>(Expression.Parameter(typeof(bool)));
            var e4 = l4.Body;
            var l1 = xgr.FromFunc(l2, l3, l4, (v2, v3, v4) => new {
                EleOne = v2,
                EleTwo = v3,
                ElemThree = v4,
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Default(typeof(int)) },
                { e4, Expression.Default(typeof(bool)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);
            assert.ProductionHas(e1, o1 => o1.Members[2] == e1.Members[2]);

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
        public void Test030()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
            var e2 = l2.Body;
            var l3 = Expression.Lambda<Func<int>>(Expression.Parameter(typeof(int)));
            var e3 = l3.Body;
            var l4 = Expression.Lambda<Func<bool>>(Expression.Parameter(typeof(bool)));
            var e4 = l4.Body;
            var l1 = xgr.FromFunc(l2, l3, l4, (v2, v3, v4) => new {
                EleOne = v2,
                EleTwo = v3,
                ElemThree = v4,
            });

            Assert.IsInstanceOfType(l1.Body, typeof(NewExpression));
            Assert.AreEqual(ExpressionType.New, l1.Body.NodeType);
            var e1 = (NewExpression)l1.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Default(typeof(string)) },
                { e3, Expression.Default(typeof(int)) },
                { e4, Expression.Default(typeof(bool)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);
            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Constructor == e1.Constructor);
            assert.ProductionHas(e1, o1 => o1.Members.Count == e1.Members.Count);
            assert.ProductionHas(e1, o1 => o1.Members[0] == e1.Members[0]);
            assert.ProductionHas(e1, o1 => o1.Members[1] == e1.Members[1]);
            assert.ProductionHas(e1, o1 => o1.Members[2] == e1.Members[2]);

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

        class NewData02 {
            public List<string> Collection;
            public int DataOne;
            public string DataTwo;
            public bool DataThree;
            public NewData02 NestedOne;
        }

        [TestMethod]
        public void Test031()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, i3=>new NewData02 {
                Collection = {
                    i3
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression,Expression>();
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1=>o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1=>o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1=> ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1=> ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1=>o1.NewExpression == e2);
            assert.WasProduced(e1);

            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test032()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, i3 => new NewData02
            {
                Collection = {
                    i3
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression> {
                {  e3, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasNotProduced(e1);

            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);

            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }


        [TestMethod]
        public void Test033()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, (i3,i4) => new NewData02
            {
                Collection = {
                    i3, i4
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression> {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasProduced(e1);

            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test034()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new NewData02
            {
                Collection = {
                    i3, i4
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression> {
                { e3, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasNotProduced(e1);

            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test035()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new NewData02
            {
                Collection = {
                    i3, i4
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasNotProduced(e1);

            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test036()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new NewData02
            {
                Collection = {
                    i3, i4
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant("ABC") },
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasNotProduced(e1);

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
        public void Test037()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                Collection = {
                    i3, i4, i5
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>();
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasProduced(e1);

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
        public void Test038()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                Collection = {
                    i3, i4, i5
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression> {
                {e3, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasNotProduced(e1);

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
        public void Test039()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                Collection = {
                    i3, i4, i5
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasNotProduced(e1);

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
        public void Test040()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                Collection = {
                    i3, i4, i5
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e5, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasNotProduced(e1);

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
        public void Test041()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                Collection = {
                    i3, i4, i5
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression> {
                {e3, Expression.Constant("ABC") },
                {e4, Expression.Constant("DEF") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments[0] == e5);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasNotProduced(e1);

            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }
        [TestMethod]
        public void Test042()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                Collection = {
                    i3, i4, i5
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression> {
                {e3, Expression.Constant("ABC") },
                {e5, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == e4);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasNotProduced(e1);

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
        public void Test043()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                Collection = {
                    i3, i4, i5
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("DEF") },
                {e5, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasNotProduced(e1);

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

        [TestMethod]
        public void Test044()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                Collection = {
                    i3, i4, i5
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant("ABC") },
                {e4, Expression.Constant("DEF") },
                {e5, Expression.Constant("GHI") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberListBinding);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers.Count == ((MemberListBinding)e1.Bindings[0]).Initializers.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[0].Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[1].Arguments[0] == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments.Count == ((MemberListBinding)e1.Bindings[0]).Initializers[0].Arguments.Count);
            assert.ProductionHas(e1, o1 => ((MemberListBinding)o1.Bindings[0]).Initializers[2].Arguments[0] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.WasNotProduced(e1);

            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test045()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, (i3) => new NewData02
            {
                NestedOne = {
                    DataOne = i3
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == e3);
            assert.WasProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test046()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, (i3) => new NewData02
            {
                NestedOne = {
                    DataOne = i3
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == replace[e3]);
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
        public void Test047()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == e4);
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
        public void Test048()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == e4);
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
        public void Test049()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == replace[e4]);
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
        public void Test050()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == replace[e4]);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test051()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4,
                    DataThree = i5,
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[2] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[2]).Expression == e5);
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
        public void Test052()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4,
                    DataThree = i5,
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[2] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[2]).Expression == e5);
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
        public void Test053()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4,
                    DataThree = i5,
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[2] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[2]).Expression == e5);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test054()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4,
                    DataThree = i5,
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e5, Expression.Constant(true) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[2] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[2]).Expression == replace[e5]);
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
        public void Test055()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4,
                    DataThree = i5,
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[2] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[2]).Expression == e5);
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
        public void Test056()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4,
                    DataThree = i5,
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
                {e5, Expression.Constant(true) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[2] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[2]).Expression == replace[e5]);
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
        public void Test057()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4,
                    DataThree = i5,
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("ABC") },
                {e5, Expression.Constant(true) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[2] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[2]).Expression == replace[e5]);
            assert.WasNotProduced(e1);

            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
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
        public void Test058()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var e3 = l3.Body as DefaultExpression;
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var e4 = l4.Body as DefaultExpression;
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var e5 = l5.Body as DefaultExpression;
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new NewData02
            {
                NestedOne = {
                    DataOne = i3,
                    DataTwo = i4,
                    DataThree = i5,
                }
            });
            var e1 = l1.Body as MemberInitExpression;
            var e2 = e1.NewExpression;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
                {e4, Expression.Constant("ABC") },
                {e5, Expression.Constant(true) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => o1.Bindings[0] is MemberMemberBinding);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings.Count == ((MemberMemberBinding)e1.Bindings[0]).Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[0] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[1] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[1]).Expression == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberMemberBinding)o1.Bindings[0]).Bindings[2] is MemberAssignment);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)((MemberMemberBinding)o1.Bindings[0]).Bindings[2]).Expression == replace[e5]);
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
    }
}
