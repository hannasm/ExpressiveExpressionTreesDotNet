using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ExpressiveExpressionTrees.Tests.ExpressionVisitorTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionComparerTests
{
    [TestClass]
    public class MemberInitVisitorTests
    {
        class MemberInitData {
            public MemberInitData() { }

            public int FieldOne;
            public string FieldTwo;
            public bool FieldThree;
        }

        [TestMethod]
        public void Test001()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l1 = xgr.FromFunc(l2, i2=>new MemberInitData() {
                FieldOne = i2
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l2.Body;

            var replace = new Dictionary<Expression,Expression> {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1=>o1.NewExpression == e2);
            assert.ProductionHas(e1, o1=>o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1=>((MemberAssignment)o1.Bindings[0]).Expression == e3);
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
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l1 = xgr.FromFunc(l2, i2 => new MemberInitData()
            {
                FieldOne = i2
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l2.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.New(e2.Constructor) }
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);

            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test003()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l1 = xgr.FromFunc(l2, i2 => new MemberInitData()
            {
                FieldOne = i2
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l2.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3,Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);

            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }

        [TestMethod]
        public void Test004()
        {
            var xgr = new ExpressionGenerator();
            var l2 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l1 = xgr.FromFunc(l2, i2 => new MemberInitData()
            {
                FieldOne = i2
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l2.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e2,Expression.New(e2.Constructor) },
                {e3,Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);

            assert.TotalVisits(3);
            assert.TotalProduced(3);
        }
        
        [TestMethod]
        public void Test005()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
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
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.New(e2.Constructor) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test007()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test008()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == replace[e4]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test009()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.New(e2.Constructor) },
                { e3, Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test010()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                { e2, Expression.New(e2.Constructor) },
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == replace[e4]);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test011()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == replace[e4]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test012()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l1 = xgr.FromFunc(l3, l4, (i3, i4) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(e2.Constructor) },
                {e3, Expression.Constant(1) },
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == replace[e4]);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);

            assert.TotalVisits(4);
            assert.TotalProduced(4);
        }

        [TestMethod]
        public void Test013()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == e5);
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
        public void Test014()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(e2.Constructor) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == e5);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
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
        public void Test015()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == e5);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test016()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == e5);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test017()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e5, Expression.Constant(true) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == replace[e5]);
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
        public void Test018()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(e2.Constructor) },
                {e3, Expression.Constant(1) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == e5);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test019()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(e2.Constructor) },
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == e5);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test020()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(e2.Constructor) },
                {e5, Expression.Constant(true) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == replace[e5]);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
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
        public void Test021()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(e2.Constructor) },
                {e3, Expression.Constant(1) },
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == e5);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test022()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(e2.Constructor) },
                {e3, Expression.Constant(1) },
                {e5, Expression.Constant(true) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == replace[e5]);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test023()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e2, Expression.New(e2.Constructor) },
                {e3, Expression.Constant(1) },
                {e4, Expression.Constant("ABC") },
                {e5, Expression.Constant(true) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == replace[e2]);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == replace[e5]);
            assert.WasVisited(e2);
            assert.WasProduced(replace[e2]);
            assert.WasNotProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test024()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
                {e4, Expression.Constant("ABC") },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == e5);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test025()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
                {e5, Expression.Constant(true) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == e4);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == replace[e5]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test026()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e3, Expression.Constant(1) },
                {e4, Expression.Constant("ABC") },
                {e5, Expression.Constant(true) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == replace[e3]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == replace[e5]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(replace[e3]);
            assert.WasNotProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }

        [TestMethod]
        public void Test027()
        {
            var xgr = new ExpressionGenerator();
            var l3 = Expression.Lambda<Func<int>>(Expression.Default(typeof(int)));
            var l4 = Expression.Lambda<Func<string>>(Expression.Default(typeof(string)));
            var l5 = Expression.Lambda<Func<bool>>(Expression.Default(typeof(bool)));
            var l1 = xgr.FromFunc(l3, l4, l5, (i3, i4, i5) => new MemberInitData()
            {
                FieldOne = i3,
                FieldTwo = i4,
                FieldThree = i5,
            });
            var e1 = (MemberInitExpression)l1.Body;
            var e2 = e1.NewExpression;
            var e3 = l3.Body;
            var e4 = l4.Body;
            var e5 = l5.Body;

            var replace = new Dictionary<Expression, Expression>
            {
                {e4, Expression.Constant("ABC") },
                {e5, Expression.Constant(true) },
            };
            var assert = ExpressionVisitorVerifierTool.Test(e1, replace);

            assert.WasVisited(e1);
            assert.WasNotProduced(e1);
            assert.ProductionHas(e1, o1 => o1.NewExpression == e2);
            assert.ProductionHas(e1, o1 => o1.Bindings.Count == e1.Bindings.Count);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[0]).Expression == e3);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[1]).Expression == replace[e4]);
            assert.ProductionHas(e1, o1 => ((MemberAssignment)o1.Bindings[2]).Expression == replace[e5]);
            assert.WasVisited(e2);
            assert.WasProduced(e2);
            assert.WasVisited(e3);
            assert.WasProduced(e3);
            assert.WasVisited(e4);
            assert.WasProduced(replace[e4]);
            assert.WasNotProduced(e4);
            assert.WasVisited(e5);
            assert.WasProduced(replace[e5]);
            assert.WasNotProduced(e5);

            assert.TotalVisits(5);
            assert.TotalProduced(5);
        }
    }
}
