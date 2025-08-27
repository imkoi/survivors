using Common.Systems;
using Ecs;
using Tools.HostMigrationPoC.Components;

namespace Tools.HostMigrationPoC.Systems
{
    public class EnemyMoveSystem : ISystemExecutable
    {
        public static Filter EnemyFilter = Filter.Create(include: new []{typeof(Enemy)});
        
        public void Execute(Registry registry, float deltaTime)
        {
            registry.Each(static (Registry r, Player player, Position playerPosition) =>
            {
                r.Each((Registry _, ref Enemy enemy, ref Position enemyPosition) =>
                {
                    enemyPosition.Value += (playerPosition.Value - enemyPosition.Value) * 2f;
                }, EnemyFilter);
            });
        }
    }
}