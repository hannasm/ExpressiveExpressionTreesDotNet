using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveExpressionTrees.Tests
{
    [TestClass]
    public class ExpressionReaderTests
    {
        [TestMethod]
        public void Test001()
        {
            var xgr = new ExpressionGenerator();
            var xpr = new ExpressionReader();

            var expr = xgr.FromFunc(()=>default(IQueryable<int>).Where(x=>x > 10));
            var expr2 = ((MethodCallExpression)expr.Body).Arguments[1];

            var body = xpr.GetLambda(expr2);

            Assert.AreNotEqual(expr2, body);
            Assert.IsInstanceOfType(body, typeof(LambdaExpression));
        }

        [TestMethod]
        public void Test002()
        {
            var xgr = new ExpressionGenerator();
            var xpr = new ExpressionReader();

            var param1 = Expression.Parameter(typeof(int));
            var expr = Expression.Call(
                typeof(Queryable),
                "Where",
                new [] { typeof(int) },
                Expression.Default(typeof(IQueryable<int>)),
                Expression.Constant(
                    Expression.Lambda<Func<int, bool>>(
                        Expression.GreaterThan(param1, Expression.Constant(10)),
                        param1
                    )
                )
            );
            var expr2 = expr.Arguments[1];
            var result = xpr.GetLambda(expr2);

            Assert.AreNotEqual(expr2, result);
            Assert.IsInstanceOfType(result, typeof(LambdaExpression));
        }


        [TestMethod]
        public void Test003()
        {
            var xgr = new ExpressionGenerator();
            var xpr = new ExpressionReader();

            var param1 = Expression.Parameter(typeof(int));
            var expr = Expression.Call(
                typeof(Queryable),
                "Where",
                new[] { typeof(int) },
                Expression.Default(typeof(IQueryable<int>)),
                Expression.Constant(
                    Expression.Lambda<Func<int, bool>>(
                        Expression.GreaterThan(param1, Expression.Constant(10)),
                        param1
                    )
                )
            );
            var result = xpr.GetLambda(expr);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test004()
        {
            var xgr = new ExpressionGenerator();
            var xpr = new ExpressionReader();

            var expr = xgr.FromFunc(() => default(IQueryable<int>).Where(x => x > 10));

            var result = xpr.GetLambda(expr);

            Assert.AreEqual(expr, result);
            Assert.IsInstanceOfType(result, typeof(LambdaExpression));
        }



        [TestMethod]
        public void Test005()
        {
            var xpr = new ExpressionReader();
            var xcr = new ExpressionComparer();

            var expr = Expression.Convert(Expression.Convert(Expression.Default(typeof(byte)), typeof(short)), typeof(int));

            var result = xpr.StripConvert(expr);

            Assert.AreNotEqual(expr, result);
            Assert.IsInstanceOfType(result, typeof(DefaultExpression));
            Assert.IsTrue(xcr.AreEqual(Expression.Default(typeof(byte)), result));
        }

        [TestMethod]
        public void Test006()
        {
            var xpr = new ExpressionReader();
            var xcr = new ExpressionComparer();

            var expr = Expression.ConvertChecked(Expression.ConvertChecked(Expression.Default(typeof(byte)), typeof(short)), typeof(int));

            var result = xpr.StripConvert(expr);

            Assert.AreNotEqual(expr, result);
            Assert.IsInstanceOfType(result, typeof(DefaultExpression));
            Assert.IsTrue(xcr.AreEqual(Expression.Default(typeof(byte)), result));
        }

        [TestMethod]
        public void Test007()
        {
            var xpr = new ExpressionReader();
            var xcr = new ExpressionComparer();

            var expr = Expression.Convert(Expression.ConvertChecked(Expression.Default(typeof(byte)), typeof(short)), typeof(int));

            var result = xpr.StripConvert(expr);

            Assert.AreNotEqual(expr, result);
            Assert.IsInstanceOfType(result, typeof(DefaultExpression));
            Assert.IsTrue(xcr.AreEqual(Expression.Default(typeof(byte)), result));
        }

        [TestMethod]
        public void Test008()
        {
            var xpr = new ExpressionReader();
            var xcr = new ExpressionComparer();

            var expr = Expression.ConvertChecked(Expression.Convert(Expression.Default(typeof(byte)), typeof(short)), typeof(int));

            var result = xpr.StripConvert(expr);

            Assert.AreNotEqual(expr, result);
            Assert.IsInstanceOfType(result, typeof(DefaultExpression));
            Assert.IsTrue(xcr.AreEqual(Expression.Default(typeof(byte)), result));
        }

        [TestMethod]
        public void Test009()
        {
            var xpr = new ExpressionReader();
            var xcr = new ExpressionComparer();

            var expr = Expression.Default(typeof(byte));

            var result = xpr.StripConvert(expr);

            Assert.AreEqual(expr, result);
            Assert.IsInstanceOfType(result, typeof(DefaultExpression));
            Assert.IsTrue(xcr.AreEqual(Expression.Default(typeof(byte)), result));
        }

        [TestMethod]
        public void Test010()
        {
            var xpr = new ExpressionReader();
            var xcr = new ExpressionComparer();

            var expr = Expression.UnaryPlus(Expression.Default(typeof(int)));

            var result = xpr.StripConvert(expr);

            Assert.AreEqual(expr, result);
            Assert.IsInstanceOfType(result, typeof(UnaryExpression));
            Assert.IsTrue(xcr.AreEqual(Expression.UnaryPlus(Expression.Default(typeof(int))), result));
        }

        [TestMethod]
        public void Test011()
        {
            var xpr = new ExpressionReader();

            var expr = Expression.UnaryPlus(Expression.Default(typeof(int)));

            var result = xpr.GetTrueUnderlyingType(expr);

            Assert.AreEqual(result, typeof(int));
        }

        [TestMethod]
        public void Test012()
        {
            var xpr = new ExpressionReader();

            var expr = Expression.Convert(Expression.Default(typeof(int)), typeof(decimal));

            var result = xpr.GetTrueUnderlyingType(expr);

            Assert.AreEqual(result, typeof(int));
        }

        [TestMethod]
        public void Test013()
        {
            var xpr = new ExpressionReader();
            var xcr = new ExpressionComparer();

            var expr = Expression.Convert(
                Expression.Convert(
                    Expression.Default(typeof(int)), 
                    typeof(decimal)),
                typeof(long)
            );

            var result = xpr.GetTrueUnderlyingType(expr);

            Assert.AreEqual(result, typeof(int));
        }
    }
}
