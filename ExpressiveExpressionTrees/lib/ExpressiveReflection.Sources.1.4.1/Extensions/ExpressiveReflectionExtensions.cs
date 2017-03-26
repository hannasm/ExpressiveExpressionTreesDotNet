// Nuget source distribution of ExpressiveReflection.Sources.1.4.1
namespace ExpressiveExpressionTrees.lib {
  using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Linq.Expressions;
using global::System.Reflection;
using global::System.Text;
using global::System.Threading.Tasks;

namespace ExpressiveReflection.Extensions
{
#if EXPRESSIVE_REFLECTION_ASSEMBLY
    public
#endif
    static class ExpressiveReflectionExtensions
    {
        public static Type GetMemberType(this MemberInfo member)
        {
            return Reflection.GetType(member);
        }

        public static bool IsNullableType(this Type type)
        {
            return Reflection.IsNullableType(type);
        }

        public static bool IsNullAssignable(this Type type)
        {
            return Reflection.IsNullAssignable(type);
        }

        public static Type MadeNonNullable(this Type type)
        {
            return Reflection.MadeNonNullable(type);
        }

        public static Type MadeNullAssignable(this Type type)
        {
            return Reflection.MadeNullAssignable(type);
        }

        public static object GetDefaultValue(this Type type)
        {
            return Reflection.GetDefaultValue(type);
        }

        public static bool IsInteger(this Type type)
        {
            return Reflection.IsInteger(type);
        }

        public static bool IsDecimal(this Type type)
        {
            return Reflection.IsDecimal(type);
        }
        public static bool IsReadOnly(this MemberInfo member)
        {
            return Reflection.IsReadOnly(member);
        }

        public static bool IsAPIEquivalent(this MemberInfo left, MemberInfo right)
        {
            return Reflection.IsAPIEquivalent(left, right);
        }

        public static T GetValue<T>(this MemberInfo member, object instance, params object[] args)
        {
            return Reflection.GetValue<T>(member, instance, args);
        }
        public static object GetValue(this MemberInfo member, object instance, params object[] args)
        {
            return Reflection.GetValue(member, instance, args);
        }

        public static void SetValue<T>(this MemberInfo member, object instance, T value, params object[] args)
        {
            Reflection.SetValue<T>(member, instance, value, args);
        }

        public static void SetValue(this MemberInfo member, object instance, object value, params object[] args)
        {
            Reflection.SetValue(member, instance, value, args);
        }
  
          public static MemberInfo Transmute(this MemberInfo member, params Type[] newGenericArgs)
          {
              return Reflection.Transmute(member, newGenericArgs);
          }
        public static ConstructorInfo Transmute(this ConstructorInfo constructor, params Type[] newGenericArgs)
          {
              return Reflection.Transmute(constructor, newGenericArgs);
          }
        public static Type Transmute(this Type other, params Type[] newGenericArgs)
          {
              return Reflection.Transmute(other, newGenericArgs);
          }
          public static MethodInfo Transmute(this MethodInfo other, Type[] typeArgsForType, Type[] typeArgsForMethod)
          {
              return Reflection.Transmute(other, typeArgsForType, typeArgsForMethod);
          }
          public static MethodInfo GetMethodExt(this Type thisType, string name, params Type[] parameterTypes)
          {
              return Reflection.GetMethodExt(thisType, name, parameterTypes);
          }
          public static MethodInfo GetMethodExt(this Type thisType, string name, BindingFlags bindingFlags, params Type[] parameterTypes)
          {
              return Reflection.GetMethodExt(thisType, name, bindingFlags, parameterTypes);
          }
    }
}
}