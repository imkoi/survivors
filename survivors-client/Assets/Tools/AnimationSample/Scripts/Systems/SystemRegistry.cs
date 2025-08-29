using System;
using System.Collections.Generic;

namespace Tools.AnimationSample.Scripts.Systems
{
    public abstract class SystemRegistryBase
    {
        public abstract Type ContextType { get; }
        public abstract int Count { get; }

        internal abstract IReadOnlyList<Func<ISystem>> GetSystemFactories();
    }
    
    public abstract class SystemRegistry<TContext> : SystemRegistryBase
    {
        public override Type ContextType => typeof(TContext);
        public override int Count => _systemFactories?.Count ?? GetSystemFactories().Count;

        private IReadOnlyList<Func<ISystem>> _systemFactories;
        
        internal override IReadOnlyList<Func<ISystem>> GetSystemFactories()
        {
            if (_systemFactories == null)
            {
                var builder = new SystemRegistryBuilder();
            
                RegisterSystems(builder);

                _systemFactories = builder.Build();
            }
            
            return _systemFactories;
        }
        
        protected abstract void RegisterSystems(ISystemRegistryBuilder builder);

        public interface ISystemRegistryBuilder
        {
            ISystemRegistryBuilder WithSystem<TSystem>() where TSystem : ISystem, new();
        }

        private class SystemRegistryBuilder : ISystemRegistryBuilder
        {
            private List<Func<ISystem>> _systemFactories = new List<Func<ISystem>>(128);
            public int Count => _systemFactories.Count;
            
            public ISystemRegistryBuilder WithSystem<TSystem>() where TSystem : ISystem, new()
            {
                _systemFactories.Add(() => new TSystem());
                
                return this;
            }

            public IReadOnlyList<Func<ISystem>> Build()
            {
                return _systemFactories;
            }
        }
    }
}