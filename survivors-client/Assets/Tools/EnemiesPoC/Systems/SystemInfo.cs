using Common.Systems;
using Core.Gameplay;
using Tools.HostMigrationPoC.Systems;

[assembly:RegisterSystem(typeof(EnemySpawnSystem), typeof(GameplayContext))]
[assembly:RegisterSystem(typeof(EnemyMoveSystem), typeof(GameplayContext))]