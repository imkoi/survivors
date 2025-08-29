using Common.Systems;
using Core.Gameplay;
using Secs;
using Tools.HostMigrationPoC.Components;
using UnityEngine;

namespace Tools.HostMigrationPoC.Systems
{
    public class HordeSpawnSystem : ISystemExecutable
    {
        public void Execute(Registry registry, float deltaTime)
        {
            registry.EachWithEntity(static (Registry r, int e, HordeSpawnRequest hordeSpawnRequest) =>
            {
                r.DestroyEntity(e);

                for (var i = 0; i < hordeSpawnRequest.Amount; i++)
                {
                    var enemyEntity = r.CreateEntity();
                    r.AddComponent(enemyEntity, new Enemy());
                    r.AddComponent(enemyEntity, new Position());
                    r.AddComponent(enemyEntity, new Rotation());
                    r.AddComponent(enemyEntity, new Scale());
                    r.AddComponent(enemyEntity, new Matrix4x4());
                }
            });
        }
    }
}