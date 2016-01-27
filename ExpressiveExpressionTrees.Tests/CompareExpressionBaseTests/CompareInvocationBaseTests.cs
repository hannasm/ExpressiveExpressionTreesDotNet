using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareInvocationBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(int))));
            var expr2 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(int))));

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test002()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(int))));
            var expr2 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(long))));

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test003()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(long))));
            var expr2 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(int))));

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test004()
        {
            
            var xgr = new ExpressionGenerator();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));

            var expr1 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(int)), p1), Expression.Default(typeof(int)));
            var expr2 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(int)), p2), Expression.Default(typeof(int)));

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test005()
        {
            
            var xgr = new ExpressionGenerator();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));

            var expr1 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(int)), p1), Expression.Default(typeof(int)));
            var expr2 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(int)), p2), Expression.Constant(0, typeof(int)));

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test006()
        {
            
            var xgr = new ExpressionGenerator();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));

            var expr1 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(int)), p1), Expression.Constant(0, typeof(int)));
            var expr2 = Expression.Invoke(Expression.Lambda(Expression.Default(typeof(int)), p2), Expression.Default(typeof(int)));

            _assert.AreNotEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test007()
        {
            
            var xgr = new ExpressionGenerator();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));
            var p3 = Expression.Parameter(typeof(int));
            var p4 = Expression.Parameter(typeof(int));

            var expr1 = Expression.Invoke(
                Expression.Lambda(Expression.Default(typeof(int)), p1, p2),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)));
            var expr2 = Expression.Invoke(
                Expression.Lambda(Expression.Default(typeof(int)), p3, p4),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)));

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test008()
        {
            
            var xgr = new ExpressionGenerator();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));
            var p3 = Expression.Parameter(typeof(int));
            var p4 = Expression.Parameter(typeof(int));

            var expr1 = Expression.Invoke(
                Expression.Lambda(Expression.Default(typeof(int)), p1, p2),
                Expression.Constant(0, typeof(int)), 
                Expression.Default(typeof(int)));
            var expr2 = Expression.Invoke(
                Expression.Lambda(Expression.Default(typeof(int)), p3, p4), 
                Expression.Default(typeof(int)), 
                Expression.Default(typeof(int)));

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test009()
        {
            
            var xgr = new ExpressionGenerator();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));
            var p3 = Expression.Parameter(typeof(int));
            var p4 = Expression.Parameter(typeof(int));

            var expr1 = Expression.Invoke(
                Expression.Lambda(Expression.Default(typeof(int)), p1, p2),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)));
            var expr2 = Expression.Invoke(
                Expression.Lambda(Expression.Default(typeof(int)), p3, p4),
                Expression.Constant(0, typeof(int)),
                Expression.Default(typeof(int)));

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test010()
        {
            
            var xgr = new ExpressionGenerator();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));
            var p3 = Expression.Parameter(typeof(int));
            var p4 = Expression.Parameter(typeof(int));

            var expr1 = Expression.Invoke(
                Expression.Lambda(Expression.Default(typeof(int)), p1, p2),
                Expression.Default(typeof(int)),
                Expression.Constant(0, typeof(int)));
            var expr2 = Expression.Invoke(
                Expression.Lambda(Expression.Default(typeof(int)), p3, p4),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)));

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test011()
        {
            
            var xgr = new ExpressionGenerator();

            var p1 = Expression.Parameter(typeof(int));
            var p2 = Expression.Parameter(typeof(int));
            var p3 = Expression.Parameter(typeof(int));
            var p4 = Expression.Parameter(typeof(int));

            var expr1 = Expression.Invoke(
                Expression.Lambda(Expression.Default(typeof(int)), p1, p2),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)));
            var expr2 = Expression.Invoke(
                Expression.Lambda(Expression.Default(typeof(int)), p3, p4),
                Expression.Default(typeof(int)),
                Expression.Constant(0, typeof(int)));

            _assert.AreNotEqual(expr1, expr2);
        }
    }
}
