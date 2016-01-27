using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareNewArrayBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(()=>new string[0]);
            var expr2 = xgr.FromFunc(() => new string[0]);

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test002()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[10]);
            var expr2 = xgr.FromFunc(() => new string[10]);

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test003()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { });
            var expr2 = xgr.FromFunc(() => new string[] { });

            _assert.AreEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test004()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A" });
            var expr2 = xgr.FromFunc(() => new string[] { "A" });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test005()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A", "B" });
            var expr2 = xgr.FromFunc(() => new string[] { "A", "B" });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test006()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A", "B", "C" });
            var expr2 = xgr.FromFunc(() => new string[] { "A", "B", "C" });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test007()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A", "B", "C", "D" });
            var expr2 = xgr.FromFunc(() => new string[] { "A", "B", "C", "D" });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test008()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[0]);
            var expr2 = xgr.FromFunc(() => new string[1]);

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test009()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[1]);
            var expr2 = xgr.FromFunc(() => new string[0]);

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test010()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new int[0]);
            var expr2 = xgr.FromFunc(() => new string[0]);

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test011()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[0]);
            var expr2 = xgr.FromFunc(() => new int[0]);

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test012()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A" });
            var expr2 = xgr.FromFunc(() => new string[] { "B" });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test013()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A", "A" });
            var expr2 = xgr.FromFunc(() => new string[] { "B", "A" });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test014()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "B", "A" });
            var expr2 = xgr.FromFunc(() => new string[] { "A", "A" });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test015()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A", "A" });
            var expr2 = xgr.FromFunc(() => new string[] { "A", "B" });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test016()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A", "B" });
            var expr2 = xgr.FromFunc(() => new string[] { "A", "A" });

            _assert.AreNotEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test017()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "B", "B", "C", "D" });
            var expr2 = xgr.FromFunc(() => new string[] { "A", "B", "C", "D" });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test018()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A", "B", "C", "D" });
            var expr2 = xgr.FromFunc(() => new string[] { "B", "B", "C", "D" });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test019()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A", "B", "A", "D" });
            var expr2 = xgr.FromFunc(() => new string[] { "A", "B", "C", "D" });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test020()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A", "B", "C", "D" });
            var expr2 = xgr.FromFunc(() => new string[] { "A", "B", "A", "D" });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test021()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A", "B", "C", "A" });
            var expr2 = xgr.FromFunc(() => new string[] { "A", "B", "C", "D" });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test022()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new string[] { "A", "B", "C", "D" });
            var expr2 = xgr.FromFunc(() => new string[] { "A", "B", "C", "A" });

            _assert.AreNotEqual(expr1, expr2);
        }
    }
}
