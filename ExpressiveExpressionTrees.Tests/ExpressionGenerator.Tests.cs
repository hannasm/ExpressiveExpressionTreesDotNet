using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveExpressionTrees.Tests
{
    [TestClass]
    public class ExpressionGeneratorTests
    {
        [TestMethod]
        [Description("Just making sure that these two methods (WithType / WithoutType) work correctly and round-trip properly, in some very basic scenario. A more comprehensive test suite seems like pointless waste of time when the current implementations are so simple.")]
        public void Test001()
        {
            var xgr = new ExpressionGenerator();
            var expr = Expression.Default(typeof(string));
            var expr2 = xgr.WithType<string>(expr);
            var expr3 = xgr.WithoutType(expr2);

            var xcr = new ExpressionComparer();
            Assert.IsTrue(xcr.AreEqual(expr, expr3));
        }

        [TestMethod]
        public void Test002()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.FromFunc(()=>default(long));
            var e2 = xgr.FromFunc(()=>default(long));

            var result = xgr.ConvertExpressions(e1, e2);

            Assert.AreEqual(e1.Body, result.Left);
            Assert.AreEqual(e2.Body, result.Right);
        }

        [TestMethod]
        public void Test003()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.FromFunc(() => default(long));
            var e2 = xgr.FromFunc(() => default(long?));

            var result = xgr.ConvertExpressions(e1, e2);

            Assert.AreNotEqual(e1.Body, result.Left);
            Assert.AreEqual(e2.Body, result.Right);
            Assert.AreEqual(typeof(long?), result.Left.Type);
        }

        [TestMethod]
        public void Test004()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.FromFunc(() => default(long?));
            var e2 = xgr.FromFunc(() => default(long));

            var result = xgr.ConvertExpressions(e1, e2);

            Assert.AreEqual(e1.Body, result.Left);
            Assert.AreNotEqual(e2.Body, result.Right);
            Assert.AreEqual(typeof(long?), result.Right.Type);
        }

        [TestMethod]
        public void Test005()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.FromFunc(() => default(long?));
            var e2 = xgr.FromFunc(() => default(long?));

            var result = xgr.ConvertExpressions(e1, e2);

            Assert.AreEqual(e1.Body, result.Left);
            Assert.AreEqual(e2.Body, result.Right);
        }


        [TestMethod]
        public void Test006()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.FromFunc(() => default(int));
            var e2 = xgr.FromFunc(() => default(string));

            var result = xgr.ConvertExpressions(e1, e2);

            Assert.AreEqual(e1.Body, result.Left);
            Assert.AreEqual(e2.Body, result.Right);
        }


        [TestMethod]
        public void Test007()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.FromFunc(() => default(int));
            var e2 = xgr.FromFunc(() => default(long));

            var result = xgr.ConvertExpressions(e1, e2);

            Assert.AreEqual(e1.Body, result.Left);
            Assert.AreEqual(e2.Body, result.Right);
        }




        [TestMethod]
        public void Test008()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.FromFunc(() => default(float));
            var e2 = xgr.FromFunc(() => default(double));

            var result = xgr.ConvertExpressions(e1, e2);

            Assert.AreEqual(e1.Body, result.Left);
            Assert.AreEqual(e2.Body, result.Right);
        }


        [TestMethod]
        public void Test009()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.FromFunc(() => default(double));
            var e2 = xgr.FromFunc(() => default(decimal));

            var result = xgr.ConvertExpressions(e1, e2);

            Assert.AreEqual(e1.Body, result.Left);
            Assert.AreEqual(e2.Body, result.Right);
        }


        [TestMethod]
        public void Test010()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.FromFunc(() => default(short));
            var e2 = xgr.FromFunc(() => default(int));

            var result = xgr.ConvertExpressions(e1, e2);

            Assert.AreEqual(e1.Body, result.Left);
            Assert.AreEqual(e2.Body, result.Right);
        }



        [TestMethod]
        public void Test011()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.FromFunc(() => default(string));
            var e2 = xgr.FromFunc(() => default(string));

            var result = xgr.ConvertExpressions(e1, e2);

            Assert.AreEqual(e1.Body, result.Left);
            Assert.AreEqual(e2.Body, result.Right);
        }

        [TestMethod]
        public void Test012()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(e2, e3));

            var result = xgr.Split(e1, ExpressionType.And);

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
        }

        [TestMethod]
        public void Test013()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(e2, Expression.And(e3, e4)));

            var result = xgr.Split(e1, ExpressionType.And);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
        }

        [TestMethod]
        public void Test014()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(Expression.And(e2, e3), e4));

            var result = xgr.Split(e1, ExpressionType.And);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
        }

        [TestMethod]
        public void Test015()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(Expression.And(e2, e3), Expression.And(e4, e5)));

            var result = xgr.Split(e1, ExpressionType.And);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }
        [TestMethod]
        public void Test016()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(Expression.And(e2, Expression.And(e3, e4)), e5));

            var result = xgr.Split(e1, ExpressionType.And);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test017()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(Expression.And(Expression.And(e2, e3), e4), e5));

            var result = xgr.Split(e1, ExpressionType.And);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test018()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(e2, Expression.And(e3, Expression.And(e4, e5))));

            var result = xgr.Split(e1, ExpressionType.And);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test019()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(e2, Expression.And(Expression.And(e3, e4), e5)));

            var result = xgr.Split(e1, ExpressionType.And);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test022()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(e2, e3));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
        }

        [TestMethod]
        public void Test023()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(e2, Expression.Or(e3, e4)));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
        }

        [TestMethod]
        public void Test024()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(Expression.Or(e2, e3), e4));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
        }

        [TestMethod]
        public void Test025()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(Expression.Or(e2, e3), Expression.And(e4, e5)));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }
        [TestMethod]
        public void Test026()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(Expression.Or(e2, Expression.And(e3, e4)), e5));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test027()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(Expression.Or(Expression.And(e2, e3), e4), e5));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test028()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(e2, Expression.Or(e3, Expression.And(e4, e5))));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test029()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.And(e2, Expression.Or(Expression.And(e3, e4), e5)));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test032()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.Or(e2, e3));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
        }

        [TestMethod]
        public void Test033()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.Or(e2, Expression.And(e3, e4)));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
        }

        [TestMethod]
        public void Test034()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.Or(Expression.And(e2, e3), e4));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
        }

        [TestMethod]
        public void Test035()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.Or(Expression.And(e2, e3), Expression.Or(e4, e5)));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }
        [TestMethod]
        public void Test036()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.Or(Expression.And(e2, Expression.Or(e3, e4)), e5));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test037()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.Or(Expression.And(Expression.Or(e2, e3), e4), e5));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test038()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.Or(e2, Expression.And(e3, Expression.Or(e4, e5))));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test039()
        {
            var xgr = new ExpressionGenerator();

            var e2 = Expression.Default(typeof(bool));
            var e3 = Expression.Default(typeof(bool));
            var e4 = Expression.Default(typeof(bool));
            var e5 = Expression.Default(typeof(bool));
            var e1 = xgr.WithType<bool>(Expression.Or(e2, Expression.And(Expression.Or(e3, e4), e5)));

            var result = xgr.Split(e1, ExpressionType.And, ExpressionType.Or);

            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(e2, result[0]);
            Assert.AreEqual(e3, result[1]);
            Assert.AreEqual(e4, result[2]);
            Assert.AreEqual(e5, result[3]);
        }

        [TestMethod]
        public void Test040()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression, BinaryExpression> conv = x => (BinaryExpression)x;

            var el = new Expression[] {
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int))
            };

            var result = xgr.Join(el, ExpressionType.Add);
            Assert.IsInstanceOfType(result, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, result.NodeType);
            Assert.AreEqual(el[0], conv(result).Left);
            Assert.AreEqual(el[1], conv(result).Right);
        }

        [TestMethod]
        public void Test041()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression,BinaryExpression> conv = x=>(BinaryExpression)x;

            var el = new Expression[] {
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
            };

            var result = xgr.Join(el, ExpressionType.Add);
            Assert.IsInstanceOfType(result, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, result.NodeType);
            Assert.IsInstanceOfType(conv(result).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(result).Left.NodeType);
            Assert.AreEqual(el[0], conv(conv(result).Left).Left);
            Assert.AreEqual(el[1], conv(conv(result).Left).Right);
            Assert.AreEqual(el[2], conv(result).Right);
        }

        [TestMethod]
        public void Test042()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression, BinaryExpression> conv = x => (BinaryExpression)x;

            var el = new Expression[] {
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
            };

            var result = xgr.Join(el, ExpressionType.Add);
            Assert.IsInstanceOfType(result, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, result.NodeType);
            Assert.IsInstanceOfType(conv(result).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(result).Left.NodeType);
            Assert.AreEqual(el[0], conv(conv(result).Left).Left);
            Assert.AreEqual(el[1], conv(conv(result).Left).Right);
            Assert.IsInstanceOfType(conv(result).Right, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(result).Right.NodeType);
            Assert.AreEqual(el[2], conv(conv(result).Right).Left);
            Assert.AreEqual(el[3], conv(conv(result).Right).Right);
        }

        [TestMethod]
        public void Test043()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression, BinaryExpression> conv = x => (BinaryExpression)x;

            var el = new Expression[] {
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
            };

            var result = xgr.Join(el, ExpressionType.Add);
            Assert.IsInstanceOfType(result, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, result.NodeType);

            Assert.IsInstanceOfType(conv(result).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(result).Left.NodeType);

            Assert.IsInstanceOfType(conv(conv(result).Left).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(conv(result).Left).Left.NodeType);

            Assert.AreEqual(el[0], conv(conv(conv(result).Left).Left).Left);
            Assert.AreEqual(el[1], conv(conv(conv(result).Left).Left).Right);

            Assert.IsInstanceOfType(conv(conv(result).Left).Right, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(conv(result).Left).Right.NodeType);

            Assert.AreEqual(el[2], conv(conv(conv(result).Left).Right).Left);
            Assert.AreEqual(el[3], conv(conv(conv(result).Left).Right).Right);

            Assert.AreEqual(el[4], conv(result).Right);
        }

        [TestMethod]
        public void Test044()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression, BinaryExpression> conv = x => (BinaryExpression)x;

            var el = new Expression[] {
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
            };

            var result = xgr.Join(el, ExpressionType.Add);
            Assert.IsInstanceOfType(result, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, result.NodeType);

            Assert.IsInstanceOfType(conv(result).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(result).Left.NodeType);

            Assert.IsInstanceOfType(conv(conv(result).Left).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(conv(result).Left).Left.NodeType);

            Assert.AreEqual(el[0], conv(conv(conv(result).Left).Left).Left);
            Assert.AreEqual(el[1], conv(conv(conv(result).Left).Left).Right);

            Assert.IsInstanceOfType(conv(conv(result).Left).Right, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(conv(result).Left).Right.NodeType);

            Assert.AreEqual(el[2], conv(conv(conv(result).Left).Right).Left);
            Assert.AreEqual(el[3], conv(conv(conv(result).Left).Right).Right);

            Assert.IsInstanceOfType(conv(result).Right, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(result).Right.NodeType);

            Assert.AreEqual(el[4], conv(conv(result).Right).Left);
            Assert.AreEqual(el[5], conv(conv(result).Right).Right);
        }

        [TestMethod]
        public void Test045()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression, BinaryExpression> conv = x => (BinaryExpression)x;

            var el = new Expression[] {
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
            };

            var result = xgr.Join(el, ExpressionType.Add);
            Assert.IsInstanceOfType(result, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, result.NodeType);

            Assert.IsInstanceOfType(conv(result).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(result).Left.NodeType);

            Assert.IsInstanceOfType(conv(conv(result).Left).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(conv(result).Left).Left.NodeType);

            Assert.AreEqual(el[0], conv(conv(conv(result).Left).Left).Left);
            Assert.AreEqual(el[1], conv(conv(conv(result).Left).Left).Right);

            Assert.IsInstanceOfType(conv(conv(result).Left).Right, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(conv(result).Left).Right.NodeType);

            Assert.AreEqual(el[2], conv(conv(conv(result).Left).Right).Left);
            Assert.AreEqual(el[3], conv(conv(conv(result).Left).Right).Right);

            Assert.IsInstanceOfType(conv(result).Right, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(result).Right.NodeType);

            Assert.IsInstanceOfType(conv(conv(result).Right).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(conv(result).Right).Left.NodeType);

            Assert.AreEqual(el[4], conv(conv(conv(result).Right).Left).Left);
            Assert.AreEqual(el[5], conv(conv(conv(result).Right).Left).Right);

            Assert.AreEqual(el[6], conv(conv(result).Right).Right);
        }


        [TestMethod]
        public void Test046()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression, BinaryExpression> conv = x => (BinaryExpression)x;

            var el = new Expression[] {
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int)),
            };

            var result = xgr.Join(el, ExpressionType.Add);
            Assert.IsInstanceOfType(result, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, result.NodeType);

            Assert.IsInstanceOfType(conv(result).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(result).Left.NodeType);

            Assert.IsInstanceOfType(conv(conv(result).Left).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(conv(result).Left).Left.NodeType);

            Assert.AreEqual(el[0], conv(conv(conv(result).Left).Left).Left);
            Assert.AreEqual(el[1], conv(conv(conv(result).Left).Left).Right);

            Assert.IsInstanceOfType(conv(conv(result).Left).Right, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(conv(result).Left).Right.NodeType);

            Assert.AreEqual(el[2], conv(conv(conv(result).Left).Right).Left);
            Assert.AreEqual(el[3], conv(conv(conv(result).Left).Right).Right);

            Assert.IsInstanceOfType(conv(result).Right, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(result).Right.NodeType);

            Assert.IsInstanceOfType(conv(conv(result).Right).Left, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(conv(result).Right).Left.NodeType);

            Assert.AreEqual(el[4], conv(conv(conv(result).Right).Left).Left);
            Assert.AreEqual(el[5], conv(conv(conv(result).Right).Left).Right);

            Assert.IsInstanceOfType(conv(conv(result).Right).Right, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, conv(conv(result).Right).Right.NodeType);

            Assert.AreEqual(el[6], conv(conv(conv(result).Right).Right).Left);
            Assert.AreEqual(el[7], conv(conv(conv(result).Right).Right).Right);
        }

        [TestMethod]
        public void Test047()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression, BinaryExpression> conv = x => (BinaryExpression)x;

            var el = new Expression[] {};

            var result = xgr.Join(el, ExpressionType.Add);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test048()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression, BinaryExpression> conv = x => (BinaryExpression)x;

            var result = xgr.Join(null, ExpressionType.Add);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test049()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression, BinaryExpression> conv = x => (BinaryExpression)x;

            var el = new Expression[] {
                Expression.Default(typeof(int))
            };

            var result = xgr.Join(el, ExpressionType.Add);

            Assert.AreEqual(el[0], result);
        }

        [TestMethod]
        public void Test050()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression, BinaryExpression> conv = x => (BinaryExpression)x;

            var el = new Expression[] {
                Expression.Default(typeof(int)),
                Expression.Default(typeof(int))
            };

            var result = xgr.Join<int>(el, ExpressionType.Add);
            Assert.IsInstanceOfType(result.Body, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, result.Body.NodeType);
            Assert.AreEqual(el[0], conv(result.Body).Left);
            Assert.AreEqual(el[1], conv(result.Body).Right);
        }

        [TestMethod]
        public void Test051()
        {
            var xgr = new ExpressionGenerator();
            Func<Expression, BinaryExpression> conv = x => (BinaryExpression)x;

            var el = new Expression[] {
                Expression.Default(typeof(decimal)),
                Expression.Default(typeof(decimal))
            };

            var result = xgr.Join<decimal>(el, ExpressionType.Add);
            Assert.IsInstanceOfType(result.Body, typeof(BinaryExpression));
            Assert.AreEqual(ExpressionType.Add, result.Body.NodeType);
            Assert.AreEqual(el[0], conv(result.Body).Left);
            Assert.AreEqual(el[1], conv(result.Body).Right);
        }
        [TestMethod]
        public void Test060() {
            var xgr = new ExpressionGenerator();
            int val = 10;
            var p = xgr.Constant(val);

            Assert.IsInstanceOfType(p.Body, typeof(ConstantExpression));
            Assert.AreEqual(val, ((ConstantExpression)p.Body).Value);
        }
        [TestMethod]
        public void Test061() {
            var xgr = new ExpressionGenerator();
            var p = xgr.Parameter<string>();

            Assert.IsInstanceOfType(p.Body, typeof(ParameterExpression));
        }
        [TestMethod]
        public void Test062() {
            var xgr = new ExpressionGenerator();
            var p = xgr.Parameter(default(string));

            Assert.IsInstanceOfType(p.Body, typeof(ParameterExpression));
        }
    }
}
