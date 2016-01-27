using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareConstantBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            

            var object01 = new object();
            var object02 = new object();

            var constant01 = Expression.Constant(object01);
            var constant02 = Expression.Constant(object02);

            _assert.AreNotEqual(constant01, constant02);
        }
        [TestMethod]
        public virtual void Test002()
        {
            

            var object01 = new object();

            var constant01 = Expression.Constant(object01);
            var constant02 = Expression.Constant(object01);

            _assert.AreEqual(constant01, constant02);
        }

        class Dummy01 {
            public Dummy01(int val) {
                value = val;
            }
            int value;

            public override int GetHashCode()
            {
                return value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                var other = obj as Dummy01;
                if (other == null) { return false; }
                return other.value == value;
            }
        }

        [TestMethod]
        public virtual void Test003()
        {
            

            var object01 = new Dummy01(1);
            var object02 = new Dummy01(1);

            var constant01 = Expression.Constant(object01);
            var constant02 = Expression.Constant(object02);

            _assert.AreEqual(constant01, constant02);
        }

        [TestMethod]
        public virtual void Test004()
        {
            

            var object01 = new Dummy01(1);
            var object02 = new Dummy01(2);

            var constant01 = Expression.Constant(object01);
            var constant02 = Expression.Constant(object02);

            _assert.AreNotEqual(constant01, constant02);
        }

        [TestMethod]
        public virtual void Test005()
        {
            
            var object01 = Enumerable.Range(0, 1).AsQueryable();
            var object02 = Enumerable.Range(0, 1).AsQueryable();

            var constant01 = Expression.Constant(object01);
            var constant02 = Expression.Constant(object02);

            _assert.AreNotEqual(constant01, constant02);

        }

        [TestMethod]
        public virtual void Test006()
        {
            
            var object01 = Enumerable.Range(0, 1).AsQueryable().Where(i=>i < 10);
            var object02 = Enumerable.Range(0, 1).AsQueryable().Where(i => i < 10);

            var constant01 = Expression.Constant(object01);
            var constant02 = Expression.Constant(object02);

            _assert.AreNotEqual(constant01, constant02);
        }


        [TestMethod]
        public virtual void Test009()
        {
            
            var object01 = Enumerable.Range(0, 1).AsQueryable();

            var constant01 = Expression.Constant(object01);
            var constant02 = Expression.Constant(null, object01.GetType());

            _assert.AreNotEqual(constant01, constant02);
        }
        [TestMethod]
        public virtual void Test010()
        {
            
            var object01 = Enumerable.Range(0, 1).AsQueryable();

            var constant01 = Expression.Constant(object01);
            var constant02 = Expression.Constant(null, object01.GetType());

            _assert.AreNotEqual(constant02, constant01);
        }
        [TestMethod]
        public virtual void Test011()
        {
            
            var object01 = Enumerable.Range(0, 1).AsQueryable();

            var constant01 = Expression.Constant(null, object01.GetType());
            var constant02 = Expression.Constant(null, object01.GetType());

            _assert.AreEqual(constant01, constant02);
        }
    }
}
