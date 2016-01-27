using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareNewBaseTests : CompareExpressionTestBase
    {
        public class NewConstructorData
        {
            public NewConstructorData(string val)
            {
            }
            public NewConstructorData(int val)
            {
            }

            public NewConstructorData()
            {
            }

            public string StringOne;
            public string StringTwo;
            public int IntOne;
            public int IntTwo;

            public List<NewConstructorData> NestedList;
            public NewConstructorData ChildOne;
            public NewConstructorData ChildTwo;
        }

        [TestMethod]
        public virtual void Test001()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(()=>new NewConstructorData(default(string)));
            var expr2 = xgr.FromFunc(() => new NewConstructorData(default(string)));

            _assert.AreEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test002()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new NewConstructorData(default(string)));
            var expr2 = xgr.FromFunc(() => new NewConstructorData(default(int)));

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test003()
        {
            
            var xgr = new ExpressionGenerator();

            var p1 = xgr.FromFunc(()=>default(string));
            var expr1 = xgr.FromFunc(p1, a => new NewConstructorData(a));
            var expr2 = xgr.FromFunc(p1, a => new NewConstructorData(a));

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test004()
        {
            
            var xgr = new ExpressionGenerator();

            var p1 = xgr.FromFunc(() => default(string));
            var p2 = xgr.FromFunc(() => "ABC");

            var expr1 = xgr.FromFunc(p1, a => new NewConstructorData(a));
            var expr2 = xgr.FromFunc(p2, a => new NewConstructorData(a));

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test005()
        {
            
            var xgr = new ExpressionGenerator();
            
            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test006()
        {
            
            var xgr = new ExpressionGenerator();
            
            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = 1,
                StringOne = default(string),
                StringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test007()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = 1,
                StringOne = default(string),
                StringTwo = default(string),
            });

            _assert.AreNotEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test008()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = 1,
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test009()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = 1,
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test010()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = "A",
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test011()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = "A",
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test012()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                OtherIntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test013()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                OtherIntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test014()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                OtherIntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test015()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                OtherIntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test016()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                OtherStringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test017()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                StringTwo = default(string),
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int),
                StringOne = default(string),
                OtherStringTwo = default(string),
            });

            _assert.AreNotEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test018()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int)
            });

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test019()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                OtherIntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int)
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test020()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new {
                OtherIntOne = default(int)
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test021()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(long)
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test022()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(long)
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int)
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test023()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int)
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int)
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test024()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int)
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test025()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int)
            });
            var expr2 = xgr.FromFunc(() => new {
                IntTwo = default(int),
                IntOne = default(int)
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test026()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new {
                IntTwo = default(int),
                IntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new {
                IntOne = default(int),
                IntTwo = default(int)
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test027()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new { // empty anonymous type
            });
            var expr2 = xgr.FromFunc(() => new { // empty anonymous type
            });

            _assert.AreEqual(expr1, expr2);
        }
    }
}
