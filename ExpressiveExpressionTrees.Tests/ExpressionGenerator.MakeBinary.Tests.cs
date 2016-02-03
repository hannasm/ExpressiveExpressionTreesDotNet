using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests
{
    [TestClass]
    public class ExpressionGeneratorMakeBinaryTests
    {
        [TestMethod]
        public void Test001()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int?>(Expression.Default(typeof(int?)));

            var e1  = xgr.MakeEqualityComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.Equal,
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?)),
                    Expression.Default(typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test002()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int?>(Expression.Default(typeof(int?)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeEqualityComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.Equal,
                    Expression.Default(typeof(int?)),
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test003()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeEqualityComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.Equal,
                    Expression.Default(typeof(int)),
                    Expression.Default(typeof(int))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test011()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int?>(Expression.Default(typeof(int?)));

            var e1 = xgr.MakeInequalityComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.NotEqual,
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?)),
                    Expression.Default(typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test012()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int?>(Expression.Default(typeof(int?)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeInequalityComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.NotEqual,
                    Expression.Default(typeof(int?)),
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test013()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeInequalityComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.NotEqual,
                    Expression.Default(typeof(int)),
                    Expression.Default(typeof(int))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test021()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int?>(Expression.Default(typeof(int?)));

            var e1 = xgr.MakeGreaterThanComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.GreaterThan,
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?)),
                    Expression.Default(typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test022()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int?>(Expression.Default(typeof(int?)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeGreaterThanComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.GreaterThan,
                    Expression.Default(typeof(int?)),
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test023()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeGreaterThanComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.GreaterThan,
                    Expression.Default(typeof(int)),
                    Expression.Default(typeof(int))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test031()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int?>(Expression.Default(typeof(int?)));

            var e1 = xgr.MakeGreaterThanOrEqualComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.GreaterThanOrEqual,
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?)),
                    Expression.Default(typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test032()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int?>(Expression.Default(typeof(int?)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeGreaterThanOrEqualComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.GreaterThanOrEqual,
                    Expression.Default(typeof(int?)),
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test033()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeGreaterThanOrEqualComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.GreaterThanOrEqual,
                    Expression.Default(typeof(int)),
                    Expression.Default(typeof(int))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test041()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int?>(Expression.Default(typeof(int?)));

            var e1 = xgr.MakeGreaterThanComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.GreaterThan,
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?)),
                    Expression.Default(typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test042()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int?>(Expression.Default(typeof(int?)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeGreaterThanComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.GreaterThan,
                    Expression.Default(typeof(int?)),
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test043()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeGreaterThanComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.GreaterThan,
                    Expression.Default(typeof(int)),
                    Expression.Default(typeof(int))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test051()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int?>(Expression.Default(typeof(int?)));

            var e1 = xgr.MakeLessThanOrEqualComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.LessThanOrEqual,
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?)),
                    Expression.Default(typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test052()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int?>(Expression.Default(typeof(int?)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeLessThanOrEqualComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.LessThanOrEqual,
                    Expression.Default(typeof(int?)),
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test053()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeLessThanOrEqualComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.LessThanOrEqual,
                    Expression.Default(typeof(int)),
                    Expression.Default(typeof(int))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test061()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int?>(Expression.Default(typeof(int?)));

            var e1 = xgr.MakeLessThanComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.LessThan,
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?)),
                    Expression.Default(typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test062()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int?>(Expression.Default(typeof(int?)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeLessThanComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.LessThan,
                    Expression.Default(typeof(int?)),
                    Expression.Convert(Expression.Default(typeof(int)), typeof(int?))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test063()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeLessThanComparison(e2, e3);

            var expected = Expression.Lambda<Func<bool>>(
                Expression.MakeBinary(
                    ExpressionType.LessThan,
                    Expression.Default(typeof(int)),
                    Expression.Default(typeof(int))
                )
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test071()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int?>(Expression.Default(typeof(int?)));

            var e1 = xgr.MakeBinary(e2, ExpressionType.Add, e3);

            var expected = Expression.MakeBinary(
                ExpressionType.Add,
                Expression.Convert(Expression.Default(typeof(int)), typeof(int?)),
                Expression.Default(typeof(int?))
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test072()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int?>(Expression.Default(typeof(int?)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeBinary(e2, ExpressionType.Add, e3);

            var expected = Expression.MakeBinary(
                ExpressionType.Add,
                Expression.Default(typeof(int?)),
                Expression.Convert(Expression.Default(typeof(int)), typeof(int?))
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test073()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<int>(Expression.Default(typeof(int)));
            var e3 = xgr.WithType<int>(Expression.Default(typeof(int)));

            var e1 = xgr.MakeBinary(e2, ExpressionType.Add, e3);

            var expected = Expression.MakeBinary(
                ExpressionType.Add,
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int))
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test081()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<bool>(Expression.Default(typeof(bool)));
            var e3 = xgr.WithType<bool?>(Expression.Default(typeof(bool?)));

            var e1 = xgr.MakeAndAlso(e2, e3);

            var expected = Expression.MakeBinary(
                ExpressionType.AndAlso,
                Expression.Convert(Expression.Default(typeof(bool)), typeof(bool?)),
                Expression.Default(typeof(bool?))
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test082()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<bool?>(Expression.Default(typeof(bool?)));
            var e3 = xgr.WithType<bool>(Expression.Default(typeof(bool)));

            var e1 = xgr.MakeAndAlso(e2, e3);

            var expected = Expression.MakeBinary(
                ExpressionType.AndAlso,
                Expression.Default(typeof(bool?)),
                Expression.Convert(Expression.Default(typeof(bool)), typeof(bool?))
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test083()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<bool>(Expression.Default(typeof(bool)));
            var e3 = xgr.WithType<bool>(Expression.Default(typeof(bool)));

            var e1 = xgr.MakeAndAlso(e2, e3);

            var expected = Expression.MakeBinary(
                ExpressionType.AndAlso,
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(bool))
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }
        
        [TestMethod]
        public void Test091()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<bool>(Expression.Default(typeof(bool)));
            var e3 = xgr.WithType<bool?>(Expression.Default(typeof(bool?)));

            var e1 = xgr.MakeOrElse(e2, e3);

            var expected = Expression.MakeBinary(
                ExpressionType.OrElse,
                Expression.Convert(Expression.Default(typeof(bool)), typeof(bool?)),
                Expression.Default(typeof(bool?))
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test092()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<bool?>(Expression.Default(typeof(bool?)));
            var e3 = xgr.WithType<bool>(Expression.Default(typeof(bool)));

            var e1 = xgr.MakeOrElse(e2, e3);

            var expected = Expression.MakeBinary(
                ExpressionType.OrElse,
                Expression.Default(typeof(bool?)),
                Expression.Convert(Expression.Default(typeof(bool)), typeof(bool?))
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test093()
        {
            var xgr = new ExpressionGenerator();
            var xc = new ExpressionComparer();

            var e2 = xgr.WithType<bool>(Expression.Default(typeof(bool)));
            var e3 = xgr.WithType<bool>(Expression.Default(typeof(bool)));

            var e1 = xgr.MakeOrElse(e2, e3);

            var expected = Expression.MakeBinary(
                ExpressionType.OrElse,
                Expression.Default(typeof(bool)),
                Expression.Default(typeof(bool))
            );

            Assert.IsTrue(xc.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test100() {
            var x = 10;
            var y = (int?)null;

            var z = x > y;

            Assert.IsInstanceOfType(z, typeof(bool));
        }

        [TestMethod]
        public void Test101()
        {
            var x = true;
            var y = (bool?)null;

            var z = x == y;

            Assert.IsInstanceOfType(z, typeof(bool));
        }
    }
}
