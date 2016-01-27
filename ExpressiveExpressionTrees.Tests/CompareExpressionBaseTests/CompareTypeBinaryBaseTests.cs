using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareTypeBinaryBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            var expr = Expression.Default(typeof(double));

            var expr1 = Expression.TypeEqual(expr, typeof(int));
            var expr2 = Expression.TypeEqual(expr, typeof(int));

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test002()
        {
            var expr = Expression.Default(typeof(double));

            var expr1 = Expression.TypeIs(expr, typeof(int));
            var expr2 = Expression.TypeIs(expr, typeof(int));

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test003()
        {
            var expr = Expression.Default(typeof(double));

            var expr1 = Expression.TypeEqual(expr, typeof(long));
            var expr2 = Expression.TypeEqual(expr, typeof(int));

            

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test004()
        {
            var innerExpr1 = Expression.Default(typeof(double));
            var innerExpr2 = Expression.Default(typeof(string));

            var expr1 = Expression.TypeEqual(innerExpr1, typeof(int));
            var expr2 = Expression.TypeEqual(innerExpr2, typeof(int));

            

            _assert.AreNotEqual(expr1, expr2);
        }
    }
}
