using System;

namespace Common.Systems
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class RegisterSystemAttribute : Attribute
    {
        public Type SystemType { get; }
        public Type ContextType { get; }

        public RegisterSystemAttribute(Type systemType, Type contextType)
        {
            SystemType = systemType;
            ContextType = contextType;
        }
    }
}