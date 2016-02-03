using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests
{
    [TestClass]
    public class ExpressionGeneratorMultiProjectTests
    {
        class InitializerOne {
            public string StringField;
            public int IntField;
        }
        class InitializerTwo {
            public string StringFieldOne;
            public string StringFieldTwo;
        }
        Expression<Func<InitializerOne,string>> _initializerOneTemplate = x=>x.StringField + x.IntField;
        Expression<Func<InitializerTwo,string>> _initializerTwoTemplate = x=>x.StringFieldTwo + x.StringFieldOne;

        [TestMethod]
        public void Test001()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.MultiProject(
                ()=>new {
                    FieldOne = 1,
                    FieldTwo = "ABC"
                },
                x=>new InitializerOne {
                    IntField = x.FieldOne,
                    StringField = x.FieldTwo
                },
                _initializerOneTemplate,
                x=>new InitializerTwo {
                    StringFieldOne = x.FieldTwo + "DEF",
                    StringFieldTwo = "GHI" + x.FieldTwo
                },
                _initializerTwoTemplate,
                (x,y)=>new {
                    InitializerOneResult = x,
                    InitializerTwoResult = y
                }
            );

            var inputPlaceholder = xgr.FromFunc(()=>new {
                FieldOne = 1,
                FieldTwo = "ABC"
            });
            var expectations = xgr.FromFunc(inputPlaceholder, x=>new {
                InitializerOneResult = (new InitializerOne {
                        IntField = x.FieldOne,
                        StringField = x.FieldTwo
                    }).StringField + (new InitializerOne
                    {
                        IntField = x.FieldOne,
                        StringField = x.FieldTwo
                    }).IntField,
                InitializerTwoResult = (new InitializerTwo {
                        StringFieldOne = x.FieldTwo + "DEF",
                        StringFieldTwo = "GHI" + x.FieldTwo
                    }).StringFieldTwo + (new InitializerTwo
                    {
                        StringFieldOne = x.FieldTwo + "DEF",
                        StringFieldTwo = "GHI" + x.FieldTwo
                    }).StringFieldOne
            });

            var inputParam = Expression.Parameter(inputPlaceholder.ReturnType);
            var expected = Expression.Lambda(
                ExpressionReplacer.Replace(expectations.Body, inputPlaceholder.Body, inputParam),
                inputParam
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test002()
        {
            var xgr = new ExpressionGenerator();

            var e1 = xgr.MultiProject(
                () => new {
                    FieldOne = 1,
                    FieldTwo = "ABC"
                },
                x => x.FieldTwo + x.FieldOne,
                x => "GHI" + x.FieldTwo + x.FieldTwo + "DEF",
                (x, y) => new {
                    InitializerOneResult = x,
                    InitializerTwoResult = y
                }
            );

            var inputPlaceholder = xgr.FromFunc(() => new {
                FieldOne = 1,
                FieldTwo = "ABC"
            });
            var expectations = xgr.FromFunc(inputPlaceholder, x => new {
                InitializerOneResult = x.FieldTwo + x.FieldOne,
                InitializerTwoResult = "GHI" + x.FieldTwo + x.FieldTwo + "DEF"
            });

            var inputParam = Expression.Parameter(inputPlaceholder.ReturnType);
            var expected = Expression.Lambda(
                ExpressionReplacer.Replace(expectations.Body, inputPlaceholder.Body, inputParam),
                inputParam
            );

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, e1));
        }

        [TestMethod]
        public void Test003()
        {
            var xgr = new ExpressionGenerator();
            var q = Enumerable.Range(0,1).Select(x=> new {
                FieldOne = 1,
                FieldTwo = "ABC"
            }).AsQueryable();

            var e1 = xgr.MultiProject(
                q,
                x => new InitializerOne
                {
                    IntField = x.FieldOne,
                    StringField = x.FieldTwo
                },
                _initializerOneTemplate,
                x => new InitializerTwo
                {
                    StringFieldOne = x.FieldTwo + "DEF",
                    StringFieldTwo = "GHI" + x.FieldTwo
                },
                _initializerTwoTemplate,
                (x, y) => new {
                    InitializerOneResult = x,
                    InitializerTwoResult = y
                }
            );

            var inputPlaceholder = xgr.FromFunc(() => new {
                FieldOne = 1,
                FieldTwo = "ABC"
            });
            var expectations = xgr.FromFunc(inputPlaceholder, x => new {
                InitializerOneResult = (new InitializerOne
                {
                    IntField = x.FieldOne,
                    StringField = x.FieldTwo
                }).StringField + (new InitializerOne
                {
                    IntField = x.FieldOne,
                    StringField = x.FieldTwo
                }).IntField,
                InitializerTwoResult = (new InitializerTwo
                {
                    StringFieldOne = x.FieldTwo + "DEF",
                    StringFieldTwo = "GHI" + x.FieldTwo
                }).StringFieldTwo + (new InitializerTwo
                {
                    StringFieldOne = x.FieldTwo + "DEF",
                    StringFieldTwo = "GHI" + x.FieldTwo
                }).StringFieldOne
            });

            var inputParam = Expression.Parameter(inputPlaceholder.ReturnType);
            var expected = Expression.Lambda(
                ExpressionReplacer.Replace(expectations.Body, inputPlaceholder.Body, inputParam),
                inputParam
            );

            var inner1 = e1.Expression as MethodCallExpression;
            var inner2 = inner1.Arguments[1] as UnaryExpression;
            var inner3 = inner2.Operand as LambdaExpression;

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, inner3));
        }

        [TestMethod]
        public void Test004()
        {
            var xgr = new ExpressionGenerator();
            var q = Enumerable.Range(0, 1).Select(x => new {
                FieldOne = 1,
                FieldTwo = "ABC"
            }).AsQueryable();

            var e1 = xgr.MultiProject(
                q,
                x => x.FieldTwo + x.FieldOne,
                x => "GHI" + x.FieldTwo + x.FieldTwo + "DEF",
                (x, y) => new {
                    InitializerOneResult = x,
                    InitializerTwoResult = y
                }
            );

            var inputPlaceholder = xgr.FromFunc(() => new {
                FieldOne = 1,
                FieldTwo = "ABC"
            });
            var expectations = xgr.FromFunc(inputPlaceholder, x => new {
                InitializerOneResult = x.FieldTwo + x.FieldOne,
                InitializerTwoResult = "GHI" + x.FieldTwo + x.FieldTwo + "DEF"
            });

            var inputParam = Expression.Parameter(inputPlaceholder.ReturnType);
            var expected = Expression.Lambda(
                ExpressionReplacer.Replace(expectations.Body, inputPlaceholder.Body, inputParam),
                inputParam
            );

            var inner1 = e1.Expression as MethodCallExpression;
            var inner2 = inner1.Arguments[1] as UnaryExpression;
            var inner3 = inner2.Operand as LambdaExpression;

            var comparer = new ExpressionComparer();
            Assert.IsTrue(comparer.AreEqual(expected, inner3));
        }
    }
}
