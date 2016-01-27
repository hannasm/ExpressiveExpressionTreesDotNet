using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareDefaultBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            var expr1 = Expression.Default(typeof(int));
            var expr2 = Expression.Default(typeof(int));

            
            
            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test002()
        {
            var expr1 = Expression.Default(typeof(int));
            var expr2 = Expression.Default(typeof(string));

            

            _assert.AreNotEqual(expr1, expr2);
        }
    }
}
