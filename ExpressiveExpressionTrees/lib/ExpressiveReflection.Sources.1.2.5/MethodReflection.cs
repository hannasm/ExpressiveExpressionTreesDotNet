// Nuget source distribution of ExpressiveReflection.Sources.1.2.5
namespace ExpressiveExpressionTrees.lib {
  using global::System;
  using global::System.Collections.Generic;
  using global::System.Linq;
  using global::System.Linq.Expressions;
  using global::System.Reflection;
  using global::System.Text;
  using global::System.Threading.Tasks;
  
  namespace ExpressiveReflection
  {
  #if EXPRESSIVE_REFLECTION_ASSEMBLY
      public
  #endif
      class MethodReflection
      {
          public MethodInfo From<T>(Expression<Func<T>> methodExpression)
          {
              var mthExpr = methodExpression.Body as MethodCallExpression;
              if (mthExpr != null) {
                  return mthExpr.Method;
              }
              
              var bexp = methodExpression.Body as BinaryExpression;
              if (bexp != null && bexp.Method != null) {
                  return bexp.Method;
              }
  
              var uexp = methodExpression.Body as UnaryExpression;
              if (uexp != null && uexp.Method != null) {
                  return uexp.Method;
              }
  
              throw new InvalidExpressionException(
                  "method reflection",
                  methodExpression.Body,
                  typeof(MethodCallExpression),
                  typeof(BinaryExpression),
                  typeof(UnaryExpression)
              );
          }
  
          public string NameOf<T>(Expression<Func<T>> methodExpression)
          {
              return From(methodExpression).Name;
          }
      }
  }
  }