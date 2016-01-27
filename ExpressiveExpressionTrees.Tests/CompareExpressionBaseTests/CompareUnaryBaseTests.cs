using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareUnaryBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            var inner = Expression.Default(typeof(int));

            var expr1 = Expression.Negate(inner);
            var expr2 = Expression.Negate(inner);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test002()
        {
            var inner = Expression.Default(typeof(int));

            var expr1 = Expression.NegateChecked(inner);
            var expr2 = Expression.NegateChecked(inner);

            

            _assert.AreEqual(expr1, expr2); 
        }
        [TestMethod]
        public virtual void Test003()
        {
            var inner = Expression.Default(typeof(bool));

            var expr1 = Expression.Not(inner);
            var expr2 = Expression.Not(inner);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test004()
        {
            var inner = Expression.Default(typeof(bool));

            var expr1 = Expression.Not(inner);
            var expr2 = Expression.Not(inner);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test005()
        {
            var inner = Expression.Default(typeof(long));
            var convertType = typeof(int);

            var expr1 = Expression.Convert(inner, convertType);
            var expr2 = Expression.Convert(inner, convertType);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test006()
        {
            var inner = Expression.Default(typeof(long));
            var convertType = typeof(int);

            var expr1 = Expression.ConvertChecked(inner, convertType);
            var expr2 = Expression.ConvertChecked(inner, convertType);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test007()
        {
            var inner = Expression.Default(typeof(long[]));

            var expr1 = Expression.ArrayLength(inner);
            var expr2 = Expression.ArrayLength(inner);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test008()
        {
            var inner = Expression.Lambda(Expression.Default(typeof(string)));

            var expr1 = Expression.Quote(inner);
            var expr2 = Expression.Quote(inner);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test009()
        {
            var inner = Expression.Default(typeof(object));
            var convertType = typeof(string);


            var expr1 = Expression.TypeAs(inner, convertType);
            var expr2 = Expression.TypeAs(inner, convertType);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test010()
        {
            var inner = Expression.Default(typeof(int));


            var expr1 = Expression.UnaryPlus(inner);
            var expr2 = Expression.UnaryPlus(inner);

            

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test011()
        {
            var inner = Expression.Default(typeof(int?));
            
            var expr1 = Expression.UnaryPlus(inner);
            var expr2 = Expression.UnaryPlus(inner);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test012()
        {
            var inner = Expression.Default(typeof(bool?));

            var expr1 = Expression.Not(inner);
            var expr2 = Expression.Not(inner);

            

            _assert.AreEqual(expr1, expr2);
        }

        public struct CustomVT001 {
            int data;
            public static CustomVT001? operator ++(CustomVT001? inner)
            {
                return inner;
            }
        }

        [TestMethod]
        public virtual void Test013()
        {
            var inner = Expression.Default(typeof(CustomVT001?));

            var expr1 = Expression.Increment(inner);
            var expr2 = Expression.Increment(inner);

            

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test014()
        {
            var inner = Expression.Default(typeof(int));

            var expr1 = Expression.OnesComplement(inner);
            var expr2 = Expression.OnesComplement(inner);

            

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test015()
        {
            var inner = Expression.Default(typeof(bool));

            var expr1 = Expression.IsTrue(inner);
            var expr2 = Expression.IsTrue(inner);

            

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test016()
        {
            var inner = Expression.Default(typeof(bool));

            var expr1 = Expression.IsFalse(inner);
            var expr2 = Expression.IsFalse(inner);

            

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test017()
        {
            var inner = Expression.Convert(Expression.Default(typeof(int)), typeof(object));

            var expr1 = Expression.Unbox(inner, typeof(int));
            var expr2 = Expression.Unbox(inner, typeof(int));

            

            _assert.AreEqual(expr1, expr2);
        }
    }
}
