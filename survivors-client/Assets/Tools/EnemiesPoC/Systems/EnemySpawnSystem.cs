using Common.Systems;
using Core.Gameplay;
using Ecs;
using Tools.HostMigrationPoC.Components;
using Tools.HostMigrationPoC.Systems;
using UnityEngine;

namespace Tools.HostMigrationPoC.Systems
{
    public class EnemySpawnSystem : ISystemExecutable
    {
        public void Execute(Registry registry, float deltaTime)
        {
            registry.EachWithEntity(static (Registry r, int e, EnemySpawnRequest c) =>
            {
                r.DestroyEntity(e);
                
                var enemyEntity = r.CreateEntity();
                r.AddComponent(enemyEntity, new Enemy());
                r.AddComponent(enemyEntity, new Position());
                r.AddComponent(enemyEntity, new Rotation());
                r.AddComponent(enemyEntity, new Scale());
                r.AddComponent(enemyEntity, new Matrix4x4());
            });
        }
    }
}