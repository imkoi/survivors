using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

namespace Common.Systems
{
    public static class SystemLocator
    {
        private static HashSet<Type> _contextTypes;
        private static CompactList<RegisterSystemAttribute> _systemAttributes;
        private static Dictionary<Type, Type[]> _systemTypes;

        [RuntimeInitializeOnLoadMethod]
        private static void ClearCache()
        {
            _contextTypes = null;
            _systemAttributes = null;
            _systemTypes = null;
        }

        public static Type[] GetContextTypes()
        {
            if(_systemAttributes == null)
            {
                _contextTypes = new HashSet<Type>();
                
                var systemAttributes = new CompactList<RegisterSystemAttribute>(1024);
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                foreach (var assembly in assemblies)
                {
                    var assemblyAttributes = assembly.GetCustomAttributes(typeof(RegisterSystemAttribute), false);

                    foreach (var systemAttribute in assemblyAttributes)
                    {
                        var concreteSystemAttribute = (RegisterSystemAttribute) systemAttribute;
                        
                        systemAttributes.Add(concreteSystemAttribute);

                        _contextTypes.Add(concreteSystemAttribute.ContextType);
                    }
                }

                _systemAttributes = systemAttributes;
            }
            
            return _contextTypes.ToArray();
        }
        
        public static Type[] GetSystemTypes(Type contextType)
        {
            if(_systemAttributes == null)
            {
                _contextTypes = new HashSet<Type>();
                
                var systemAttributes = new CompactList<RegisterSystemAttribute>(1024);
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                foreach (var assembly in assemblies)
                {
                    var assemblyAttributes = assembly.GetCustomAttributes(typeof(RegisterSystemAttribute), false);

                    foreach (var systemAttribute in assemblyAttributes)
                    {
                        var concreteSystemAttribute = (RegisterSystemAttribute) systemAttribute;
                        
                        systemAttributes.Add(concreteSystemAttribute);

                        _contextTypes.Add(concreteSystemAttribute.ContextType);
                    }
                }

                _systemAttributes = systemAttributes;
            }

            if (_systemTypes == null)
            {
                _systemTypes = new Dictionary<Type, Type[]>();
            }

            if (!_systemTypes.TryGetValue(contextType, out var systemTypes))
            {
                var systemAttributesCount = _systemAttributes.Count;
                var systemAttributesBuffer = _systemAttributes.Buffer;
                var count = 0;
                
                systemTypes = new Type[Mathf.Max(1, systemAttributesCount / 4)];

                for (var i = systemAttributesCount - 1; i >= 0; i--)
                {
                    var attribute = systemAttributesBuffer[i];
                    
                    if (attribute.ContextType == contextType)
                    {
                        var targetCount = count + 1;
                        
                        if (systemTypes.Length < targetCount)
                        {
                            Array.Resize(ref systemTypes, targetCount * 2);
                        }
                        
                        systemTypes[count] = attribute.SystemType;
                        
                        _systemAttributes.RemoveAt(i);

                        count++;
                    }
                }
                
                Array.Resize(ref systemTypes, count);
                
                _systemTypes[contextType] = systemTypes;
            }

            return systemTypes;
        }
    }
}