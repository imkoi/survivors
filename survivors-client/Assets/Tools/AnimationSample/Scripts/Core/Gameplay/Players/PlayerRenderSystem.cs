using Common.Systems;
using Core.Gameplay;
using Core.Gameplay.Players;
using Secs;

[assembly:RegisterSystem(typeof(PlayerRenderSystem), typeof(GameplayContext))]

namespace Core.Gameplay.Players
{
    public class PlayerRenderSystem : ISystemExecutable
    {
        public void Execute(Registry registry, float deltaTime)
        {
            
        }
    }
}