using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareTryCatchBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public void Test001()
        {

            var e11 = Expression.Default(typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(10, typeof(int));
            var e41 = Expression.Catch(e21, e31);
            var e51 = Expression.TryCatch(e11, e41);

            var e12 = Expression.Default(typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(10, typeof(int));
            var e42 = Expression.Catch(e22, e32);
            var e52 = Expression.TryCatch(e12, e42);

            _assert.AreEqual(e51, e52);
        }

        [TestMethod]
        public void Test002()
        {
            var e11 = Expression.Constant(10, typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(11, typeof(int));
            var e41 = Expression.Catch(e21, e31);
            var e61 = Expression.Parameter(typeof(NullReferenceException));
            var e71 = Expression.Constant(13, typeof(int));
            var e81 = Expression.Catch(e61, e71);
            var e91 = Expression.TryCatch(e11, e41, e81);

            var e12 = Expression.Constant(10, typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(11, typeof(int));
            var e42 = Expression.Catch(e22, e32);
            var e62 = Expression.Parameter(typeof(NullReferenceException));
            var e72 = Expression.Constant(13, typeof(int));
            var e82 = Expression.Catch(e62, e72);
            var e92 = Expression.TryCatch(e12, e42, e82);

            _assert.AreEqual(e91, e92);
        }

        [TestMethod]
        public void Test003()
        {
            var e11 = Expression.Constant(10, typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(11, typeof(int));
            var e41 = Expression.Catch(e21, e31);
            var e61 = Expression.Parameter(typeof(NullReferenceException));
            var e71 = Expression.Constant(13, typeof(int));
            var e81 = Expression.Catch(e61, e71);
            var e110 = Expression.Parameter(typeof(AggregateException));
            var e111 = Expression.Constant(15, typeof(int));
            var e112 = Expression.Catch(e110, e111);
            var e114 = Expression.TryCatch(e11, e41, e81, e112);

            var e12 = Expression.Constant(10, typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(11, typeof(int));
            var e42 = Expression.Catch(e22, e32);
            var e62 = Expression.Parameter(typeof(NullReferenceException));
            var e72 = Expression.Constant(13, typeof(int));
            var e82 = Expression.Catch(e62, e72);
            var e120 = Expression.Parameter(typeof(AggregateException));
            var e121 = Expression.Constant(15, typeof(int));
            var e122 = Expression.Catch(e120, e121);
            var e124 = Expression.TryCatch(e12, e42, e82, e122);

            _assert.AreEqual(e114, e124);
        }

        [TestMethod]
        public void Test011()
        {
            var e11 = Expression.Constant(9, typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(10, typeof(int));
            var e41 = Expression.Catch(e21, e31);
            var e61 = Expression.Constant(20, typeof(int));
            var e51 = Expression.TryCatchFinally(e11, e61, e41);

            var e12 = Expression.Constant(9, typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(10, typeof(int));
            var e42 = Expression.Catch(e22, e32);
            var e62 = Expression.Constant(20, typeof(int));
            var e52 = Expression.TryCatchFinally(e12, e62, e42);

            _assert.AreEqual(e51, e52);
        }

        [TestMethod]
        public void Test012()
        {
            var e11 = Expression.Constant(10, typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(11, typeof(int));
            var e41 = Expression.Catch(e21, e31);
            var e61 = Expression.Parameter(typeof(NullReferenceException));
            var e71 = Expression.Constant(13, typeof(int));
            var e81 = Expression.Catch(e61, e71);
            var e111 = Expression.Constant(20, typeof(int));
            var e91 = Expression.TryCatchFinally(e11, e111, e41, e81);

            var e12 = Expression.Constant(10, typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(11, typeof(int));
            var e42 = Expression.Catch(e22, e32);
            var e62 = Expression.Parameter(typeof(NullReferenceException));
            var e72 = Expression.Constant(13, typeof(int));
            var e82 = Expression.Catch(e62, e72);
            var e121 = Expression.Constant(20, typeof(int));
            var e92 = Expression.TryCatchFinally(e12, e121, e42, e82);

            _assert.AreEqual(e91, e92);
        }

        [TestMethod]
        public void Test013()
        {
            var e11 = Expression.Constant(10, typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(11, typeof(int));
            var e41 = Expression.Catch(e21, e31);
            var e61 = Expression.Parameter(typeof(NullReferenceException));
            var e71 = Expression.Constant(13, typeof(int));
            var e81 = Expression.Catch(e61, e71);
            var e110 = Expression.Parameter(typeof(AggregateException));
            var e111 = Expression.Constant(15, typeof(int));
            var e112 = Expression.Catch(e110, e111);
            var e113 = Expression.Constant(20, typeof(int));
            var e114 = Expression.TryCatchFinally(e11, e113, e41, e81, e112);

            var e12 = Expression.Constant(10, typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(11, typeof(int));
            var e42 = Expression.Catch(e22, e32);
            var e62 = Expression.Parameter(typeof(NullReferenceException));
            var e72 = Expression.Constant(13, typeof(int));
            var e82 = Expression.Catch(e62, e72);
            var e120 = Expression.Parameter(typeof(AggregateException));
            var e121 = Expression.Constant(15, typeof(int));
            var e122 = Expression.Catch(e120, e121);
            var e123 = Expression.Constant(20, typeof(int));
            var e124 = Expression.TryCatchFinally(e12, e123, e42, e82, e122);

            _assert.AreEqual(e114, e124);
        }

        [TestMethod]
        public void Test021()
        {
            var e11 = Expression.Constant(1, typeof(int));
            var e21 = Expression.Constant(2, typeof(int));
            var e51 = Expression.TryFinally(e11, e21);

            var e12 = Expression.Constant(1, typeof(int));
            var e22 = Expression.Constant(2, typeof(int));
            var e52 = Expression.TryFinally(e12, e22);

            _assert.AreEqual(e51, e52);
        }

        [TestMethod]
        public void Test022()
        {
            var e11 = Expression.Constant(1, typeof(int));
            var e21 = Expression.Constant(2, typeof(int));
            var e51 = Expression.TryFault(e11, e21);

            var e12 = Expression.Constant(1, typeof(int));
            var e22 = Expression.Constant(2, typeof(int));
            var e52 = Expression.TryFault(e12, e22);

            _assert.AreEqual(e51, e52);
        }

        [TestMethod]
        public void Test031()
        {
            var e11 = Expression.Default(typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e21n = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(10, typeof(int));
            var e61 = Expression.Constant(true, typeof(bool));
            var e41 = Expression.Catch(e21, e31, e61);
            var e51 = Expression.TryCatch(e11, e41);

            var e12 = Expression.Default(typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e22n = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(10, typeof(int));
            var e62 = Expression.Constant(true, typeof(bool));
            var e42 = Expression.Catch(e22, e32, e62);
            var e52 = Expression.TryCatch(e12, e42);

            _assert.AreEqual(e51, e52);
        }

        [TestMethod]
        public void Test032()
        {
            var e11 = Expression.Default(typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(10, typeof(int));
            var e31n = Expression.Constant(14, typeof(int));
            var e61 = Expression.Constant(true, typeof(bool));
            var e41 = Expression.Catch(e21, e31, e61);
            var e51 = Expression.TryCatch(e11, e41);

            var e12 = Expression.Default(typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(10, typeof(int));
            var e32n = Expression.Constant(14, typeof(int));
            var e62 = Expression.Constant(true, typeof(bool));
            var e42 = Expression.Catch(e22, e32, e62);
            var e52 = Expression.TryCatch(e12, e42);

            _assert.AreEqual(e51, e52);
        }

        [TestMethod]
        public void Test033()
        {
            var e11 = Expression.Default(typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(10, typeof(int));
            var e61 = Expression.Constant(true, typeof(bool));
            var e61n = Expression.Constant(false, typeof(bool));
            var e41 = Expression.Catch(e21, e31, e61);
            var e51 = Expression.TryCatch(e11, e41);

            var e12 = Expression.Default(typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(10, typeof(int));
            var e62 = Expression.Constant(true, typeof(bool));
            var e62n = Expression.Constant(false, typeof(bool));
            var e42 = Expression.Catch(e22, e32, e62);
            var e52 = Expression.TryCatch(e12, e42);

            _assert.AreEqual(e51, e52);
        }

        [TestMethod]
        public void Test041()
        {
            var e11 = Expression.Constant(10, typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(11, typeof(int));
            var e41 = Expression.Catch(e21, e31);
            var e41n = Expression.Catch(e21, e31);
            var e61 = Expression.Parameter(typeof(NullReferenceException));
            var e71 = Expression.Constant(13, typeof(int));
            var e81 = Expression.Catch(e61, e71);
            var e110 = Expression.Parameter(typeof(AggregateException));
            var e111 = Expression.Constant(15, typeof(int));
            var e112 = Expression.Catch(e110, e111);
            var e114 = Expression.TryCatch(e11, e41, e81, e112);

            var e12 = Expression.Constant(10, typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(11, typeof(int));
            var e42 = Expression.Catch(e22, e32);
            var e42n = Expression.Catch(e22, e32);
            var e62 = Expression.Parameter(typeof(NullReferenceException));
            var e72 = Expression.Constant(13, typeof(int));
            var e82 = Expression.Catch(e62, e72);
            var e120 = Expression.Parameter(typeof(AggregateException));
            var e121 = Expression.Constant(15, typeof(int));
            var e122 = Expression.Catch(e120, e121);
            var e124 = Expression.TryCatch(e12, e42, e82, e122);

            _assert.AreEqual(e114, e124);
        }

        [TestMethod]
        public void Test042()
        {
            var e11 = Expression.Constant(10, typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(11, typeof(int));
            var e41 = Expression.Catch(e21, e31);
            var e61 = Expression.Parameter(typeof(NullReferenceException));
            var e71 = Expression.Constant(13, typeof(int));
            var e81 = Expression.Catch(e61, e71);
            var e81n = Expression.Catch(e61, e71);
            var e110 = Expression.Parameter(typeof(AggregateException));
            var e111 = Expression.Constant(15, typeof(int));
            var e112 = Expression.Catch(e110, e111);
            var e114 = Expression.TryCatch(e11, e41, e81, e112);

            var e12 = Expression.Constant(10, typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(11, typeof(int));
            var e42 = Expression.Catch(e22, e32);
            var e62 = Expression.Parameter(typeof(NullReferenceException));
            var e72 = Expression.Constant(13, typeof(int));
            var e82 = Expression.Catch(e62, e72);
            var e82n = Expression.Catch(e62, e72);
            var e120 = Expression.Parameter(typeof(AggregateException));
            var e121 = Expression.Constant(15, typeof(int));
            var e122 = Expression.Catch(e120, e121);
            var e124 = Expression.TryCatch(e12, e42, e82, e122);

            _assert.AreEqual(e114, e124);
        }

        [TestMethod]
        public void Test043()
        {
            var e11 = Expression.Constant(10, typeof(int));
            var e21 = Expression.Parameter(typeof(Exception));
            var e31 = Expression.Constant(11, typeof(int));
            var e41 = Expression.Catch(e21, e31);
            var e61 = Expression.Parameter(typeof(NullReferenceException));
            var e71 = Expression.Constant(13, typeof(int));
            var e81 = Expression.Catch(e61, e71);
            var e110 = Expression.Parameter(typeof(AggregateException));
            var e111 = Expression.Constant(15, typeof(int));
            var e112 = Expression.Catch(e110, e111);
            var e112n = Expression.Catch(e110, e111);
            var e114 = Expression.TryCatch(e11, e41, e81, e112);

            var e12 = Expression.Constant(10, typeof(int));
            var e22 = Expression.Parameter(typeof(Exception));
            var e32 = Expression.Constant(11, typeof(int));
            var e42 = Expression.Catch(e22, e32);
            var e62 = Expression.Parameter(typeof(NullReferenceException));
            var e72 = Expression.Constant(13, typeof(int));
            var e82 = Expression.Catch(e62, e72);
            var e120 = Expression.Parameter(typeof(AggregateException));
            var e121 = Expression.Constant(15, typeof(int));
            var e122 = Expression.Catch(e120, e121);
            var e122n = Expression.Catch(e120, e121);
            var e124 = Expression.TryCatch(e12, e42, e82, e122);

            _assert.AreEqual(e114, e124);
        }
    }
}
