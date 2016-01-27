using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareListInitBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            
            var xgr = new ExpressionGenerator();

            // this does not actually generate a ListInit expression
            var expr1 = xgr.FromFunc(()=>new Dictionary<int, int> {
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int> {
            });

            _assert.AreEqual(expr1, expr2);
            Assert.IsNotNull(expr1.Body as MemberInitExpression, "Expected this to be a memberInit");

        }

        [TestMethod]
        public virtual void Test002()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1 }
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1 }
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test003()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test004()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });

            _assert.AreEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test005()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>(1)
            {
                {1, 1 }
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1 }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test006()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1 }
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>(1)
            {
                {1, 1}
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test007()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {2, 1 }
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1 }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test008()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1 }
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {2, 1 }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test009()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 2 }
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1 }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test010()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1 }
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 2 }
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        
        [TestMethod]
        public virtual void Test011()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {3, 1},
                {2, 2},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test012()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {3, 1},
                {2, 2},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test013()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 3},
                {2, 2},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test014()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 3},
                {2, 2},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test015()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {3, 2},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test016()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {3, 2},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test017()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test018()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test019()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {4, 1},
                {2, 2},
                {3, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test020()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {4, 1},
                {2, 2},
                {3, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test021()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 4},
                {2, 2},
                {3, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test022()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 4},
                {2, 2},
                {3, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test023()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {4, 2},
                {3, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test024()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {4, 2},
                {3, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test025()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 4},
                {3, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test026()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 4},
                {3, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test027()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {4, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test028()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {4, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test029()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 4},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test030()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 3},
            });
            var expr2 = xgr.FromFunc(() => new Dictionary<int, int>
            {
                {1, 1},
                {2, 2},
                {3, 4},
            });

            _assert.AreNotEqual(expr1, expr2);
        }
    }
}
