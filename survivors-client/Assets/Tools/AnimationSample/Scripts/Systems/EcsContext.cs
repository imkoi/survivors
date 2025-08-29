using System;
using System.Collections.Generic;
using System.Linq;
using Common.Systems;
using Secs;
using Tools.AnimationSample.Scripts.Systems;
using UnityEngine;

namespace DefaultNamespace
{
    public class EcsContext : MonoBehaviour
    {
        private Dictionary<Type, EcsHolder> _contextHolders;
        private List<EcsHolder> _holders;

        private static EcsContext _singleton;

        public static bool TryGetRegistry(Type contextType, out Registry registry)
        {
            if (_singleton._contextHolders.TryGetValue(contextType, out var holder))
            {
                registry = holder.Registry;
                
                return true;
            }

            registry = null;

            return false;
        }

        private void Awake()
        {
            _singleton = this;
            
            _contextHolders = new Dictionary<Type, EcsHolder>();
            _holders = new List<EcsHolder>();
            
            foreach (var pair in SystemLocator.GetSystemRegistries())
            {
                var handler = new EcsHolder(pair.Key, pair.Value);
                
                _contextHolders.Add(pair.Key, handler);
                _holders.Add(handler);
            }
        }

        private void Start()
        {
            foreach (var holder in _holders)
            {
                holder.Initialize(holder.Registry);
            }
        }

        private void Update()
        {
            var dt = Time.deltaTime;

            foreach (var holder in _holders)
            {
                holder.Execute(holder.Registry, dt);
            }
        }

        private void OnDestroy()
        {
            foreach (var holder in _holders)
            {
                holder.Dispose(holder.Registry);
            }
        }

        private class EcsHolder : ISystemInitializable, ISystemExecutable, ISystemDisposable
        {
            public Registry Registry => _registry;

            private Registry _registry;

            private List<object> _systems;
            private List<ISystemInitializable> _systemInitializables;
            private List<ISystemExecutable> _systemExecutables;
            private List<ISystemDisposable> _systemDisposables;

            public EcsHolder(Type contextType, List<SystemRegistryBase> systemRegistryBases)
            {
                var systemsCount = systemRegistryBases.Sum(sr => sr.Count);
                
                _registry = new Registry();
                _systems = new List<object>(systemsCount);
                _systemInitializables = new List<ISystemInitializable>(systemsCount / 4);
                _systemExecutables = new List<ISystemExecutable>(systemsCount / 4);
                _systemDisposables = new List<ISystemDisposable>(systemsCount / 4);

                foreach (var systemRegistry in systemRegistryBases)
                {
                    foreach (var systemFactory in systemRegistry.GetSystemFactories())
                    {
                        var system = systemFactory.Invoke();
                        
                        _systems.Add(system);
                        
                        if (system is ISystemInitializable initializable)
                        {
                            _systemInitializables.Add(initializable);
                        }

                        if (system is ISystemExecutable executable)
                        {
                            _systemExecutables.Add(executable);
                        }

                        if (system is ISystemDisposable disposable)
                        {
                            _systemDisposables.Add(disposable);
                        }
                    }
                }
            }

            public void Initialize(Registry registry)
            {
                foreach (var initializable in _systemInitializables)
                {
                    initializable.Initialize(registry);
                }
            }

            public void Execute(Registry registry, float deltaTime)
            {
                foreach (var executable in _systemExecutables)
                {
                    executable.Execute(registry, deltaTime);
                }
            }

            public void Dispose(Registry registry)
            {
                foreach (var disposable in _systemDisposables)
                {
                    disposable.Dispose(registry);
                }
            }
        }
    }
}