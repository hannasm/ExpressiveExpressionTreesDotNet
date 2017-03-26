// Nuget source distribution of ExpressiveReflection.Sources.1.4.1
namespace ExpressiveExpressionTrees.lib {
  using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Reflection;
using global::System.Text;
using global::System.Threading.Tasks;

namespace ExpressiveReflection
{
    /// <summary>
    /// Provides facility for testing whether two reflected properties are representing the same component of an API,
    /// regardless of whether they represent the exact same implementation
    /// </summary>

#if EXPRESSIVE_REFLECTION_ASSEMBLY
    public
#endif
    class APIEquivalenceComparison
    {
        public bool IsParentEquivalentToChild(MemberInfo parentMember, MemberInfo childMember)
        {
            switch (parentMember.MemberType)
            {
                case MemberTypes.Property:
                    return IsParentEquivalentToChild(parentMember as PropertyInfo, childMember as PropertyInfo);
                case MemberTypes.Method:
                    return IsParentEquivalentToChild(parentMember as MethodInfo, childMember as MethodInfo);
                case MemberTypes.Field:
                    return IsParentEquivalentToChild(parentMember as FieldInfo, childMember as FieldInfo);
                case MemberTypes.TypeInfo:
                    return IsParentEquivalentToChild(parentMember as TypeInfo, childMember as TypeInfo);
                case MemberTypes.Event:
                    return IsParentEquivalentToChild(parentMember as EventInfo, childMember as EventInfo);
                default:
                    throw new NotImplementedException("Member type " + parentMember.MemberType);
            }
        }

        public bool IsParentEquivalentToChild(FieldInfo parentField, FieldInfo childField)
        {
            return false;
        }
        public bool IsParentEquivalentToChild(TypeInfo parentMethod, TypeInfo childMethod)
        {
            return false;
        }
        public bool IsParentEquivalentToChild(EventInfo parentMethod, EventInfo childMethod)
        {
            return false;
        }
        public bool IsParentEquivalentToChild(MethodInfo parentMethod, MethodInfo childMethod)
        {
            if (parentMethod.GetBaseDefinition() == childMethod.GetBaseDefinition()) { return true; }

            var pim = GetInterfaceMethod(parentMethod);
            if (pim != null) {
                var cim = GetInterfaceMethod(childMethod);
                if (pim == cim) { return true; }
            }

            return false;
        }

        public MethodInfo GetInterfaceMethod(MethodInfo childMethod)
        {            
            if (childMethod.DeclaringType.IsInterface) { return childMethod; }

            foreach (var @interface in childMethod.DeclaringType.GetInterfaces())
            {
                var map = childMethod.DeclaringType.GetInterfaceMap(@interface);
                for (int i=0, len=map.InterfaceMethods.Length;i<len;i++)
                {
                    if (map.TargetMethods[i] == childMethod) { return map.InterfaceMethods[i]; }
                }
            }
            return null;
        }

        public bool IsParentEquivalentToChild(PropertyInfo parentProperty, PropertyInfo childProperty)
        {
            if (!parentProperty.DeclaringType.IsInterface && !childProperty.DeclaringType.IsInterface)
            {
                if (parentProperty.GetGetMethod() != null &&
                    childProperty.GetGetMethod() != null &&
                    parentProperty.GetGetMethod().GetBaseDefinition() == childProperty.GetGetMethod().GetBaseDefinition()) {
                    return true;
                }
                if (parentProperty.GetSetMethod() != null &&
                    childProperty.GetSetMethod() != null &&
                    parentProperty.GetSetMethod().GetBaseDefinition() == childProperty.GetSetMethod().GetBaseDefinition()) {
                    return true;
                }
            }

            if (parentProperty.GetGetMethod() != null &&
                childProperty.GetGetMethod() != null) {
                var pm = GetInterfaceMethod(parentProperty.GetGetMethod());
                if (pm != null) {
                    var cm = GetInterfaceMethod(childProperty.GetGetMethod());
                    if (cm == pm) { return true; }
                }
            }

            if (parentProperty.GetSetMethod() != null &&
                childProperty.GetSetMethod() != null)
            {
                var pm = GetInterfaceMethod(parentProperty.GetSetMethod());
                if (pm != null)
                {
                    var cm = GetInterfaceMethod(childProperty.GetSetMethod());
                    if (cm == pm) { return true; }
                }
            }

            return false;
        }

        public bool Matches(MemberInfo targetProperty, MemberInfo sourceProperty)
        {
            if (sourceProperty == null) { return false; }
            if (targetProperty == null) { return false; }

            if (sourceProperty.MemberType != targetProperty.MemberType) { return false; }

            var targetType = targetProperty.DeclaringType;

            if (sourceProperty.DeclaringType == targetType) { if (sourceProperty == targetProperty) { return true; } }
            else if (targetType.IsAssignableFrom(sourceProperty.DeclaringType))
            {
                return IsParentEquivalentToChild(targetProperty, sourceProperty);
            }
            else if (sourceProperty.DeclaringType.IsAssignableFrom(targetType))
            {
                return IsParentEquivalentToChild(sourceProperty, targetProperty);
            }

            switch (targetProperty.MemberType)
            {
                case MemberTypes.Method:
                case MemberTypes.Property:
                    return IsParentEquivalentToChild(targetProperty, sourceProperty);
                default:
                    return false;
            }
        }
    }
}
}