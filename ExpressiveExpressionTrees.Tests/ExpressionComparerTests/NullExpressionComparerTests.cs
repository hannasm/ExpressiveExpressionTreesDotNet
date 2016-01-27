using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionComparerTests
{

    [TestClass]
    public class NullExpressionComparerTests : CompareNullBasetests
    {
        public override bool AreEqual(Expression left, Expression right)
        {
            var xc = new ExpressionComparer();

            return xc.AreEqual(left, right);
        }

        public override bool AreEqual(Dictionary<ParameterExpression, ParameterExpression> mapping, Expression left, Expression right)
        {
            var xc = new ExpressionComparer();

            return xc.AreEqual(mapping, left, right);
        }
    }
}
