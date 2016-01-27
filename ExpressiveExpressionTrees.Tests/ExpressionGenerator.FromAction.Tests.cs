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
    public class ExpressionGeneratorFromActionTests
    {
        public static void paramFunc<T>(params T[] data)
        {
            // dont need to do anything
            Console.WriteLine("Param Func Invoked");
        }
        public static void interleaveFunc(params object[] data)
        {
            // dont need to do anything
            Console.WriteLine("interleave Func Invoked");
        }

        Expression<Func<int>>[] GetIntArgs(int count)
        {
            var result = new Expression<Func<int>>[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = Expression.Lambda<Func<int>>(
                    Expression.Default(typeof(int))
                );
            }
            return result;
        }
        Expression<Func<string>>[] GetStringArgs(int count)
        {
            if (count == 0) { return new Expression<Func<string>>[] { }; }
            var result = new Expression<Func<string>>[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = Expression.Lambda<Func<string>>(
                    Expression.Default(typeof(string))
                );
            }
            return result;
        }

        [TestMethod]
        public void Test001()
        {
            var xgr = new ExpressionGenerator();
            var actual = xgr.FromAction(() => Console.WriteLine("hello world"));

            var expected = Expression.Call(
                null,
                typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }),
                Expression.Constant("hello world")
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test002()
        {
            var xgr = new ExpressionGenerator();
            var actual = xgr.FromAction(() => paramFunc<int>());

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int))
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        
        [TestMethod]
        public void Test003()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(1);
            var actual = xgr.FromAction(args[0], a => paramFunc(a));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a=>a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test004()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(2);
            var actual = xgr.FromAction(args[0], args[1], (a,b) => paramFunc(a, b));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test005()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(3);
            var actual = xgr.FromAction(args[0], args[1], args[2], (a, b, c) => paramFunc(a, b, c));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test006()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(4);
            var actual = xgr.FromAction(args[0], args[1], args[2], args[3], (a, b, c, d) => paramFunc(a, b, c, d));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test007()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(5);
            var actual = xgr.FromAction(args[0], args[1], args[2], args[3], args[4], (a, b, c, d, e) => paramFunc(a, b, c, d, e));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test008()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(6);
            var actual = xgr.FromAction(args[0], args[1], args[2], args[3], args[4], args[5], 
                (a, b, c, d, e, f) => paramFunc(a, b, c, d, e, f));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test009()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(7);
            var actual = xgr.FromAction(args[0], args[1], args[2], args[3], args[4], args[5], args[6],
                (a, b, c, d, e, f, g) => paramFunc(a, b, c, d, e, f, g));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test010()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(8);
            var actual = xgr.FromAction(args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                (a, b, c, d, e, f, g, h) => paramFunc(a, b, c, d, e, f, g, h));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test011()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(9);
            var actual = xgr.FromAction(
                args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8],
                (a, b, c, d, e, f, g, h, i) => paramFunc(a, b, c, d, e, f, g, h, i));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test012()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(10);
            var actual = xgr.FromAction(
                args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9],
                (a, b, c, d, e, f, g, h, i, j) => paramFunc(a, b, c, d, e, f, g, h, i, j));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }


        [TestMethod]
        public void Test013()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(11);
            var actual = xgr.FromAction(
                args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10],
                (a, b, c, d, e, f, g, h, i, j, k) => paramFunc(a, b, c, d, e, f, g, h, i, j, k));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test014()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(12);
            var actual = xgr.FromAction(
                args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11],
                (a, b, c, d, e, f, g, h, i, j, k, l) => paramFunc(a, b, c, d, e, f, g, h, i, j, k, l));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test015()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(13);
            var actual = xgr.FromAction(
                args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11], args[12],
                (a, b, c, d, e, f, g, h, i, j, k, l, m) => paramFunc(a, b, c, d, e, f, g, h, i, j, k, l, m));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test016()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(14);
            var actual = xgr.FromAction(
                args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11], args[12], args[13],
                (a, b, c, d, e, f, g, h, i, j, k, l, m, n) => paramFunc(a, b, c, d, e, f, g, h, i, j, k, l, m, n));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test017()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(15);
            var actual = xgr.FromAction(
                args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11], args[12], args[13], args[14],
                (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o) => paramFunc(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test018()
        {
            var xgr = new ExpressionGenerator();
            var args = GetIntArgs(16);
            var actual = xgr.FromAction(
                args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11], args[12], args[13], args[14], args[15],
                (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => paramFunc(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p));

            var expected = Expression.Call(
                null,
                typeof(ExpressionGeneratorFromActionTests).GetMethod("paramFunc").MakeGenericMethod(typeof(int)),
                Expression.NewArrayInit(typeof(int), args.Select(a => a.Body).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }


        [TestMethod]
        public void Test019()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(1);
            var stringArgs = GetStringArgs(0);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0],
                a => interleaveFunc(a));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test020()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(1);
            var stringArgs = GetStringArgs(1);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0],
                (a, b) => interleaveFunc(a, b));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test021()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(2);
            var stringArgs = GetStringArgs(1);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1],
                (a, b, c) => interleaveFunc(a, b, c));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test022()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(2);
            var stringArgs = GetStringArgs(2);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1],
                (a, b, c, d) => interleaveFunc(a, b, c, d));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test023()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(3);
            var stringArgs = GetStringArgs(2);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2],
                (a, b, c, d, e) => interleaveFunc(a, b, c, d, e));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test024()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(3);
            var stringArgs = GetStringArgs(3);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2], stringArgs[2],
                (a, b, c, d, e, f) => interleaveFunc(a, b, c, d, e, f));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test025()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(4);
            var stringArgs = GetStringArgs(3);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2], stringArgs[2], intArgs[3],
                (a, b, c, d, e, f, g) => interleaveFunc(a, b, c, d, e, f, g));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test026()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(4);
            var stringArgs = GetStringArgs(4);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2], stringArgs[2], intArgs[3], stringArgs[3],
                (a, b, c, d, e, f, g, h) => interleaveFunc(a, b, c, d, e, f, g, h));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test027()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(5);
            var stringArgs = GetStringArgs(4);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2], stringArgs[2], intArgs[3], stringArgs[3],
                intArgs[4],
                (a, b, c, d, e, f, g, h, i) => interleaveFunc(a, b, c, d, e, f, g, h, i));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test028()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(5);
            var stringArgs = GetStringArgs(5);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2], stringArgs[2], intArgs[3], stringArgs[3],
                intArgs[4], stringArgs[4],
                (a, b, c, d, e, f, g, h, i, j) => interleaveFunc(a, b, c, d, e, f, g, h, i, j));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test029()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(6);
            var stringArgs = GetStringArgs(5);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2], stringArgs[2], intArgs[3], stringArgs[3],
                intArgs[4], stringArgs[4], intArgs[5],
                (a, b, c, d, e, f, g, h, i, j, k) => interleaveFunc(a, b, c, d, e, f, g, h, i, j, k));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test030()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(6);
            var stringArgs = GetStringArgs(6);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2], stringArgs[2], intArgs[3], stringArgs[3],
                intArgs[4], stringArgs[4], intArgs[5], stringArgs[5],
                (a, b, c, d, e, f, g, h, i, j, k, l) => interleaveFunc(a, b, c, d, e, f, g, h, i, j, k, l));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test031()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(7);
            var stringArgs = GetStringArgs(6);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2], stringArgs[2], intArgs[3], stringArgs[3],
                intArgs[4], stringArgs[4], intArgs[5], stringArgs[5], intArgs[6],
                (a, b, c, d, e, f, g, h, i, j, k, l, m) => interleaveFunc(a, b, c, d, e, f, g, h, i, j, k, l, m));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test032()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(7);
            var stringArgs = GetStringArgs(7);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2], stringArgs[2], intArgs[3], stringArgs[3],
                intArgs[4], stringArgs[4], intArgs[5], stringArgs[5], intArgs[6], stringArgs[6],
                (a, b, c, d, e, f, g, h, i, j, k, l, m, n) => interleaveFunc(a, b, c, d, e, f, g, h, i, j, k, l, m, n));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        [TestMethod]
        public void Test033()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(8);
            var stringArgs = GetStringArgs(7);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2], stringArgs[2], intArgs[3], stringArgs[3],
                intArgs[4], stringArgs[4], intArgs[5], stringArgs[5], intArgs[6], stringArgs[6], intArgs[7],
                (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o) => interleaveFunc(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
        
        [TestMethod]
        public void Test034()
        {
            var xgr = new ExpressionGenerator();
            var intArgs = GetIntArgs(8);
            var stringArgs = GetStringArgs(8);
            var args = intArgs.Zip(stringArgs, (a, b) => new { a = (Expression)a.Body, b = (Expression)b.Body }).SelectMany(a => new[] { a.a, a.b }).Concat(new[] { intArgs.Length != stringArgs.Length ? intArgs.Last().Body : null }).Where(a => a != null);

            var actual = xgr.FromAction(
                intArgs[0], stringArgs[0], intArgs[1], stringArgs[1], intArgs[2], stringArgs[2], intArgs[3], stringArgs[3],
                intArgs[4], stringArgs[4], intArgs[5], stringArgs[5], intArgs[6], stringArgs[6], intArgs[7], stringArgs[7],
                (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => interleaveFunc(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p));

            var expected = Expression.Call(
                    null,
                    typeof(ExpressionGeneratorFromActionTests).GetMethod("interleaveFunc"),
                    Expression.NewArrayInit(typeof(object), args.Select(a => a.Type == typeof(string) ? a : Expression.Convert(a, typeof(object))).ToArray())
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, actual));
        }
    }
}
