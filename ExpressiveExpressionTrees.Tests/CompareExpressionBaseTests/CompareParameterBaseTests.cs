using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareParameterBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = Expression.Parameter(typeof(int));
            var expr2 = Expression.Parameter(typeof(int));

            _assert.AreEqual(
                new Dictionary<ParameterExpression, ParameterExpression> {
                    { expr1, expr2 }
                },
                expr1, expr2);
        }


        [TestMethod]
        public virtual void Test002()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = Expression.Parameter(typeof(int));
            var expr2 = Expression.Parameter(typeof(long));

            _assert.AreNotEqual(
                new Dictionary<ParameterExpression, ParameterExpression> {
                    { expr1, expr2 }
                },
                expr1, expr2);
        }

        [TestMethod]
        public virtual void Test005()
        {
            

            var expr1 = Expression.Parameter(typeof(int));
            var expr2 = expr1;

            _assert.AreEqual(expr1, expr2);
        }
    }
}
