// Nuget source distribution of ExpressiveReflection.Sources.
namespace ExpressiveExpressionTrees.App_Packages {
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
      static class Reflection
      {
          private static readonly ConstructorReflection _constructor = new ConstructorReflection();
          private static readonly MemberReflection _member = new MemberReflection();
          private static readonly MethodReflection _method = new MethodReflection();
          private static readonly TypeReflection _type = new TypeReflection();
          private static readonly APIEquivalenceComparison _APIComparison = new APIEquivalenceComparison();
  
          public static ConstructorInfo GetConstructor<T>(Expression<Func<T>> constructorExpression)
          {
              return _constructor.From(constructorExpression);
          }
          public static MemberInfo GetMember<T>(Expression<Func<T>> memberExpression)
          {
              return _member.From(memberExpression);
          }
          public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
          {
              return _member.NameOf(memberExpression);
          }
  
          public static MethodInfo GetMethod<T>(Expression<Func<T>> methodExpression)
          {
              return _method.From(methodExpression);
          }
          public static string GetMethodName<T>(Expression<Func<T>> methodExpression)
          {
              return _method.NameOf(methodExpression);
          }
          public static Type GetType<T>(Expression<Func<T>> typeExpression)
          {
              return _type.From(typeExpression);
          }
          public static string GetTypeName<T>(Expression<Func<T>> typeExpression)
          {
              return _type.NameOf(typeExpression);
          }
  
          public static Type GetType(MemberInfo member)
          {
              return _type.From(member);
          }
  
  
          public static bool IsNullableType(Type type)
          {
              return _type.IsNullableType(type);
          }
  
          public static bool IsNullAssignable(Type type)
          {
              return _type.IsNullableType(type);
          }
  
          public static Type MadeNonNullable(Type type)
          {
              return _type.MadeNonNullable(type);
          }
  
          public static Type MadeNullAssignable(Type type)
          {
              return _type.MadeNullAssignable(type);
          }
  
          public static object GetDefaultValue(Type type)
          {
             return _type.GetDefaultValue(type);
          }
  
          public static bool IsInteger(Type type)
          {
              return _type.IsInteger(type);
          }
  
          public static bool IsDecimal(Type type)
          {
              return _type.IsDecimal(type);
          }
          public static bool IsReadOnly(MemberInfo member)
          {
              return _member.IsReadOnly(member);
          }
  
          public static bool IsAPIEquivalent(MemberInfo left, MemberInfo right)
          {
              return _APIComparison.Matches(left, right);
          }
  
          public static T GetValue<T>(MemberInfo member, object instance, params object[] args)
          {
              return _member.GetValue<T>(member, instance, args);
          }
          public static object GetValue(MemberInfo member, object instance, params object[] args)
          {
              return _member.GetValue(member, instance, args);
          }
  
          public static void SetValue<T>(MemberInfo member, object instance, T value, params object[] args)
          {
              _member.SetValue<T>(member, instance, value, args);
          }
  
          public static void SetValue(MemberInfo member, object instance, object value, params object[] args)
          {
              _member.SetValue(member, instance, value, args);
          }
      }
  }
  }