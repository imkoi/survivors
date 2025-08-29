using Secs;
using Tools.AnimationSample.Scripts.Systems;

namespace Common.Systems
{
    public interface ISystemExecutable : ISystem
    {
        void Execute(Registry registry, float deltaTime);
    }
}