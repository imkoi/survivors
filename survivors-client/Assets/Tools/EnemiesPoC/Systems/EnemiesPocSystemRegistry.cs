using Common.Systems;
using Core.Gameplay;
using Tools.AnimationSample.Scripts.Systems;
using Tools.HostMigrationPoC;
using Tools.HostMigrationPoC.Systems;

[assembly: LinkSystemRegistry(typeof(EnemiesPocSystemRegistry))]

namespace Tools.HostMigrationPoC
{
    public class EnemiesPocSystemRegistry : SystemRegistry<GameplayContext>
    {
        protected override void RegisterSystems(ISystemRegistryBuilder builder)
        {
            builder.WithSystem<HordeSpawnSystem>();
            builder.WithSystem<EnemyMoveSystem>();
            builder.WithSystem<CollisionSystem>();
            builder.WithSystem<MatrixTransformSystem>();
            builder.WithSystem<RenderSystem>();
        }
    }
}