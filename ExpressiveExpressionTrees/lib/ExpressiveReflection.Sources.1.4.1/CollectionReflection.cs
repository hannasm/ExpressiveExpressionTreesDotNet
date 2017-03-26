// Nuget source distribution of ExpressiveReflection.Sources.1.4.1
namespace ExpressiveExpressionTrees.lib {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  
  namespace ExpressiveReflection
  {
  #if EXPRESSIVE_REFLECTION_ASSEMBLY
      public
  #endif
      class CollectionReflection
      {
          public Type FindIEnumerable(Type seqType)
          {
              if (seqType == null || seqType == typeof(string))
                  return null;
              if (seqType.IsArray)
                  return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());
              if (seqType.IsGenericType)
              {
                  foreach (Type arg in seqType.GetGenericArguments())
                  {
                      Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                      if (ienum.IsAssignableFrom(seqType))
                      {
                          return ienum;
                      }
                  }
              }
              Type[] ifaces = seqType.GetInterfaces();
              if (ifaces != null && ifaces.Length > 0)
              {
                  foreach (Type iface in ifaces)
                  {
                      Type ienum = FindIEnumerable(iface);
                      if (ienum != null) return ienum;
                  }
              }
              if (seqType.BaseType != null && seqType.BaseType != typeof(object))
              {
                  return FindIEnumerable(seqType.BaseType);
              }
              return null;
          }
  
          public Type GetIEnumerableType(Type elementType)
          {
              return typeof(IEnumerable<>).MakeGenericType(elementType);
          }
  
          public Type GetElementType(Type seqType)
          {
              Type ienum = FindIEnumerable(seqType);
              if (ienum == null) return seqType;
              return ienum.GetGenericArguments()[0];
          }
      }
  }
  }