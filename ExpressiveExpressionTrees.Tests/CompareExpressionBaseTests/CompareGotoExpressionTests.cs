using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareGotoBaseTests: CompareExpressionTestBase
    {
        [TestMethod]
        public void Test001()
        {
            var t11 = Expression.Label();
            var e11 = Expression.Goto(t11);

            var t12 = Expression.Label();
            var e12 = Expression.Goto(t12);

            _assert.AreEqual(e11, e12);
        }

        [TestMethod]
        public void Test002() {
            var t11 = Expression.Label("testName");
            var e11 = Expression.Goto(t11);

            var t12 = Expression.Label("testName");
            var e12 = Expression.Goto(t12);

            _assert.AreEqual(e11, e12);
        }

        [TestMethod]
        public void Test003() {
            var t11 = Expression.Label(typeof(int), "testName");
            var e21 = Expression.Default(typeof(int));
            var e11 = Expression.Goto(t11, e21);

            var t12 = Expression.Label(typeof(int), "testName");
            var e22 = Expression.Default(typeof(int));
            var e12 = Expression.Goto(t12, e22);

            _assert.AreEqual(e11, e12);
        }

        [TestMethod]
        public void Test004() {
            var e21 = Expression.Default(typeof(int));
            var t11 = Expression.Label(e21.Type);
            var e11 = Expression.Goto(t11, e21);

            var e22 = Expression.Default(typeof(int));
            var t12 = Expression.Label(e22.Type);
            var e12 = Expression.Goto(t12, e22);

            _assert.AreEqual(e11, e12);
        }

        [TestMethod]
        public void Test005() {
            var e21 = Expression.Default(typeof(int));
            var t11 = Expression.Label(e21.Type);
            var e11 = Expression.Goto(t11, e21);

            var e22 = Expression.Default(typeof(int));
            var t12 = Expression.Label(e22.Type);
            var e12 = Expression.Goto(t12, e22);

            _assert.AreEqual(e11, e12);
        }

        [TestMethod]
        public void Test006() {
            var e21 = Expression.Default(typeof(int));
            var t11 = Expression.Label(e21.Type);
            var e11 = Expression.Goto(t11, e21);

            var e22 = Expression.Default(typeof(int));
            var t12 = Expression.Label(e22.Type);
            var e12 = Expression.Goto(t12, e22);

            _assert.AreEqual(e11, e12);
        }
    }
}
