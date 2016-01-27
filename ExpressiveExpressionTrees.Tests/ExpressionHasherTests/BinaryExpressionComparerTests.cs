using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionHasherTests
{

    [TestClass]
    public class BinaryExpressionHasherTests : CompareBinaryBaseTests
    {
        public override bool AreEqual(Expression left, Expression right)
        {
            var lh = ExpressionHasher.Hash(left);
            var rh = ExpressionHasher.Hash(right);

            return lh.HashCode == rh.HashCode;
        }

        public override bool AreEqual(Dictionary<ParameterExpression, ParameterExpression> mapping, Expression left, Expression right)
        {
            return AreEqual(left, right);
        }
    }
}
