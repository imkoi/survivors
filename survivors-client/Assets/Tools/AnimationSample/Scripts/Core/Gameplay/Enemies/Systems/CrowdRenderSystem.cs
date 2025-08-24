using Common.Systems;
using Core.Gameplay;
using Core.Gameplay.Enemies;
using Ecs;

[assembly:RegisterSystem(typeof(CrowdRenderSystem), typeof(GameplayContext))]

namespace Core.Gameplay.Enemies
{
    public class CrowdRenderSystem : ISystemExecutable
    {
        public void Execute(Registry registry, float deltaTime)
        {
            
        }
    }
}