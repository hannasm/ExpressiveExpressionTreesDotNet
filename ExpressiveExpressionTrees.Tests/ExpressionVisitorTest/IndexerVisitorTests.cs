using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class IndexerVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e2 = Expression.Default(typeof(string[]));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MakeIndex(e2, null, new[] { e3 });
            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test002()
        {
            var e2 = Expression.Default(typeof(int[]));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MakeIndex(e2, null, new[] { e3 });
            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test003()
        {
            var e2 = Expression.Default(typeof(Dictionary<string,int>));
            var e3 = Expression.Default(typeof(string));
            var prop = e2.Type.GetProperty("Item");
            var e1 = Expression.MakeIndex(e2, prop, new[] { e3 });
            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        public class CustomIndexerData001
        {
            public string this[int one]
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public string this[int one, int two]
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
            public string this[int one, int two, int three]
            {
                get {
                    throw new NotImplementedException();
                }
            }
        }

        [TestMethod]
        public void Test004()
        {
            var e2 = Expression.Default(typeof(CustomIndexerData001));
            var e3 = Expression.Default(typeof(int));
            var prop = e2.Type.GetProperty("Item", new Type[] { typeof(int) });
            var e1 = Expression.MakeIndex(e2, prop, new[] { e3 });
            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }
        [TestMethod]
        public void Test005()
        {
            var e2 = Expression.Default(typeof(CustomIndexerData001));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var prop = e2.Type.GetProperty("Item", new Type[] { typeof(int), typeof(int) });
            var e1 = Expression.MakeIndex(e2, prop, new[] { e3, e4 });
            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test006()
        {
            var e2 = Expression.Default(typeof(CustomIndexerData001));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e5 = Expression.Default(typeof(int));
            var prop = e2.Type.GetProperty("Item", new Type[] { typeof(int), typeof(int), typeof(int) });
            var e1 = Expression.MakeIndex(e2, prop, new[] { e3, e4, e5 });
            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test007()
        {
            var e2 = Expression.Default(typeof(CustomIndexerData001));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e5 = Expression.Default(typeof(int));
            var prop = e2.Type.GetProperty("Item", new Type[] { typeof(int), typeof(int), typeof(int) });
            var e1 = Expression.MakeIndex(e2, prop, new[] { e3, e4, e5 });
            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Default(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1=>o1.Arguments.Count == 3);
            assert.ProductionHas(e1, o1=>o1.Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1=>o1.Arguments[1] == e4);
            assert.ProductionHas(e1, o1=>o1.Arguments[2] == e5);
            assert.ProductionHas(e1, o1=>o1.Object == e2);
            assert.ProductionHas(e1, o1=>o1.Indexer == prop);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test008()
        {
            var e2 = Expression.Default(typeof(CustomIndexerData001));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e5 = Expression.Default(typeof(int));
            var prop = e2.Type.GetProperty("Item", new Type[] { typeof(int), typeof(int), typeof(int) });
            var e1 = Expression.MakeIndex(e2, prop, new[] { e3, e4, e5 });
            var replace = new Dictionary<Expression, Expression>
            {
                { e4, Expression.Default(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == 3);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e5);
            assert.ProductionHas(e1, o1 => o1.Object == e2);
            assert.ProductionHas(e1, o1 => o1.Indexer == prop);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasProduced(replace[e4]);
            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test009()
        {
            var e2 = Expression.Default(typeof(CustomIndexerData001));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e5 = Expression.Default(typeof(int));
            var prop = e2.Type.GetProperty("Item", new Type[] { typeof(int), typeof(int), typeof(int) });
            var e1 = Expression.MakeIndex(e2, prop, new[] { e3, e4, e5 });
            var replace = new Dictionary<Expression, Expression>
            {
                { e5, Expression.Default(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == 3);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e4);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Object == e2);
            assert.ProductionHas(e1, o1 => o1.Indexer == prop);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test010()
        {
            var e2 = Expression.Default(typeof(CustomIndexerData001));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e5 = Expression.Default(typeof(int));
            var prop = e2.Type.GetProperty("Item", new Type[] { typeof(int), typeof(int), typeof(int) });
            var e1 = Expression.MakeIndex(e2, prop, new[] { e3, e4, e5 });
            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Constant(null, typeof(CustomIndexerData001)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == 3);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e4);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e5);
            assert.ProductionHas(e1, o1 => o1.Object == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Indexer == prop);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }


        [TestMethod]
        public void Test011()
        {
            var e2 = Expression.Default(typeof(CustomIndexerData001));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e5 = Expression.Default(typeof(int));
            var prop = e2.Type.GetProperty("Item", new Type[] { typeof(int), typeof(int), typeof(int) });
            var e1 = Expression.MakeIndex(e2, prop, new[] { e3, e4, e5 });
            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Constant(null, typeof(CustomIndexerData001)) },
                { e3, Expression.Default(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == 3);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e4);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e5);
            assert.ProductionHas(e1, o1 => o1.Object == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Indexer == prop);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test012()
        {
            var e2 = Expression.Default(typeof(CustomIndexerData001));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e5 = Expression.Default(typeof(int));
            var prop = e2.Type.GetProperty("Item", new Type[] { typeof(int), typeof(int), typeof(int) });
            var e1 = Expression.MakeIndex(e2, prop, new[] { e3, e4, e5 });
            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Constant(null, typeof(CustomIndexerData001)) },
                { e4, Expression.Default(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == 3);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == replace[e4]);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == e5);
            assert.ProductionHas(e1, o1 => o1.Object == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Indexer == prop);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasNotProduced(e4);
            assert.WasProduced(replace[e4]);
            assert.WasVisited(e5);
            assert.WasProduced(e5);
            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test013()
        {
            var e2 = Expression.Default(typeof(CustomIndexerData001));
            var e3 = Expression.Default(typeof(int));
            var e4 = Expression.Default(typeof(int));
            var e5 = Expression.Default(typeof(int));
            var prop = e2.Type.GetProperty("Item", new Type[] { typeof(int), typeof(int), typeof(int) });
            var e1 = Expression.MakeIndex(e2, prop, new[] { e3, e4, e5 });
            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Constant(null, typeof(CustomIndexerData001)) },
                { e5, Expression.Default(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.Arguments.Count == 3);
            assert.ProductionHas(e1, o1 => o1.Arguments[0] == e3);
            assert.ProductionHas(e1, o1 => o1.Arguments[1] == e4);
            assert.ProductionHas(e1, o1 => o1.Arguments[2] == replace[e5]);
            assert.ProductionHas(e1, o1 => o1.Object == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Indexer == prop);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);
            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }
    }
}
