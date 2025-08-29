using Secs;

namespace Common.Systems
{
    public interface ISystemExecutable
    {
        void Execute(Registry registry, float deltaTime);
    }
}