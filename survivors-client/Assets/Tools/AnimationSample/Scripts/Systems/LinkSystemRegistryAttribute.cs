using System;

namespace Common.Systems
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class LinkSystemRegistryAttribute : Attribute
    {
        public Type SystemRegistryType { get; }

        public LinkSystemRegistryAttribute(Type systemRegistryType)
        {
            SystemRegistryType = systemRegistryType;
        }
    }
}