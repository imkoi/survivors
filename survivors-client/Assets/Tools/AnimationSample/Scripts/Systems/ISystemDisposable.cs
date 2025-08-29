using Secs;
using Tools.AnimationSample.Scripts.Systems;

namespace Common.Systems
{
    public interface ISystemDisposable : ISystem
    {
        void Dispose(Registry registry);
    }
}