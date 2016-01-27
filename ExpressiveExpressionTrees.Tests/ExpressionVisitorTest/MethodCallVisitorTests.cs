using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class MethodCallVisitorTests
    {
        class MethodCallData
        {
            public int MethodOne() { throw new NotImplementedException(); }
            public static int MethodTwo() { throw new NotImplementedException(); }
            public int MethodThree(int arg1) { throw new NotImplementedException(); }
            public static int MethodFour(int arg1) { throw new NotImplementedException(); }
            public int MethodFive(int arg1, int arg2) { throw new NotImplementedException(); }
        }

        [TestMethod]
        public void Test001()
        {
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodOne));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e1 = Expression.Call(e2, mi);

            var replace = new Dictionary<Expression,Expression> {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1=>o1.Object == e2);
            assert.ProductionHas(e1, o1=>o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1=>o1.Method == e1.Method);
            assert.ProductionHas(e1, o1=>o1.Type == e1.Type);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test002()
        {
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodOne));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e1 = Expression.Call(e2, mi);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(null, typeof(MethodCallData)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodTwo));
            var e1 = Expression.Call(mi);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == null);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(null, 1);
            assert.WasProduced(null, 1);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test004()
        {
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodThree));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e3 = Expression.Parameter(typeof(int));
            var e1 = Expression.Call(e2, mi, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1=>o1.Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodThree));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e3 = Expression.Parameter(typeof(int));
            var e1 = Expression.Call(e2, mi, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(MethodCallData)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodThree));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e3 = Expression.Parameter(typeof(int));
            var e1 = Expression.Call(e2, mi, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodThree));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e3 = Expression.Parameter(typeof(int));
            var e1 = Expression.Call(e2, mi, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(MethodCallData)) },
                { e3, Expression.Parameter(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodFour));
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.Call(mi, e2);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == null);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1=> o1.Arguments[0] == e2);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(null, 1);
            assert.WasProduced(null, 1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }
        [TestMethod]
        public void Test009()
        {
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodFour));
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.Call(mi, e2);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == null);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.WasVisited(null, 1);
            assert.WasProduced(null, 1);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test010()
        {
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodFive));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Call(e2, mi, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e4);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
        public void Test011()
        {
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodFive));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Call(e2, mi, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Parameter(typeof(MethodCallData)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e4);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
        public void Test012()
        {
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodFive));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Call(e2, mi, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e4);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
        public void Test013()
        {
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodFive));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Call(e2, mi, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { e4, Expression.Parameter(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
        public void Test014()
        {
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodFive));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Call(e2, mi, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Parameter(typeof(MethodCallData)) },
                {e3, Expression.Parameter(typeof(int)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e4);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
        public void Test015()
        {
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodFive));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Call(e2, mi, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Parameter(typeof(MethodCallData)) },
                {e4, Expression.Parameter(typeof(int)) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
        public void Test016()
        {
            var mi = typeof(MethodCallData).GetMethod(nameof(MethodCallData.MethodFive));
            var e2 = Expression.Default(typeof(MethodCallData));
            var e3 = Expression.Parameter(typeof(int));
            var e4 = Expression.Parameter(typeof(int));
            var e1 = Expression.Call(e2, mi, e3, e4);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
                { e4, Expression.Parameter(typeof(int)) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Object == e2);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == e1.Arguments.Count);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
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
    }
}
