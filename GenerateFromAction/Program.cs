﻿using System;
using static System.Console;

namespace GenerateFromAction
{
    class Program
    {
        static void Main(string[] args)
        {
          var ts = "    ";
          var ws = "";

          WriteLine("{0}using global::System;", ws); 
          WriteLine("{0}using global::System.Linq.Expressions;", ws);
          WriteLine("{0}namespace ExpressiveExpressionTrees {{", ws);
          ws += ts;
          WriteLine("{0}#if EXPRESSIVE_EXPRESSION_TREES_ASSEMBLY", "");
          WriteLine("{0}public",ws);
          WriteLine("{0}#endif", "");
          WriteLine("{0}partial class ExpressionGenerator {{",ws);
          ws += ts;
          for (int i = 0; i < 16; i++) {
            Write("{0}public Expression FromAction<", ws, i+1);
            var prefix = "";
            for (int j = 1; j <= i+1; j++) {
              Write("{0}T{1}", prefix, j);
              prefix = ", ";
            } 
            Write(">(");
            for (int j = 1; j <= i+1; j++) {
              Write("Expression<Func<T{0}>> p{0}, ", j);
            } 
            Write("Expression<Action<");
            prefix = "";
            for (int j = 1; j <= i+1; j++) {
              Write("{0}T{1}", prefix, j);
              prefix = ", ";
            }
            WriteLine(">> expr)");
            WriteLine("{0}{{", ws);
            WriteLine("{0}{1}return ExpressionReplacer.", ws, ts);
	          WriteLine("{0}            Search(expr.Body).", ws);
            for (int j = 1; j <= i+1; j++) {
		          WriteLine("{0}            When(expr.Parameters[{1}], p{2}.Body).", ws, j-1, j);
            }
            WriteLine("{0}            GetResult();", ws);
            WriteLine("{0}}}", ws);
          }
          WriteLine("{0}}}", ts);
          WriteLine("}");
        }
    }
}
