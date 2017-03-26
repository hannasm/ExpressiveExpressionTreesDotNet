// Nuget source distribution of ExpressiveReflection.Sources.1.4.1
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
      partial class MethodReflection
      {
          /// <summary>
          /// Convert a methodinfo from one generic type permutation to a different generic permutation. It is possible to change both the
          /// generic permutations of the declaring type and of the method definition. If you don't desire to transmute the declaring type, specify
          /// null for the typeArgsForType argument. You may only pass null for the typeArgsForMethod argument if the method is not generic.
          /// </summary>
          public MethodInfo Transmute(MethodInfo target, Type[] typeArgsForType, Type[] typeArgsForMethod)
          {
              var declaringType = target.DeclaringType;
              if (target.IsGenericMethod && !target.IsGenericMethodDefinition)
              {
                  target = target.GetGenericMethodDefinition();
              }
              
              Type newType;
              if (declaringType.IsGenericType && typeArgsForType != null && typeArgsForType.Length > 0)
              {
                  newType = declaringType.GetGenericTypeDefinition().MakeGenericType(typeArgsForType);
              }
              else
              {
                  newType = declaringType;
              }
              
              var newMethod = newType.GetMethods().Where(m => m.MetadataToken == target.MetadataToken && m.Module == target.Module).Single();
              if (newMethod.IsGenericMethodDefinition)
              {
                  newMethod = newMethod.MakeGenericMethod(typeArgsForMethod);
              }
  
              return newMethod;
          }
  
          public MethodInfo From(Expression<Action> methodExpression)
          {
              return From(methodExpression.Body);
          }
          public MethodInfo From<T>(Expression<Func<T>> methodExpression)
          {
              return From(methodExpression.Body);
          }
          public MethodInfo From(Expression methodExpression)
          {
              var mthExpr = methodExpression as MethodCallExpression;
              if (mthExpr != null) {
                  return mthExpr.Method;
              }
              
              var bexp = methodExpression as BinaryExpression;
              if (bexp != null && bexp.Method != null) {
                  return bexp.Method;
              }
  
              var uexp = methodExpression as UnaryExpression;
              if (uexp != null && uexp.Method != null) {
                  return uexp.Method;
              }
  
              throw new InvalidExpressionException(
                  "method reflection",
                  methodExpression,
                  typeof(MethodCallExpression),
                  typeof(BinaryExpression),
                  typeof(UnaryExpression)
              );
          }
  
          public string NameOf<T>(Expression<Func<T>> methodExpression)
          {
              return From(methodExpression).Name;
          }
          public string NameOf(Expression<Action> methodExpression)
          {
              return From(methodExpression).Name;
          }
          public string NameOf(Expression methodExpression)
          {
              return From(methodExpression).Name;
          }
      }
  }
  }