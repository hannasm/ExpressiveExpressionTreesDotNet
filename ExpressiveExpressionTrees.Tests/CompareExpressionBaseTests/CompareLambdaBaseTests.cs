using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareLambdaBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            
            var sp = new Dictionary<ParameterExpression, ParameterExpression>();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));
            var p3 = Expression.Parameter(typeof(int));
            var expr1 = Expression.Lambda(Expression.Default(typeof(int)), p1, p2);
            var expr2 = Expression.Lambda(Expression.Default(typeof(int)), p1, p2, p3);

            _assert.AreNotEqual(sp, expr1, expr2);
            Assert.AreEqual(0, sp.Count);
        }

        [TestMethod]
        public virtual void Test002()
        {
            
            var sp = new Dictionary<ParameterExpression, ParameterExpression>();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));
            var p3 = Expression.Parameter(typeof(int));
            var p4 = Expression.Parameter(typeof(string));
            var expr1 = Expression.Lambda(Expression.Default(typeof(int)), p1, p2);
            var expr2 = Expression.Lambda(Expression.Default(typeof(int)), p3, p4);

            _assert.AreNotEqual(sp, expr1, expr2);
            Assert.AreEqual(0, sp.Count);
        }

        [TestMethod]
        public virtual void Test003()
        {
            
            var sp = new Dictionary<ParameterExpression, ParameterExpression>();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));
            var p3 = Expression.Parameter(typeof(string));
            var p4 = Expression.Parameter(typeof(int));
            var expr1 = Expression.Lambda(Expression.Default(typeof(int)), p1, p2);
            var expr2 = Expression.Lambda(Expression.Default(typeof(int)), p3, p4);

            _assert.AreNotEqual(sp, expr1, expr2);
            Assert.AreEqual(0, sp.Count);
        }

        [TestMethod]
        public virtual void Test004()
        {
            
            var sp = new Dictionary<ParameterExpression, ParameterExpression>();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));
            var p3 = Expression.Parameter(typeof(int));
            var p4 = Expression.Parameter(typeof(int));
            var p5 = Expression.Parameter(typeof(int));
            var p6 = Expression.Parameter(typeof(int));
            var p7 = Expression.Parameter(typeof(int));
            var p8 = Expression.Parameter(typeof(string));
            var expr1 = Expression.Lambda(Expression.Default(typeof(int)), p1, p2, p3, p4);
            var expr2 = Expression.Lambda(Expression.Default(typeof(int)), p5, p6, p7, p8);

            _assert.AreNotEqual(sp, expr1, expr2);
            Assert.AreEqual(0, sp.Count);
        }


        [TestMethod]
        public virtual void Test005()
        {
            
            var sp = new Dictionary<ParameterExpression, ParameterExpression>();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(object));
            var p3 = Expression.Parameter(typeof(int));
            var p4 = Expression.Parameter(typeof(string));
            var p5 = Expression.Parameter(typeof(int));
            var p6 = Expression.Parameter(typeof(object));
            var p7 = Expression.Parameter(typeof(int));
            var p8 = Expression.Parameter(typeof(string));
            var expr1 = Expression.Lambda(Expression.Default(typeof(int)), p1, p2, p3, p4);
            var expr2 = Expression.Lambda(Expression.Default(typeof(int)), p5, p6, p7, p8);

            _assert.AreEqual(sp, expr1, expr2);
            Assert.AreEqual(0, sp.Count);
        }

        [TestMethod]
        public virtual void Test006()
        {
            
            var sp = new Dictionary<ParameterExpression, ParameterExpression>();
            
            var expr1 = Expression.Lambda(Expression.Default(typeof(int)));
            var expr2 = Expression.Lambda(Expression.Default(typeof(int)));

            _assert.AreEqual(sp, expr1, expr2);
            Assert.AreEqual(0, sp.Count);
        }

        [TestMethod]
        public virtual void Test007()
        {
            
            var sp = new Dictionary<ParameterExpression, ParameterExpression>();

            var expr1 = Expression.Lambda(Expression.Default(typeof(int)));
            var expr2 = Expression.Lambda(Expression.Default(typeof(string)));

            _assert.AreNotEqual(sp, expr1, expr2);
            Assert.AreEqual(0, sp.Count);
        }



        [TestMethod]
        public virtual void Test008()
        {
            
            var sp = new Dictionary<ParameterExpression, ParameterExpression>();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(object));
            var p3 = Expression.Parameter(typeof(int));
            var p4 = Expression.Parameter(typeof(string));
            var p5 = Expression.Parameter(typeof(int));
            var p6 = Expression.Parameter(typeof(object));
            var p7 = Expression.Parameter(typeof(int));
            var p8 = Expression.Parameter(typeof(string));
            var expr1 = Expression.Lambda(Expression.Default(typeof(int)), p1, p2, p3, p4);
            var expr2 = Expression.Lambda(Expression.Default(typeof(string)), p5, p6, p7, p8);

            _assert.AreNotEqual(sp, expr1, expr2);
            Assert.AreEqual(0, sp.Count);
        }
    }
}
