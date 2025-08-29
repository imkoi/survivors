using System;
using Core.Gameplay;
using DefaultNamespace;
using Fusion;
using Secs;
using Tools.HostMigrationPoC.Components;
//using Unity.Netcode;
using UnityEngine;

namespace Tools.HostMigrationPoC
{
    public class TestPlayerEnemiesPoC : NetworkBehaviour
    {
        private Registry _registry;

        private int _playerEntity;
        
        public override void Spawned()
        {
            EcsContext.TryGetRegistry(typeof(GameplayContext), out _registry);

            _playerEntity = _registry.CreateEntity();

            _registry.AddComponent(_playerEntity, new Player());
            _registry.AddComponent(_playerEntity, new Health());
            _registry.AddComponent(_playerEntity, new Velocity());
            _registry.AddComponent(_playerEntity, new Position());
            _registry.AddComponent(_playerEntity, new Rotation());
            _registry.AddComponent(_playerEntity, new Scale());
            _registry.AddComponent(_playerEntity, new Matrix4x4());
            
            base.Spawned();
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _registry.DestroyEntity(_playerEntity);
            
            base.Despawned(runner, hasState);
        }

        public override void FixedUpdateNetwork()
        {
            var vertical = Input.GetAxis("Vertical");
            var horizontal = Input.GetAxis("Horizontal");
            var input = new Vector3(horizontal, 0, vertical);
        
            transform.position += input * 4f * Runner.DeltaTime;

            ref var pos = ref _registry.GetComponent<Position>(_playerEntity);

            pos.Value = transform.position;
        }
    }
}