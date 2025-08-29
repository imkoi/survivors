using Secs;
using Tools.AnimationSample.Scripts.Systems;

namespace Common.Systems
{
    public interface ISystemInitializable : ISystem
    {
        void Initialize(Registry registry);
    }
}