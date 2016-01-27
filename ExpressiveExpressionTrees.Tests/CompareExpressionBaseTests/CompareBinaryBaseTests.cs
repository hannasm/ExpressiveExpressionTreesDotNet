using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareBinaryBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.Add(expr, expr);
            var expr2 = Expression.Add(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test002()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.AddChecked(expr, expr);
            var expr2 = Expression.AddChecked(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test003()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.Subtract(expr, expr);
            var expr2 = Expression.Subtract(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test004()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.SubtractChecked(expr, expr);
            var expr2 = Expression.SubtractChecked(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test005()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.Multiply(expr, expr);
            var expr2 = Expression.Multiply(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test006()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.MultiplyChecked(expr, expr);
            var expr2 = Expression.MultiplyChecked(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test007()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.Divide(expr, expr);
            var expr2 = Expression.Divide(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test008()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.Modulo(expr, expr);
            var expr2 = Expression.Modulo(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test009()
        {
            var expr = Expression.Default(typeof(bool));

            var expr1 = Expression.And(expr, expr);
            var expr2 = Expression.And(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test010()
        {
            var expr = Expression.Default(typeof(bool));

            var expr1 = Expression.AndAlso(expr, expr);
            var expr2 = Expression.AndAlso(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test011()
        {
            var expr = Expression.Default(typeof(bool));

            var expr1 = Expression.Or (expr, expr);
            var expr2 = Expression.Or(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test012()
        {
            var expr = Expression.Default(typeof(bool));

            var expr1 = Expression.OrElse(expr, expr);
            var expr2 = Expression.OrElse(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test013()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.LessThan(expr, expr);
            var expr2 = Expression.LessThan(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test014()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.LessThanOrEqual(expr, expr);
            var expr2 = Expression.LessThanOrEqual(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test015()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.GreaterThan(expr, expr);
            var expr2 = Expression.GreaterThan(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test016()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.GreaterThanOrEqual(expr, expr);
            var expr2 = Expression.GreaterThanOrEqual(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test017()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.Equal(expr, expr);
            var expr2 = Expression.Equal(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test018()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.NotEqual(expr, expr);
            var expr2 = Expression.NotEqual(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test019()
        {
            var expr = Expression.Default(typeof(int?));

            var expr1 = Expression.Coalesce(expr, expr);
            var expr2 = Expression.Coalesce(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test020()
        {
            var arrayExpr = Expression.Default(typeof(int[]));
            var indexExpr = Expression.Default(typeof(int));

            var expr1 = Expression.ArrayIndex(arrayExpr, indexExpr);
            var expr2 = Expression.ArrayIndex(arrayExpr, indexExpr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test021()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.LeftShift(expr, expr);
            var expr2 = Expression.LeftShift(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test022()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.RightShift(expr, expr);
            var expr2 = Expression.RightShift(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test023()
        {
            var expr = Expression.Default(typeof(int));

            var expr1 = Expression.ExclusiveOr(expr, expr);
            var expr2 = Expression.ExclusiveOr(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test024()
        {
            var expr = Expression.Default(typeof(double));

            var expr1 = Expression.Power(expr, expr);
            var expr2 = Expression.Power(expr, expr);

            

            _assert.AreEqual(expr1, expr2);
        }
    }
}
