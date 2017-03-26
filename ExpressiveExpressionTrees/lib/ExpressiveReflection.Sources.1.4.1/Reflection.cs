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
      static class Reflection
      {
          private static readonly ConstructorReflection _constructor = new ConstructorReflection();
          private static readonly MemberReflection _member = new MemberReflection();
          private static readonly MethodReflection _method = new MethodReflection();
          private static readonly TypeReflection _type = new TypeReflection();
          private static readonly APIEquivalenceComparison _APIComparison = new APIEquivalenceComparison();
          static readonly CollectionReflection _collection = new CollectionReflection();
  
          public static ConstructorInfo GetConstructor<T>(Expression<Func<T>> constructorExpression)
          {
              return _constructor.From(constructorExpression);
          }
          public static ConstructorInfo Transmute(ConstructorInfo other, params Type[] newGenericArgs)
          {
              return _constructor.Transmute(other, newGenericArgs);
          }
          public static MemberInfo GetMember<T>(Expression<Func<T>> memberExpression)
          {
              return _member.From(memberExpression);
          }
          public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
          {
              return _member.NameOf(memberExpression);
          }
          public static MemberInfo Transmute(MemberInfo member, params Type[] newGenericArgs)
          {
              return _member.Transmute(member, newGenericArgs);
          }
  
          public static MethodInfo Transmute(MethodInfo other, Type[] typeArgsForType, Type[] typeArgsForMethod)
          {
              return _method.Transmute(other, typeArgsForType, typeArgsForMethod);
          }
          public static MethodInfo GetMethod<T>(Expression<Func<T>> methodExpression)
          {
              return _method.From(methodExpression);
          }
          public static MethodInfo GetMethod(Expression<Action> methodExpression)
          {
              return _method.From(methodExpression);
          }
          public static string GetMethodName<T>(Expression<Func<T>> methodExpression)
          {
              return _method.NameOf(methodExpression);
          }
          public static MethodInfo GetMethodExt(Type thisType, string name, params Type[] parameterTypes)
          {
              return _method.GetMethodExt(thisType, name, parameterTypes);
          }
          public static MethodInfo GetMethodExt(Type thisType, string name, BindingFlags bindingFlags, params Type[] parameterTypes)
          {
              return _method.GetMethodExt(thisType, name, bindingFlags, parameterTypes);
          }
          public static Type GenericT { get { return typeof(MethodReflection.T); } }
          public static Type ArrayOfGenericT { get { return typeof(MethodReflection.T).MakeArrayType(1); } }
  
          public static Type Transmute(Type other, params Type[] newGenericArgs)
          {
              return _type.Transmute(other, newGenericArgs);
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
              return _type.IsNullAssignable(type);
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
  
  
          public static Type GetElementType(Type seqType) { return _collection.GetElementType(seqType); }
          public static Type GetIEnumerableType(Type elementType) { return _collection.GetIEnumerableType(elementType); }
          public static Type FindIEnumerable(Type seqType) { return _collection.FindIEnumerable(seqType); }
      }
  }
  }