using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    public abstract class CompareExpressionTestBase
    {
        protected CompareExpressionTestBase()
        {
            _assert = new CompareExpressionAssertion(this);
        }

        public abstract bool AreEqual(Expression left, Expression right);
        public abstract bool AreEqual(Dictionary<ParameterExpression, ParameterExpression> mapping, Expression left, Expression right);
        public readonly CompareExpressionAssertion _assert;

        public sealed class CompareExpressionAssertion
        {
            CompareExpressionTestBase _base;

            public CompareExpressionAssertion(CompareExpressionTestBase @base)
            {
                _base = @base;
            }

            public void AreEqual(Expression left, Expression right)
            {
                Assert.IsTrue(_base.AreEqual(left, right), "Expected left and right to be equal");
            }
            public void AreEqual(Dictionary<ParameterExpression, ParameterExpression> mapping, Expression left, Expression right)
            {
                Assert.IsTrue(_base.AreEqual(mapping, left, right), "Expected left and right to be equal");
            }

            public void AreNotEqual(Expression left, Expression right)
            {
                Assert.IsFalse(_base.AreEqual(left, right), "Expected left and right to not be equal");
            }

            public void AreNotEqual(Dictionary<ParameterExpression, ParameterExpression> mapping, Expression left, Expression right)
            {
                Assert.IsFalse(_base.AreEqual(mapping, left, right), "Expected left and right to not be equal");
            }
        }
    }
}
