using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    [TestClass]
    public class UnaryVisitorTests
    {
        [TestMethod]
        public void Test001()
        {
            var e2 = Expression.Default(typeof(short));
            var e1 = Expression.Convert(e2, typeof(int));

            var replace = new Dictionary<Expression,Expression> {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1=>o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1=>o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1=>o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1=>o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1=>o1.Method == e1.Method);
            assert.ProductionHas(e1, o1=>o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
        [TestMethod]
        public void Test002()
        {
            var e2 = Expression.Default(typeof(short));
            var e1 = Expression.ConvertChecked(e2, typeof(int));

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test003()
        {
            var e2 = Expression.Default(typeof(short));
            var e1 = Expression.Negate(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test004()
        {
            var e2 = Expression.Default(typeof(short));
            var e1 = Expression.NegateChecked(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test005()
        {
            var e2 = Expression.Default(typeof(bool));
            var e1 = Expression.Not(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test006()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.UnaryPlus(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test007()
        {
            var e2 = Expression.Default(typeof(object));
            var e1 = Expression.TypeAs(e2, typeof(string));

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test008()
        {
            var e3 = Expression.Default(typeof(long));
            var e2 = Expression.Lambda(e3);
            var e1 = Expression.Quote(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test009()
        {
            var e2 = Expression.Default(typeof(object[]));
            var e1 = Expression.ArrayLength(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }


        [TestMethod]
        public void Test011()
        {
            var e2 = Expression.Default(typeof(short));
            var e1 = Expression.Convert(e2, typeof(int));

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(short)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
        [TestMethod]
        public void Test012()
        {
            var e2 = Expression.Default(typeof(short));
            var e1 = Expression.ConvertChecked(e2, typeof(int));

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Default(typeof(short)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test013()
        {
            var e2 = Expression.Default(typeof(short));
            var e1 = Expression.Negate(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(short)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test014()
        {
            var e2 = Expression.Default(typeof(short));
            var e1 = Expression.NegateChecked(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(short)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test015()
        {
            var e2 = Expression.Default(typeof(bool));
            var e1 = Expression.Not(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(bool)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test016()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.UnaryPlus(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(int)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test017()
        {
            var e2 = Expression.Default(typeof(object));
            var e1 = Expression.TypeAs(e2, typeof(string));

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.Default(typeof(object)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
        
        [TestMethod]
        public void Test018()
        {
            var e3 = Expression.Default(typeof(long));
            var e2 = Expression.Lambda(e3);
            var e1 = Expression.Quote(e2);
            
            var replace = new Dictionary<Expression, Expression>
            {
                {  e3, Expression.Default(typeof(long)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand is LambdaExpression);
            assert.ProductionHas(e1, o1 => ((LambdaExpression)o1.Operand).Body == replace[e3]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.ProductionHas(e2, o2 => o2.Body == replace[e3]);
            assert.WasVisited(e3);
            assert.WasNotProduced(e3);
            assert.WasProduced(replace[e3]);
            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test019()
        {
            var e2 = Expression.Default(typeof(object[]));
            var e1 = Expression.ArrayLength(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Default(typeof(object[])) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test020()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.Increment(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test021()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.Decrement(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test022()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.Increment(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Constant(1, typeof(int)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test023()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.Decrement(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Constant(1, typeof(int)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test024()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.OnesComplement(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test025()
        {
            var e2 = Expression.Default(typeof(int));
            var e1 = Expression.OnesComplement(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Constant(1, typeof(int)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test026()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e1 = Expression.PreIncrementAssign(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test027()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e1 = Expression.PreIncrementAssign(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test028()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e1 = Expression.PostIncrementAssign(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test029()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e1 = Expression.PostIncrementAssign(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test030()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e1 = Expression.PreDecrementAssign(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test031()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e1 = Expression.PreDecrementAssign(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test032()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e1 = Expression.PostDecrementAssign(e2);

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test033()
        {
            var e2 = Expression.Parameter(typeof(int));
            var e1 = Expression.PostDecrementAssign(e2);

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(int)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test034()
        {
            var e2 = Expression.Parameter(typeof(object));
            var e1 = Expression.Unbox(e2, typeof(int));

            var replace = new Dictionary<Expression, Expression>
            {

            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == e1.Operand);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }

        [TestMethod]
        public void Test035()
        {
            var e2 = Expression.Parameter(typeof(object));
            var e1 = Expression.Unbox(e2, typeof(int));

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.Parameter(typeof(object)) }
            };

            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.IsLifted == e1.IsLifted);
            assert.ProductionHas(e1, o1 => o1.IsLiftedToNull == e1.IsLiftedToNull);
            assert.ProductionHas(e1, o1 => o1.CanReduce == e1.CanReduce);
            assert.ProductionHas(e1, o1 => o1.Operand == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Method == e1.Method);
            assert.ProductionHas(e1, o1 => o1.Type == e1.Type);
            assert.ProductionHas(e1, o1 => o1.NodeType == e1.NodeType);
            assert.WasVisited(e2);
            assert.WasNotProduced(e2);
            assert.WasProduced(replace[e2]);
            assert.TotalVisits(2);
            assert.TotalProduced(2);
        }
    }
}
