using Secs;

namespace Common.Systems
{
    public interface ISystemInitializable
    {
        void Initialize(Registry registry);
    }
}