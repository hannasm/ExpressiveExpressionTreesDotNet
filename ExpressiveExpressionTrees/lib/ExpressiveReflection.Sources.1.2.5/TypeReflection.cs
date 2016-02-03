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
      class TypeReflection
      {
          public Type From<T>(Expression<Func<T>> typeExpression)
          {
              return typeExpression.ReturnType;
          }
          public string NameOf<T>(Expression<Func<T>> typeExpression)
          {
              var result = From(typeExpression);
              
              if (!(result is TypeInfo)) {
                  throw new InvalidExpressionException("Expected expression to have valid TypeInfo", typeExpression);
              }
  
              return result.ToString();
          }
          public Type From(MemberInfo mi)
          {
              switch (mi.MemberType) {
                  case MemberTypes.Event:
                      return ((EventInfo)mi).EventHandlerType;
                  case MemberTypes.Field:
                      return ((FieldInfo)mi).FieldType;
                  case MemberTypes.Method:
                      return ((MethodInfo)mi).ReturnType;
                  case MemberTypes.Property:
                      return ((PropertyInfo)mi).PropertyType;
                  case MemberTypes.NestedType:
                  case MemberTypes.TypeInfo:
                      return ((TypeInfo)mi);
                  case MemberTypes.Constructor:
                      return ((ConstructorInfo)mi).DeclaringType;
                  default:
                      throw new NotImplementedException("Unexpected member type: " + mi.MemberType);
              }
          }
  
          public bool IsNullableType(Type type)
          {
              return type != null && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
          }
  
          public bool IsNullAssignable(Type type)
          {
              return !type.IsValueType || IsNullableType(type);
          }
  
          public Type MadeNonNullable(Type type)
          {
              if (IsNullableType(type))
              {
                  return type.GetGenericArguments()[0];
              }
              return type;
          }
  
          public Type MadeNullAssignable(Type type)
          {
              if (!IsNullAssignable(type))
              {
                  return typeof(Nullable<>).MakeGenericType(type);
              }
              return type;
          }
          
          public object GetDefaultValue(Type type)
          {
              bool isNullable = !type.IsValueType || IsNullableType(type);
              if (!isNullable)
                  return Activator.CreateInstance(type);
              return null;
          }
  
          public bool IsInteger(Type type)
          {
              Type nnType = MadeNonNullable(type);
              switch (Type.GetTypeCode(type))
              {
                  case TypeCode.SByte:
                  case TypeCode.Int16:
                  case TypeCode.Int32:
                  case TypeCode.Int64:
                  case TypeCode.Byte:
                  case TypeCode.UInt16:
                  case TypeCode.UInt32:
                  case TypeCode.UInt64:
                      return true;
                  default:
                      if (nnType == typeof(System.Int64) ||
                          nnType == typeof(System.Int32) ||
                          nnType == typeof(System.Int16) ||
                          nnType == typeof(System.UInt16) ||
                          nnType == typeof(System.UInt32) ||
                          nnType == typeof(System.UInt64) ||
                          nnType == typeof(System.Byte) ||
                          nnType == typeof(System.SByte))
                      {
                          return true;
                      }
                      return false;
              }
          }
  
          public bool IsDecimal(Type type)
          {
              Type nnType = MadeNonNullable(type);
              switch (Type.GetTypeCode(type))
              {
                  case TypeCode.Single:
                  case TypeCode.Double:
                  case TypeCode.Decimal:
                      return true;
                  default:
                      if (nnType == typeof(System.Single) ||
                          nnType == typeof(System.Double) ||
                          nnType == typeof(System.Decimal))
                      {
                          return true;
                      }
                      return false;
              }
          }
      }
  }
  }