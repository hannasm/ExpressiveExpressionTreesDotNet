using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareConditionalBaseTests : CompareExpressionTestBase
    {
        [TestMethod]
        public virtual void Test001()
        {
            

            var innerCompare = Expression.Default(typeof(bool));
            var outcomeTrue = Expression.Default(typeof(int));
            var outcomeFalse = Expression.Default(typeof(int));

            var expr1 = Expression.Condition(innerCompare, outcomeTrue, outcomeFalse);
            var expr2 = Expression.Condition(innerCompare, outcomeTrue, outcomeFalse);

            _assert.AreEqual(expr1, expr2);
        }
        [TestMethod]
        public virtual void Test002()
        {
            

            var expr1 = Expression.Condition(Expression.Default(typeof(bool)), Expression.Default(typeof(int)), Expression.Default(typeof(int)));
            var expr2 = Expression.Condition(Expression.Default(typeof(bool)), Expression.Default(typeof(int)), Expression.Default(typeof(int)));

            _assert.AreEqual(expr1, expr2);
        }
    }
}
