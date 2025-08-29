using Common.Systems;
using Core.Gameplay;
using Core.Gameplay.Enemies;
using Secs;

[assembly:RegisterSystem(typeof(CrowdMoveSystem), typeof(GameplayContext))]

namespace Core.Gameplay.Enemies
{
    public class CrowdMoveSystem : ISystemExecutable
    {
        public void Execute(Registry registry, float deltaTime)
        {
            registry.Each<CrowdEntityComponent>(static (r, component) =>
            {
                
            });
        }
    }
}