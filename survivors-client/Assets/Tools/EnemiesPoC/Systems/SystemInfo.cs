using Common.Systems;
using Core.Gameplay;
using Tools.HostMigrationPoC.Systems;

[assembly:RegisterSystem(typeof(HordeSpawnSystem), typeof(GameplayContext))]
[assembly:RegisterSystem(typeof(MoveSystem), typeof(GameplayContext))]
[assembly:RegisterSystem(typeof(CollisionSystem), typeof(GameplayContext))]
[assembly:RegisterSystem(typeof(MatrixTransformSystem), typeof(GameplayContext))]
[assembly:RegisterSystem(typeof(RenderSystem), typeof(GameplayContext))]