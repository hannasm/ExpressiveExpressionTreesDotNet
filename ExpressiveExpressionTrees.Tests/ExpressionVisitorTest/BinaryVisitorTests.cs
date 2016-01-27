using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class BinaryVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e2= Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Add(e2, e3);

            var replace = new Dictionary<Expression,Expression> {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1=>o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1=>o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1=>o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1=>o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1=>o1.Left == e1.Left);
            assert.ProductionHas(e1, o1=>o1.Right == e1.Right);
            assert.ProductionHas(e1, o1=>o1.Method == e1.Method);
            assert.ProductionHas(e1, o1=>o1.Type == e1.Type);
            assert.ProductionHas(e1, o1=>o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test002()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test003()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Subtract(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test004()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test005()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Multiply(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test006()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test007()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Divide(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test008()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Modulo(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test009()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LessThan(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test010()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LessThanOrEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test011()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.GreaterThan(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test012()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.GreaterThanOrEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test013()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Equal(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test014()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.NotEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test015()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.ReferenceEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test016()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.ReferenceNotEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test017()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.Coalesce(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test018()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.RightShift(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test019()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LeftShift(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test020()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ExclusiveOr(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test021()
        {
            var e2 = Expression.Default(typeof(double));
            var e3 = Expression.Default(typeof(double));
            var e1 = Expression.Power(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test031()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test032()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test033()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test034()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test035()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test036()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test037()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.DivideAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test038()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ModuloAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test048()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.RightShiftAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test049()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LeftShiftAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test050()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ExclusiveOrAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test051()
        {
            var e2 = Expression.Parameter(typeof(double));
            var e3 = Expression.Default(typeof(double));
            var e1 = Expression.PowerAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e1.Left);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }


        [TestMethod]
        public void Test101()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Add(e2, e3);

            var replace = new Dictionary<Expression, Expression> {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test102()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test103()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Subtract(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test104()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test105()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Multiply(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test106()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test107()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Divide(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test108()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Modulo(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test109()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LessThan(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test110()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LessThanOrEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test111()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.GreaterThan(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test112()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.GreaterThanOrEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test113()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Equal(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test114()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.NotEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test115()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.ReferenceEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(object)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test116()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.ReferenceNotEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(object)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test117()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.Coalesce(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(object)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test118()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.RightShift(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test119()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LeftShift(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test120()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ExclusiveOr(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test121()
        {
            var e2 = Expression.Default(typeof(double));
            var e3 = Expression.Default(typeof(double));
            var e1 = Expression.Power(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(double)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test131()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test132()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test133()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test134()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test135()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test136()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test137()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.DivideAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test138()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ModuloAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test148()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.RightShiftAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test149()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LeftShiftAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test150()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ExclusiveOrAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test151()
        {
            var e2 = Expression.Parameter(typeof(double));
            var e3 = Expression.Default(typeof(double));
            var e1 = Expression.PowerAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(double)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e1.Right);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test201()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Add(e2, e3);

            var replace = new Dictionary<Expression, Expression> {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test202()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test203()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Subtract(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test204()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test205()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Multiply(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test206()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test207()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Divide(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test208()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Modulo(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test209()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LessThan(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test210()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LessThanOrEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test211()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.GreaterThan(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test212()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.GreaterThanOrEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test213()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Equal(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test214()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.NotEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test215()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.ReferenceEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(object)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test216()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.ReferenceNotEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(object)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test217()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.Coalesce(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test218()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.RightShift(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test219()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LeftShift(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test220()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ExclusiveOr(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test221()
        {
            var e2 = Expression.Default(typeof(double));
            var e3 = Expression.Default(typeof(double));
            var e1 = Expression.Power(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(double)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test231()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test232()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test233()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test234()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test235()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test236()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test237()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.DivideAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test238()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ModuloAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test248()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.RightShiftAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test249()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LeftShiftAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test250()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ExclusiveOrAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test251()
        {
            var e2 = Expression.Parameter(typeof(double));
            var e3 = Expression.Default(typeof(double));
            var e1 = Expression.PowerAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e3, Expression.Parameter(typeof(double)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test301()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Add(e2, e3);

            var replace = new Dictionary<Expression, Expression> {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test302()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test303()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Subtract(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test304()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test305()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Multiply(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test306()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test307()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Divide(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test308()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Modulo(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test309()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LessThan(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test310()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LessThanOrEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test311()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.GreaterThan(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test312()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.GreaterThanOrEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test313()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.Equal(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test314()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.NotEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test315()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.ReferenceEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test316()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.ReferenceNotEqual(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test317()
        {
            var e2 = Expression.Default(typeof(object));
            var e3 = Expression.Default(typeof(object));
            var e1 = Expression.Coalesce(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(object)) },
                { e3, Expression.Parameter(typeof(object)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test318()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.RightShift(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test319()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LeftShift(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test320()
        {
            var e2 = Expression.Default(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ExclusiveOr(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test321()
        {
            var e2 = Expression.Default(typeof(double));
            var e3 = Expression.Default(typeof(double));
            var e1 = Expression.Power(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(double)) },
                { e3, Expression.Parameter(typeof(double)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test331()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test332()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.AddAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test333()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test334()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.SubtractAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test335()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test336()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.MultiplyAssignChecked(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test337()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.DivideAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test338()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ModuloAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test348()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.RightShiftAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test349()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.LeftShiftAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }
        [TestMethod]
        public void Test350()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e3 = Expression.Default(typeof(int));
            var e1 = Expression.ExclusiveOrAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) },
                { e3, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test351()
        {
            var e2 = Expression.Parameter(typeof(double));
            var e3 = Expression.Default(typeof(double));
            var e1 = Expression.PowerAssign(e2, e3);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(double)) },
                { e3, Expression.Parameter(typeof(double)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e1.Conversion);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test400()
        {
            var xgr = new ExpressionGenerator();
            var e2 = Expression.Default(typeof(int?));
            var e3 = Expression.Default(typeof(int));
            var pc = Expression.Parameter(typeof(int));
            var e4 = Expression.Lambda(pc, pc);
            var e1 = Expression.Coalesce(e2, e3, e4);

            Assert.IsNotNull(e1.Conversion, "If conversion is null it defeats the point of this test");

            var replace = new Dictionary<Expression, Expression>
            {
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e4);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == e3);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.ProductionHas(e4, o4 => o4.Body == pc);
            assert.WasProduced(e4);
            assert.WasVisited(pc);
            assert.WasProduced(pc);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test401()
        {
            var e2 = Expression.Default(typeof(int?));
            var e3 = Expression.Default(typeof(int));
            var pc = Expression.Parameter(typeof(int));
            var e4 = Expression.Lambda(pc, pc);
            var e1 = Expression.Coalesce(e2, e3, e4);

            Assert.IsNotNull(e1.Conversion, "If conversion is null it defeats the point of this test");

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(3, typeof(int?)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e4);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e3);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.ProductionHas(e4, o4 => o4.Body == pc);
            assert.WasProduced(e4);
            assert.WasVisited(pc);
            assert.WasProduced(pc);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test402()
        {
            var e2 = Expression.Default(typeof(int?));
            var e3 = Expression.Default(typeof(int));
            var pc = Expression.Parameter(typeof(int));
            var e4 = Expression.Lambda(pc, pc);
            var e1 = Expression.Coalesce(e2, e3, e4);

            Assert.IsNotNull(e1.Conversion, "If conversion is null it defeats the point of this test");

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(5) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e4);
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.ProductionHas(e4, o4 => o4.Body == pc);
            assert.WasProduced(e4);
            assert.WasVisited(pc);
            assert.WasProduced(pc);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test403()
        {
            var e2 = Expression.Default(typeof(int?));
            var e3 = Expression.Default(typeof(int));
            var pc = Expression.Parameter(typeof(int));
            var e4 = Expression.Lambda(pc, pc);
            var e1 = Expression.Coalesce(e2, e3, e4);

            Assert.IsNotNull(e1.Conversion, "If conversion is null it defeats the point of this test");

            var replace = new Dictionary<Expression, Expression>
            {
                {pc, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == assert.ProductionOf(e4));
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == e3);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.ProductionHas(e4, o4=>o4.Body == replace[pc]);
            assert.WasNotProduced(e4);
            assert.WasVisited(pc);
            assert.WasNotProduced(pc);
            assert.WasProduced(replace[pc]);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test404()
        {
            var e2 = Expression.Default(typeof(int?));
            var e3 = Expression.Default(typeof(int));
            var pc = Expression.Parameter(typeof(int));
            var e4 = Expression.Lambda(pc, pc);
            var e1 = Expression.Coalesce(e2, e3, e4);

            Assert.IsNotNull(e1.Conversion, "If conversion is null it defeats the point of this test");

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(3, typeof(int?)) },
                {e3, Expression.Constant(5) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == e4);
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.ProductionHas(e4, o4 => o4.Body == pc);
            assert.WasProduced(e4);
            assert.WasVisited(pc);
            assert.WasProduced(pc);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test405()
        {
            var e2 = Expression.Default(typeof(int?));
            var e3 = Expression.Default(typeof(int));
            var pc = Expression.Parameter(typeof(int));
            var e4 = Expression.Lambda(pc, pc);
            var e1 = Expression.Coalesce(e2, e3, e4);

            Assert.IsNotNull(e1.Conversion, "If conversion is null it defeats the point of this test");

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(2, typeof(int?)) },
                {pc, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == assert.ProductionOf(e4));
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == e3);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.ProductionHas(e4, o4 => o4.Body == replace[pc]);
            assert.WasNotProduced(e4);
            assert.WasVisited(pc);
            assert.WasNotProduced(pc);
            assert.WasProduced(replace[pc]);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test406()
        {
            var e2 = Expression.Default(typeof(int?));
            var e3 = Expression.Default(typeof(int));
            var pc = Expression.Parameter(typeof(int));
            var e4 = Expression.Lambda(pc, pc);
            var e1 = Expression.Coalesce(e2, e3, e4);

            Assert.IsNotNull(e1.Conversion, "If conversion is null it defeats the point of this test");

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(5) },
                {pc, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == assert.ProductionOf(e4));
            assert.ProductionHas(e1, o1 => o1.Left == e2);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.ProductionHas(e4, o4 => o4.Body == replace[pc]);
            assert.WasNotProduced(e4);
            assert.WasVisited(pc);
            assert.WasNotProduced(pc);
            assert.WasProduced(replace[pc]);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test407()
        {
            var e2 = Expression.Default(typeof(int?));
            var e3 = Expression.Default(typeof(int));
            var pc = Expression.Parameter(typeof(int));
            var e4 = Expression.Lambda(pc, pc);
            var e1 = Expression.Coalesce(e2, e3, e4);

            Assert.IsNotNull(e1.Conversion, "If conversion is null it defeats the point of this test");

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Constant(2, typeof(int?)) },
                {e3, Expression.Constant(5) },
                {pc, Expression.Parameter(typeof(int)) },
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.Conversion == assert.ProductionOf(e4));
            assert.ProductionHas(e1, o1 => o1.Left == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Right == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.ProductionHas(e4, o4 => o4.Body == replace[pc]);
            assert.WasNotProduced(e4);
            assert.WasVisited(pc);
            assert.WasNotProduced(pc);
            assert.WasProduced(replace[pc]);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }
    }
}
