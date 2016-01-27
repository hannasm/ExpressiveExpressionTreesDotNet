using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveExpressionTrees.Tests.ExpressionVisitorTest
{
    public class ExpressionVisitorVerifierTool : ExpressionVisitor
    {
        public readonly List<Expression> Inputs = new List<Expression>();
        public readonly List<Expression> Outputs = new List<Expression>(); 
        public Expression Result;
        public readonly Dictionary<int, Expression> PositionalReplacements;
        public readonly Dictionary<Expression, Expression> ExpressionReplacements; 

        public static ExpressionVisitorVerifierTool Test(Expression exp) {
            var visitor = new ExpressionVisitorVerifierTool(null, null);
            visitor.Visit(exp);
            return visitor;
        }
        public static ExpressionVisitorVerifierTool Test(Expression exp, Dictionary<int, Expression> replace)
        {
            var visitor = new ExpressionVisitorVerifierTool(replace, null);
            visitor.Visit(exp);
            return visitor;
        }
        public static ExpressionVisitorVerifierTool Test(Expression exp, Dictionary<Expression, Expression> replace)
        {
            var visitor = new ExpressionVisitorVerifierTool(null, replace);
            visitor.Visit(exp);
            return visitor;
        }


        protected ExpressionVisitorVerifierTool(Dictionary<int, Expression> posReplace, Dictionary<Expression, Expression> expReplace)
        {
            PositionalReplacements = posReplace ?? new Dictionary<int, Expression>();
            ExpressionReplacements = expReplace ?? new Dictionary<Expression, Expression>();
        }

        protected override Expression Visit(Expression exp)
        {
            int pos = Inputs.Count;
            Inputs.Add(exp);
            
            Expression result;
            if (exp != null && ExpressionReplacements.TryGetValue(exp, out result)) {
                PositionalReplacements.Add(pos, result);
            }

            result = base.Visit(exp);

            while (Outputs.Count <= pos) {
                Outputs.Add(null);
            }

            if (PositionalReplacements.TryGetValue(pos, out exp)) {
                Outputs[pos] = exp;
                return exp;
            } else {
                Outputs[pos] = result;
                return result;
            }
        }

        public void WasVisited(Expression exp)
        {
            WasVisited(exp, 1);
        }
        public void WasProduced(Expression exp)
        {
            WasProduced(exp, 1);
        }

        public void WasNotVisited(Expression exp)
        {
            WasVisited(exp, 0);
        }
        public void WasNotProduced(Expression exp)
        {
            WasProduced(exp, 0);
        }

        public void WasVisited(Expression exp, int count)
        {
            Assert.AreEqual(count, Inputs.Count(e => e == exp), "Element was not visited correct number of times");
        }
        public void WasProduced(Expression exp, int count)
        {
            Assert.AreEqual(count, Outputs.Count(e => e == exp), "Element was not produced correct number of times");
        }

        public void WasVisitedAt(Expression exp, int position)
        {
            Assert.IsTrue(Inputs[position] == exp, "Element at position "+  position + " didn't match");
        }
        public void WasProducedAt(Expression exp, int position)
        {
            Assert.IsTrue(Outputs[position] == exp, "Element at position " + position + " didn't match");
        }

        public void TotalVisits(int count)
        {
            Assert.AreEqual(count, Inputs.Count, "Total elements visited");
        }
        public void TotalProduced(int count)
        {
            Assert.AreEqual(count, Outputs.Count, "Total elements produced");
        }

        public void ProductionHas<T>(T of, Func<T,bool> has)
            where T : Expression
        {
            // cannot use this helper unless element was only visited once
            WasVisited(of, 1);

            var pos = Inputs.Select((e,i)=>new { Element = e, Index = i }).Where(e=>e.Element == of).Select(e=>e.Index).Single();
            
            Assert.IsTrue(has((T)Outputs[pos]), "Expected output at position " + pos + " to meet condition");
        }

        public T ProductionOf<T>(T of)
            where T : Expression
        {
            // cannot use this helper unless element was only visited once
            WasVisited(of, 1);

            var pos = Inputs.Select((e, i) => new { Element = e, Index = i }).Where(e => e.Element == of).Select(e => e.Index).Single();

            return (T)Outputs[pos];
        }
    }
}
