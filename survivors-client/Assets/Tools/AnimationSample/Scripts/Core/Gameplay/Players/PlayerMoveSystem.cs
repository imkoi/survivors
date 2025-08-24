using Common.Systems;
using Core.Gameplay;
using Core.Gameplay.Players;
using Ecs;

[assembly:RegisterSystem(typeof(PlayerMoveSystem), typeof(GameplayContext))]

namespace Core.Gameplay.Players
{
    public class PlayerMoveSystem : ISystemExecutable
    {
        public void Execute(Registry registry, float deltaTime)
        {
            
        }
    }
}