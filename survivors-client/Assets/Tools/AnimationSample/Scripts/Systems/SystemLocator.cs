using System;
using System.Collections.Generic;
using Tools.AnimationSample.Scripts.Systems;
using UnityEngine;

namespace Common.Systems
{
    public static class SystemLocator
    {
        private static Dictionary<Type, List<SystemRegistryBase>> _systemRegistries;

        [RuntimeInitializeOnLoadMethod]
        private static void ClearCache()
        {
            _systemRegistries = null;
        }

        public static Dictionary<Type, List<SystemRegistryBase>> GetSystemRegistries()
        {
            if(_systemRegistries == null)
            {
                _systemRegistries = new (1024);

                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    var assemblyAttributes = assembly.GetCustomAttributes(typeof(LinkSystemRegistryAttribute), false);

                    foreach (var systemAttribute in assemblyAttributes)
                    {
                        var linkSystemRegistryAttribute = (LinkSystemRegistryAttribute) systemAttribute;
                        var systemConstructor = linkSystemRegistryAttribute.SystemRegistryType.GetConstructor(Type.EmptyTypes);

                        if (systemConstructor == null)
                        {
                            throw new Exception($"Cannot find constructor for type {linkSystemRegistryAttribute.SystemRegistryType}");
                        }
                        
                        var systemRegistry = systemConstructor.Invoke(Array.Empty<object>()) as SystemRegistryBase;

                        if (systemRegistry == null)
                        {
                            throw new Exception($"Cannot instantiate type {linkSystemRegistryAttribute.SystemRegistryType}");
                        }

                        if (!_systemRegistries.TryGetValue(systemRegistry.ContextType, out var systemRegistriesList))
                        {
                            systemRegistriesList = new List<SystemRegistryBase>();
                            _systemRegistries.Add(systemRegistry.ContextType, systemRegistriesList);
                        }

                        systemRegistriesList.Add(systemRegistry);
                    }
                }
            }
            
            return _systemRegistries;
        }
    }
}