using Ecs;

namespace Common.Systems
{
    public interface ISystemDisposable
    {
        void Dispose(Registry registry);
    }
}