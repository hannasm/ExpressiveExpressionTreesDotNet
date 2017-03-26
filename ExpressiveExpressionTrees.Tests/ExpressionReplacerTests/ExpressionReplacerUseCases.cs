using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressiveExpressionTrees.Tests.ExpressionReplacerTests
{
    /// <summary>
    /// Simple tests that are just checking that expected sequences of various express replacer calls perform as expected.
    /// </summary>
    [TestClass]
    public class ExpressionReplacerUseCases
    {
        Expression GenericExpressionToSearchIn()
        {
            return Expression.Default(typeof(string));
        }
        Expression GenericExpressionToSearchFor()
        {
            return Expression.Default(typeof(string));
        }
        Expression GenericExpressionToReplaceWith()
        {
            return Expression.Default(typeof(string));
        }

        [TestMethod]
        public void Test001()
        {
            ExpressionReplacer.Replace(
                GenericExpressionToSearchIn(),
                GenericExpressionToSearchFor(),
                GenericExpressionToReplaceWith()
            );
        }
        [TestMethod]
        public void Test002()
        {
            var builder = ExpressionReplacer.Search(GenericExpressionToSearchIn());
            builder.GetResult();
        }
        [TestMethod]
        public void Test003()
        {
            var builder = ExpressionReplacer.Search(GenericExpressionToSearchIn());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.GetResult();
        }
        [TestMethod]
        public void Test004()
        {
            var builder = ExpressionReplacer.Search(GenericExpressionToSearchIn());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.GetResult();
        }
        [TestMethod]
        public void Test005()
        {
            var builder = ExpressionReplacer.Search(GenericExpressionToSearchIn());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.GetResult();
        }
        [TestMethod]
        public void Test006()
        {
            var builder = ExpressionReplacer.Search(GenericExpressionToSearchIn());
            builder.ReplaceIn(GenericExpressionToSearchIn());
        }
        [TestMethod]
        public void Test007()
        {
            var builder = ExpressionReplacer.Search(GenericExpressionToSearchIn());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.ReplaceIn(GenericExpressionToSearchIn());
        }
        [TestMethod]
        public void Test008()
        {
            var builder = ExpressionReplacer.Search(GenericExpressionToSearchIn());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.ReplaceIn(GenericExpressionToSearchIn());
        }
        [TestMethod]
        public void Test009()
        {
            var builder = ExpressionReplacer.Search(GenericExpressionToSearchIn());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.ReplaceIn(GenericExpressionToSearchIn());
        }
        [TestMethod]
        public void Test010()
        {
            var builder = ExpressionReplacer.PrepareSearch();
            builder.ReplaceIn(GenericExpressionToSearchIn());
        }
        [TestMethod]
        public void Test011()
        {
            var builder = ExpressionReplacer.PrepareSearch();
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.ReplaceIn(GenericExpressionToSearchIn());
        }
        [TestMethod]
        public void Test012()
        {
            var builder = ExpressionReplacer.PrepareSearch();
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.ReplaceIn(GenericExpressionToSearchIn());
        }
        [TestMethod]
        public void Test013()
        {
            var builder = ExpressionReplacer.PrepareSearch();
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.ReplaceIn(GenericExpressionToSearchIn());
        }
        
        [TestMethod]
        public void Test014()
        {
            var builder = ExpressionReplacer.PrepareSearch();
            try { builder.GetResult(); Assert.Fail("Test should not reach here"); }
            catch (NullReferenceException eError)
            {
                Assert.AreEqual("no target, perhaps you want ReplaceIn() instead", eError.Message);
            }
        }
        [TestMethod]
        public void Test015()
        {
            var builder = ExpressionReplacer.PrepareSearch();
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            try { builder.GetResult(); Assert.Fail("Test should not reach here"); }
            catch (NullReferenceException eError)
            {
                Assert.AreEqual("no target, perhaps you want ReplaceIn() instead", eError.Message);
            }
        }
        [TestMethod]
        public void Test016()
        {
            var builder = ExpressionReplacer.PrepareSearch();
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            try { builder.GetResult(); Assert.Fail("Test should not reach here"); }
            catch (NullReferenceException eError)
            {
                Assert.AreEqual("no target, perhaps you want ReplaceIn() instead", eError.Message);
            }
        }
        [TestMethod]
        public void Test017()
        {
            var builder = ExpressionReplacer.PrepareSearch();
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            builder.When(GenericExpressionToSearchFor(), GenericExpressionToReplaceWith());
            try { builder.GetResult(); Assert.Fail("Test should not reach here"); }
            catch (NullReferenceException eError)
            {
                Assert.AreEqual("no target, perhaps you want ReplaceIn() instead", eError.Message);
            }
        }
    }
}
