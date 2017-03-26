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
    class MemberReflection
    {
          /// <summary>
          /// Convert a memberinfo from one generic type permutation to a different generic permutation. If you don't want to 
          /// transmute the declaring type, specify null / do not specify the newGenericArgs.
          /// </summary>
          public MemberInfo Transmute(MemberInfo target, params Type[] newGenericArgs)
          {
              // you can't transmute a non-generic type's constructor because there are no generic arguments
              // to change
              if (!target.DeclaringType.IsGenericType || newGenericArgs == null || newGenericArgs.Length == 0)
              {
                  return target;
              }
              
              var type = target.DeclaringType.GetGenericTypeDefinition().MakeGenericType(newGenericArgs);
              var transmuted = type.GetMembers().Where(m => m.MetadataToken == target.MetadataToken && m.Module == target.Module).Single();
              return transmuted;
          }

        /// <summary>
        /// Use expression tree to reflect property info from types 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="memberExpression"></param>
        /// <returns></returns>
        public MemberInfo From<T>(Expression<Func<T>> memberExpression)
        {
            if (memberExpression == null) {
                throw new ArgumentNullException("memberExpression");
            }
            
            var mbrExpr = memberExpression.Body as MemberExpression;            
            if (mbrExpr != null) {
                return mbrExpr.Member;
            }

            var mthCallexpr = memberExpression.Body as MethodCallExpression;
            if (mthCallexpr != null) {
                var method = mthCallexpr.Method;
                if (method.DeclaringType != null) { // not sure if there are acutally methods with null for declarying type
                    foreach (var prop in method.DeclaringType.GetProperties())
                    {
                        if (prop.GetGetMethod() == method ||
                            prop.GetSetMethod() == method)
                        {
                            return prop;
                        }
                    }
                }
            }

            var idxExpr = memberExpression.Body as IndexExpression;
            if (idxExpr != null) {
                return idxExpr.Indexer;
            }
            
            throw new InvalidExpressionException(
                "member reflection",
                memberExpression.Body,
                typeof(MemberExpression),
                typeof(IndexExpression),
                typeof(MethodCallExpression)
            );
        }

        public string NameOf<T>(Expression<Func<T>> memberExpression)
        {
            return From(memberExpression).Name;
        }

        public bool IsReadOnly(MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return (((FieldInfo)member).Attributes & FieldAttributes.InitOnly) != 0;
                case MemberTypes.Property:
                    PropertyInfo pi = (PropertyInfo)member;
                    return !pi.CanWrite || pi.GetSetMethod() == null;
                default:
                    return true;
            }
        }

        public T GetValue<T>(MemberInfo member, object instance, params object[] args)
        {
            return (T)GetValue(member, instance, args);
        }
        public object GetValue(MemberInfo member, object instance, params object[] args)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Property:
                    return ((PropertyInfo)member).GetValue(instance, args);
                case MemberTypes.Field:
                    return ((FieldInfo)member).GetValue(instance);
                default:
                    throw new InvalidOperationException();
            }
        }

        public void SetValue<T>(MemberInfo member, object instance, T value, params object[] args)
        {
            SetValue(member, instance, (object)value, args);
        }

        public void SetValue(MemberInfo member, object instance, object value, params object[] args)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Property:
                    var pi = (PropertyInfo)member;
                    pi.SetValue(instance, value, args);
                    break;
                case MemberTypes.Field:
                    var fi = (FieldInfo)member;
                    fi.SetValue(instance, value);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
}