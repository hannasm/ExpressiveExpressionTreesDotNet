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
    public class ExpressionGeneratorTests
    {
        [TestMethod]
        [Description("Just making sure that these two methods (WithType / WithoutType) work correctly and round-trip properly, in some very basic scenario. A more comprehensive test suite seems like pointless waste of time when the current implementations are so simple.")]
        public void Test001()
        {
            var xgr = new ExpressionGenerator();
            var expr = Expression.Default(typeof(string));
            var expr2 = xgr.WithType<string>(expr);
            var expr3 = xgr.WithoutType(expr2);

            var xcr = new ExpressionComparer();
            Assert.IsTrue(xcr.AreEqual(expr, expr3));
        }
    }
}
