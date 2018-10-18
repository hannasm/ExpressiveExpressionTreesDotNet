using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class TryCatchVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e1 = Expression.Default(typeof(int));
            var e2 = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(10, typeof(int));
            var e4 = Expression.Catch(e2, e3);
            var e5 = Expression.TryCatch(e1, e4);

            var assert = ExpressionVisitorVerifierTool.Test(e5);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            // fault, finally, and catch block filter
            assert.WasVisited(null, 3);
            assert.WasProduced(null, 3);

            assert.TotalVisits(7);
            assert.TotalProduced(7);

            var cbResult = (TryExpression)assert.Result;
            Assert.AreEqual(cbResult.Handlers[0], e4);
        }

        [TestMethod]
        public void Test002()
        {
            var e1 = Expression.Constant(10, typeof(int));
            var e2 = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(11, typeof(int));
            var e4 = Expression.Catch(e2, e3);

            var e6 = Expression.Parameter(typeof(NullReferenceException));
            var e7 = Expression.Constant(13, typeof(int));
            var e8 = Expression.Catch(e6, e7);

            var e9 = Expression.TryCatch(e1, e4, e8);

            var assert = ExpressionVisitorVerifierTool.Test(e9);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.WasVisited(e6);
            assert.WasProduced(e6);
            assert.WasVisited(e7);
            assert.WasProduced(e7);

            assert.WasVisited(e9);
            assert.WasProduced(e9);

            // fault, finally, and 2x catch block filter
            assert.WasVisited(null, 4);
            assert.WasProduced(null, 4);

            assert.TotalVisits(10);
            assert.TotalProduced(10);

            var cbResult = (TryExpression)assert.Result;
            Assert.AreEqual(cbResult.Handlers[0], e4);
            Assert.AreEqual(cbResult.Handlers[1], e8);
        }

        [TestMethod]
        public void Test003()
        {
            var e1 = Expression.Constant(10, typeof(int));

            var e2 = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(11, typeof(int));
            var e4 = Expression.Catch(e2, e3);

            var e6 = Expression.Parameter(typeof(NullReferenceException));
            var e7 = Expression.Constant(13, typeof(int));
            var e8 = Expression.Catch(e6, e7);

            var e10 = Expression.Parameter(typeof(AggregateException));
            var e11 = Expression.Constant(15, typeof(int));
            var e12 = Expression.Catch(e10, e11);

            var e14 = Expression.TryCatch(e1, e4, e8, e12);

            var assert = ExpressionVisitorVerifierTool.Test(e14);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.WasVisited(e6);
            assert.WasProduced(e6);
            assert.WasVisited(e7);
            assert.WasProduced(e7);

            assert.WasVisited(e10);
            assert.WasProduced(e10);
            assert.WasVisited(e11);
            assert.WasProduced(e11);

            assert.WasVisited(e14);
            assert.WasProduced(e14);

            // fault, finally, and 3x catch block filter
            assert.WasVisited(null, 5);
            assert.WasProduced(null, 5);

            assert.TotalVisits(13);
            assert.TotalProduced(13);

            var cbResult = (TryExpression)assert.Result;
            Assert.AreEqual(cbResult.Handlers[0], e4);
            Assert.AreEqual(cbResult.Handlers[1], e8);
            Assert.AreEqual(cbResult.Handlers[2], e12);
        }

        [TestMethod]
        public void Test011()
        {
            var e1 = Expression.Constant(9, typeof(int));

            var e2 = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(10, typeof(int));
            var e4 = Expression.Catch(e2, e3);

            var e6 = Expression.Constant(20, typeof(int));

            var e5 = Expression.TryCatchFinally(e1, e6, e4);


            var assert = ExpressionVisitorVerifierTool.Test(e5);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e6);
            assert.WasProduced(e6);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            // fault and catch block filter
            assert.WasVisited(null, 2);
            assert.WasProduced(null, 2);

            assert.TotalVisits(7);
            assert.TotalProduced(7);
        }

        [TestMethod]
        public void Test012()
        {
            var e1 = Expression.Constant(10, typeof(int));
            var e2 = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(11, typeof(int));
            var e4 = Expression.Catch(e2, e3);

            var e6 = Expression.Parameter(typeof(NullReferenceException));
            var e7 = Expression.Constant(13, typeof(int));
            var e8 = Expression.Catch(e6, e7);

            var e11 = Expression.Constant(20, typeof(int));

            var e9 = Expression.TryCatchFinally(e1, e11, e4, e8);

            var assert = ExpressionVisitorVerifierTool.Test(e9);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.WasVisited(e6);
            assert.WasProduced(e6);
            assert.WasVisited(e7);
            assert.WasProduced(e7);

            assert.WasVisited(e11);
            assert.WasProduced(e11);

            assert.WasVisited(e9);
            assert.WasProduced(e9);

            // fault and 2x catch block filter
            assert.WasVisited(null, 3);
            assert.WasProduced(null, 3);

            assert.TotalVisits(10);
            assert.TotalProduced(10);
        }

        [TestMethod]
        public void Test013()
        {
            var e1 = Expression.Constant(10, typeof(int));

            var e2 = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(11, typeof(int));
            var e4 = Expression.Catch(e2, e3);

            var e6 = Expression.Parameter(typeof(NullReferenceException));
            var e7 = Expression.Constant(13, typeof(int));
            var e8 = Expression.Catch(e6, e7);

            var e10 = Expression.Parameter(typeof(AggregateException));
            var e11 = Expression.Constant(15, typeof(int));
            var e12 = Expression.Catch(e10, e11);

            var e13 = Expression.Constant(20, typeof(int));

            var e14 = Expression.TryCatchFinally(e1, e13, e4, e8, e12);

            var assert = ExpressionVisitorVerifierTool.Test(e14);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.WasVisited(e6);
            assert.WasProduced(e6);
            assert.WasVisited(e7);
            assert.WasProduced(e7);

            assert.WasVisited(e10);
            assert.WasProduced(e10);
            assert.WasVisited(e11);
            assert.WasProduced(e11);

            assert.WasVisited(e13);
            assert.WasProduced(e13);

            assert.WasVisited(e14);
            assert.WasProduced(e14);

            // fault and 3x catch block filter
            assert.WasVisited(null, 4);
            assert.WasProduced(null, 4);

            assert.TotalVisits(13);
            assert.TotalProduced(13);
        }

        [TestMethod]
        public void Test021()
        {
            var e1 = Expression.Constant(1, typeof(int));
            var e2 = Expression.Constant(2, typeof(int));

            var e5 = Expression.TryFinally(e1, e2);

            var assert = ExpressionVisitorVerifierTool.Test(e5);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            // fault
            assert.WasVisited(null, 1);
            assert.WasProduced(null, 1);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test022()
        {
            var e1 = Expression.Constant(1, typeof(int));
            var e2 = Expression.Constant(2, typeof(int));

            var e5 = Expression.TryFault(e1, e2);

            var assert = ExpressionVisitorVerifierTool.Test(e5);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            // finally
            assert.WasVisited(null, 1);
            assert.WasProduced(null, 1);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test031()
        {
            var e1 = Expression.Default(typeof(int));

            var e2 = Expression.Parameter(typeof(Exception));
            var e2n = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(10, typeof(int));
            var e6 = Expression.Constant(true, typeof(bool));
            var e4 = Expression.Catch(e2, e3, e6);

            var e5 = Expression.TryCatch(e1, e4);

            var replacer = new Dictionary<Expression,Expression> {
                { e2,  e2n }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e5, replacer);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(e2n);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e6);
            assert.WasProduced(e6);

            assert.WasVisited(e5);
            assert.WasNotProduced(e5);
            assert.WasProduced(assert.Result);

            // fault, finally
            assert.WasVisited(null, 2);
            assert.WasProduced(null, 2);

            assert.TotalVisits(7);
            assert.TotalProduced(7);
        }

        [TestMethod]
        public void Test032()
        {
            var e1 = Expression.Default(typeof(int));

            var e2 = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(10, typeof(int));
            var e3n = Expression.Constant(14, typeof(int));
            var e6 = Expression.Constant(true, typeof(bool));
            var e4 = Expression.Catch(e2, e3, e6);

            var e5 = Expression.TryCatch(e1, e4);

            var replacer = new Dictionary<Expression,Expression> {
                { e3,  e3n }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e5, replacer);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(e3n);
            assert.WasVisited(e6);
            assert.WasProduced(e6);

            assert.WasVisited(e5);
            assert.WasNotProduced(e5);
            assert.WasProduced(assert.Result);

            // fault, finally
            assert.WasVisited(null, 2);
            assert.WasProduced(null, 2);

            assert.TotalVisits(7);
            assert.TotalProduced(7);
        }

        [TestMethod]
        public void Test033()
        {
            var e1 = Expression.Default(typeof(int));

            var e2 = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(10, typeof(int));
            var e6 = Expression.Constant(true, typeof(bool));
            var e6n = Expression.Constant(false, typeof(bool));
            var e4 = Expression.Catch(e2, e3, e6);

            var e5 = Expression.TryCatch(e1, e4);

            var replacer = new Dictionary<Expression,Expression> {
                { e6,  e6n }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e5, replacer);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e6);
            assert.WasNotProduced(e6);
            assert.WasProduced(e6n);

            assert.WasVisited(e5);
            assert.WasNotProduced(e5);
            assert.WasProduced(assert.Result);

            // fault, finally
            assert.WasVisited(null, 2);
            assert.WasProduced(null, 2);

            assert.TotalVisits(7);
            assert.TotalProduced(7);
        }

        [TestMethod]
        public void Test041()
        {
            var e1 = Expression.Constant(10, typeof(int));

            var e2 = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(11, typeof(int));
            var e4 = Expression.Catch(e2, e3);
            var e4n = Expression.Catch(e2, e3);

            var e6 = Expression.Parameter(typeof(NullReferenceException));
            var e7 = Expression.Constant(13, typeof(int));
            var e8 = Expression.Catch(e6, e7);

            var e10 = Expression.Parameter(typeof(AggregateException));
            var e11 = Expression.Constant(15, typeof(int));
            var e12 = Expression.Catch(e10, e11);

            var e14 = Expression.TryCatch(e1, e4, e8, e12);

            var assert = ExpressionVisitorVerifierTool.Create();
            assert.CatchBlockReplace.Add(e4, e4n);
            assert.Execute(e14);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.WasVisited(e6);
            assert.WasProduced(e6);
            assert.WasVisited(e7);
            assert.WasProduced(e7);

            assert.WasVisited(e10);
            assert.WasProduced(e10);
            assert.WasVisited(e11);
            assert.WasProduced(e11);

            assert.WasVisited(e14);
            assert.WasNotProduced(e14);
            assert.WasProduced(assert.Result);

            // fault, finally, and 3x catch block filter
            assert.WasVisited(null, 5);
            assert.WasProduced(null, 5);

            assert.TotalVisits(13);
            assert.TotalProduced(13);

            var cbResult = (TryExpression)assert.Result;

            Assert.AreEqual(cbResult.Handlers[0], e4n);
            Assert.AreEqual(cbResult.Handlers[1], e8);
            Assert.AreEqual(cbResult.Handlers[2], e12);
        }

        [TestMethod]
        public void Test042()
        {
            var e1 = Expression.Constant(10, typeof(int));

            var e2 = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(11, typeof(int));
            var e4 = Expression.Catch(e2, e3);

            var e6 = Expression.Parameter(typeof(NullReferenceException));
            var e7 = Expression.Constant(13, typeof(int));
            var e8 = Expression.Catch(e6, e7);
            var e8n = Expression.Catch(e6, e7);

            var e10 = Expression.Parameter(typeof(AggregateException));
            var e11 = Expression.Constant(15, typeof(int));
            var e12 = Expression.Catch(e10, e11);

            var e14 = Expression.TryCatch(e1, e4, e8, e12);

            var assert = ExpressionVisitorVerifierTool.Create();
            assert.CatchBlockReplace.Add(e8, e8n);
            assert.Execute(e14);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.WasVisited(e6);
            assert.WasProduced(e6);
            assert.WasVisited(e7);
            assert.WasProduced(e7);

            assert.WasVisited(e10);
            assert.WasProduced(e10);
            assert.WasVisited(e11);
            assert.WasProduced(e11);

            assert.WasVisited(e14);
            assert.WasNotProduced(e14);
            assert.WasProduced(assert.Result);

            // fault, finally, and 3x catch block filter
            assert.WasVisited(null, 5);
            assert.WasProduced(null, 5);

            assert.TotalVisits(13);
            assert.TotalProduced(13);

            var cbResult = (TryExpression)assert.Result;

            Assert.AreEqual(cbResult.Handlers[0], e4);
            Assert.AreEqual(cbResult.Handlers[1], e8n);
            Assert.AreEqual(cbResult.Handlers[2], e12);
        }

        [TestMethod]
        public void Test043()
        {
            var e1 = Expression.Constant(10, typeof(int));

            var e2 = Expression.Parameter(typeof(Exception));
            var e3 = Expression.Constant(11, typeof(int));
            var e4 = Expression.Catch(e2, e3);

            var e6 = Expression.Parameter(typeof(NullReferenceException));
            var e7 = Expression.Constant(13, typeof(int));
            var e8 = Expression.Catch(e6, e7);

            var e10 = Expression.Parameter(typeof(AggregateException));
            var e11 = Expression.Constant(15, typeof(int));
            var e12 = Expression.Catch(e10, e11);
            var e12n = Expression.Catch(e10, e11);

            var e14 = Expression.TryCatch(e1, e4, e8, e12);

            var assert = ExpressionVisitorVerifierTool.Create();
            assert.CatchBlockReplace.Add(e12, e12n);
            assert.Execute(e14);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.WasVisited(e6);
            assert.WasProduced(e6);
            assert.WasVisited(e7);
            assert.WasProduced(e7);

            assert.WasVisited(e10);
            assert.WasProduced(e10);
            assert.WasVisited(e11);
            assert.WasProduced(e11);

            assert.WasVisited(e14);
            assert.WasNotProduced(e14);
            assert.WasProduced(assert.Result);

            // fault, finally, and 3x catch block filter
            assert.WasVisited(null, 5);
            assert.WasProduced(null, 5);

            assert.TotalVisits(13);
            assert.TotalProduced(13);

            var cbResult = (TryExpression)assert.Result;

            Assert.AreEqual(cbResult.Handlers[0], e4);
            Assert.AreEqual(cbResult.Handlers[1], e8);
            Assert.AreEqual(cbResult.Handlers[2], e12n);
        }
    }
}
