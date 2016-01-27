using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.CompareExpressionBaseTests
{
    [TestClass]
    public abstract class CompareMemberAccessBaseTests : CompareExpressionTestBase
    {
        public class MemberAccessTestData {
            public readonly string StringOne;
            public readonly string StringTwo;
            public readonly int IntOne;
            public readonly int IntTwo;
        }

        [TestMethod]
        public virtual void Test001()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(()=>default(MemberAccessTestData).StringOne);
            var expr2 = xgr.FromFunc(() => default(MemberAccessTestData).StringOne);

            _assert.AreEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test002()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MemberAccessTestData).StringOne);
            var expr2 = xgr.FromFunc(() => default(MemberAccessTestData).StringTwo);

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test003()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MemberAccessTestData).StringTwo);
            var expr2 = xgr.FromFunc(() => default(MemberAccessTestData).StringOne);

            _assert.AreNotEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test004()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MemberAccessTestData).IntOne);
            var expr2 = xgr.FromFunc(() => default(MemberAccessTestData).IntOne);

            _assert.AreEqual(expr1, expr2);
        }


        [TestMethod]
        public virtual void Test005()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MemberAccessTestData).IntOne);
            var expr2 = xgr.FromFunc(() => default(MemberAccessTestData).IntTwo);

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test006()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MemberAccessTestData).IntTwo);
            var expr2 = xgr.FromFunc(() => default(MemberAccessTestData).IntOne);

            _assert.AreNotEqual(expr1, expr2);
        }



        [TestMethod]
        public virtual void Test007()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MemberAccessTestData).IntOne);
            var expr2 = xgr.FromFunc(() => default(MemberAccessTestData).StringOne);

            _assert.AreNotEqual(expr1, expr2);
        }

        [TestMethod]
        public virtual void Test008()
        {
            
            var xgr = new ExpressionGenerator();

            var expr1 = xgr.FromFunc(() => default(MemberAccessTestData).StringOne);
            var expr2 = xgr.FromFunc(() => default(MemberAccessTestData).IntOne);

            _assert.AreNotEqual(expr1, expr2);
        }



        [TestMethod]
        public virtual void Test009()
        {
            
            var xgr = new ExpressionGenerator();

            MemberAccessTestData constant = null;

            var expr1 = xgr.FromFunc(() => default(MemberAccessTestData).StringOne);
            var expr2 = xgr.FromFunc(() => constant.StringOne);

            _assert.AreNotEqual(expr1, expr2);
        }
    }
}
