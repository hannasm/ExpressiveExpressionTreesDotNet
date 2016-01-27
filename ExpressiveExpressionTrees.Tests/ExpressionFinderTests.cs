using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;

namespace ExpressiveExpressionTrees.Tests
{
    [TestClass]
    public class ExpressionFinderTests
    {
        [TestMethod]
        public void Test001()
        {
            var xfr = new ExpressionFinder();
            var needle = Expression.Parameter(typeof(int));
            var haystack = Expression.Add(
                Expression.Add(Expression.Parameter(typeof(int)), needle),
                Expression.Multiply(Expression.Parameter(typeof(int)), Expression.Parameter(typeof(int)))
            );

            Assert.IsTrue(xfr.Exists(needle, haystack));
        }

        [TestMethod]
        public void Test002()
        {
            var xfr = new ExpressionFinder();
            var needle = Expression.Parameter(typeof(int));
            var haystack = Expression.Add(
                Expression.Add(Expression.Parameter(typeof(int)), Expression.Parameter(typeof(int))),
                Expression.Multiply(Expression.Parameter(typeof(int)), Expression.Parameter(typeof(int)))
            );

            Assert.IsFalse(xfr.Exists(needle, haystack));
        }


        [TestMethod]
        public void Test003()
        {
            var xfr = new ExpressionFinder();
            var needle = default(Expression);
            var haystack = Expression.Add(
                Expression.Add(Expression.Parameter(typeof(int)), Expression.Parameter(typeof(int))),
                Expression.Multiply(Expression.Parameter(typeof(int)), Expression.Parameter(typeof(int)))
            );

            Assert.IsFalse(xfr.Exists(needle, haystack));
        }

        [TestMethod]
        public void Test004()
        {
            var xfr = new ExpressionFinder();
            var needle = Expression.Parameter(typeof(int));
            var haystack = default(Expression);

            Assert.IsFalse(xfr.Exists(needle, haystack));
        }
    }
}
