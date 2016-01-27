using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareMethodCallBaseTests : CompareExpressionTestBase
    {
        public class MethodCallTestData
        {
            public int IntMethodOne() { throw new NotImplementedException(); }
            public int IntMethodTwo() { throw new NotImplementedException(); }

            public int TwoArgMethod(int a, int b) { throw new NotImplementedException(); }
            public int TwoArgMethod(string a, string b) { throw new NotImplementedException(); }
            public int TwoArgMethod(int a, string b) { throw new NotImplementedException(); }
            public int TwoArgMethod(string a, int b) { throw new NotImplementedException(); }
        }

        [TestMethod]
        public virtual void Test001()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(()=>default(MethodCallTestData).IntMethodOne());
            var expr2 = xgr.FromFunc(() => default(MethodCallTestData).IntMethodOne());

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test002()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MethodCallTestData).IntMethodOne());
            var expr2 = xgr.FromFunc(() => default(MethodCallTestData).IntMethodTwo());

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test003()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MethodCallTestData).IntMethodTwo());
            var expr2 = xgr.FromFunc(() => default(MethodCallTestData).IntMethodOne());

            _assert.AreNotEqual(expr1, expr2);
        }
        
        [TestMethod]
        public virtual void Test004()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(int), default(int)));
            var expr2 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(int), default(int)));

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test005()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(int), default(string)));
            var expr2 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(int), default(string)));

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test006()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(string), default(int)));
            var expr2 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(string), default(int)));

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test007()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(string), default(string)));
            var expr2 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(string), default(string)));

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test008()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(int), default(int)));
            var expr2 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(string), default(int)));

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test009()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(int), default(int)));
            var expr2 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(int), default(string)));

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test010()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(int), default(int)));
            var expr2 = xgr.FromFunc(() => default(MethodCallTestData).TwoArgMethod(default(string), default(string)));

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test011()
        {
            
            var xgr = new ExpressionGenerator();

            var obj1Expr = Expression.Lambda<Func<MethodCallTestData>>(Expression.Constant(null, typeof(MethodCallTestData)));
            var obj2Expr = Expression.Lambda<Func<MethodCallTestData>>(Expression.Constant(null, typeof(MethodCallTestData)));
            
            var expr1 = xgr.FromFunc(obj1Expr, obj1 => obj1.IntMethodOne());
            var expr2 = xgr.FromFunc(obj2Expr, obj2 => obj2.IntMethodOne());
            
            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test012()
        {
            
            var xgr = new ExpressionGenerator();

            MethodCallTestData obj1 = null;
            MethodCallTestData obj2 = null;

            var expr1 = xgr.FromFunc(() => obj1.IntMethodOne());
            var expr2 = xgr.FromFunc(() => obj2.IntMethodOne());

            // these aren't equal because the expressions (.NET 3.5 -> .nET 4.5.2+) are generated as a member access
            // on a constant over the invisible closure, instead of a constant reference to the objects themselves
            // TODO: Keep this up to date as new versions are released
            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test013()
        {
            
            var xgr = new ExpressionGenerator();

            var obj = new MethodCallTestData();

            var obj1Expr = Expression.Lambda<Func<MethodCallTestData>>(Expression.Constant(obj, typeof(MethodCallTestData)));
            var obj2Expr = Expression.Lambda<Func<MethodCallTestData>>(Expression.Constant(obj, typeof(MethodCallTestData)));

            var expr1 = xgr.FromFunc(obj1Expr, obj1 => obj1.IntMethodOne());
            var expr2 = xgr.FromFunc(obj2Expr, obj2 => obj2.IntMethodOne());

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test014()
        {
            
            var xgr = new ExpressionGenerator();

            MethodCallTestData obj1 = new MethodCallTestData();
            MethodCallTestData obj2 = obj1;

            var expr1 = xgr.FromFunc(() => obj1.IntMethodOne());
            var expr2 = xgr.FromFunc(() => obj2.IntMethodOne());

            // these aren't equal because the expressions (.NET 3.5 -> .nET 4.5.2+) are generated as a member access
            // on a constant over the invisible closure, instead of a constant reference to the objects themselves
            // TODO: Keep this up to date as new versions are released
            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test015()
        {
            
            var xgr = new ExpressionGenerator();

            var obj1 = new MethodCallTestData();
            var obj2 = new MethodCallTestData();

            var obj1Expr = Expression.Lambda<Func<MethodCallTestData>>(Expression.Constant(obj1, typeof(MethodCallTestData)));
            var obj2Expr = Expression.Lambda<Func<MethodCallTestData>>(Expression.Constant(obj2, typeof(MethodCallTestData)));

            var expr1 = xgr.FromFunc(obj1Expr, pobj1 => pobj1.IntMethodOne());
            var expr2 = xgr.FromFunc(obj2Expr, pobj2 => pobj2.IntMethodOne());

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test016()
        {
            
            var xgr = new ExpressionGenerator();

            MethodCallTestData obj1 = new MethodCallTestData();
            MethodCallTestData obj2 = new MethodCallTestData();

            var expr1 = xgr.FromFunc(() => obj1.IntMethodOne());
            var expr2 = xgr.FromFunc(() => obj2.IntMethodOne());

            // these aren't equal because the expressions (.NET 3.5 -> .nET 4.5.2+) are generated as a member access
            // on a constant over the invisible closure, instead of a constant reference to the objects themselves
            // TODO: Keep this up to date as new versions are released
            _assert.AreNotEqual(expr1, expr2);
        }

    }
}
