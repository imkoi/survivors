using Common.Systems;
using Core.Gameplay;
using Core.Gameplay.Enemies;
using Secs;

namespace Core.Gameplay.Enemies
{
    public class CrowdSpawnSystem : ISystemExecutable
    {
        public void Execute(Registry registry, float deltaTime)
        {
            registry.EachWithEntity<CrowdSpawnRequestComponent>(static (r, e, component) =>
            {
                for (var i = 0; i < component.amount; i++)
                {
                    var entity = r.CreateEntity();

                    r.AddComponent(entity, new CrowdEntityComponent());
                }
                
                r.DestroyEntity(e);
            });
        }
    }
}