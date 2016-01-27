using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareBindingsBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test005()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });

            _assert.AreEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test006()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntTwo = default(int),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test007()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test008()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test009()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test010()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test011()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntTwo = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });

            _assert.AreNotEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test012()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = "ABC",
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test013()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = 1,
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test014()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = 1,
                IntTwo = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test015()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = "ABC",
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test016()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = 1,
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test017()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = default(int),
                IntTwo = default(int),
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string),
                StringTwo = default(string),
                IntOne = 1,
                IntTwo = default(int),
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test018()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string)
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                StringOne = default(string)
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test019()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int)
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test020()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntTwo = default(int)
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test021()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData(default(int))
            {
                IntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData(default(int))
            {
                IntOne = default(int)
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test022()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData(default(int))
            {
                IntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData(default(string))
            {
                IntOne = default(int)
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test023()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData(default(int))
            {
                IntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData(default(int))
            {
                IntTwo = default(int)
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test024()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData(0)
            {
                IntOne = default(int)
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData(1)
            {
                IntOne = default(int)
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test025()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = new List<CompareNewBaseTests.NewConstructorData> {}
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = new List<CompareNewBaseTests.NewConstructorData> {}
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test026()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {}
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {}
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test027()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                }
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test028()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData()
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData()
                }
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test029()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData()
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData()
                }
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test030()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test031()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    null,
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    null,
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test032()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    null,
                    null,
                    null,
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    null,
                    null,
                    null,
                }
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test033()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData()
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    null
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test034()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    null
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData()
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test035()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData()
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test036()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData()
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test037()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    null,
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test038()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    null,
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test039()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    null,
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test040()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    null,
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test041()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                    null,
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test042()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                    null,
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test043()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test044()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = 1,
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test045()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = 1,
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test046()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = 1,
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test047()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = 1,
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test048()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = "A",
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test049()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = "A",
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test050()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test051()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test052()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test053()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntOne = default(int),
                    IntTwo = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test054()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringOne = default(string),
                    StringTwo = default(string),
                }
            });

            _assert.AreEqual(expr1, expr2);
        }
        
        [TestMethod]
        public virtual void Test055()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                }
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test056()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int),
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                },
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int),
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                },
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test057()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int),
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                },
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                },
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int),
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                },
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                },
            });

            _assert.AreEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test058()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int),
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                },
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int),
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                },
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test059()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int),
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                },
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                }
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int),
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                },
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test060()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                },
                IntOne = default(int),
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                },
            });
            var expr2 = xgr.FromFunc(() => new CompareNewBaseTests.NewConstructorData
            {
                IntOne = default(int),
                ChildOne = {
                    IntTwo = default(int),
                    IntOne = default(int),
                    StringTwo = default(string),
                    StringOne = default(string),
                },
                NestedList = {
                    new CompareNewBaseTests.NewConstructorData(),
                }
            });

            _assert.AreNotEqual(expr1, expr2);
        }
    }
}
