using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareNullBasetests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            

            _assert.AreEqual(null, null);
        }

        [TestMethod]
        public virtual void Test002()
        {
            

            _assert.AreNotEqual(null, Expression.Default(typeof(int)));
        }

        [TestMethod]
        public virtual void Test003()
        {
            

            _assert.AreNotEqual(Expression.Default(typeof(int)), null);
        }


    }
}
