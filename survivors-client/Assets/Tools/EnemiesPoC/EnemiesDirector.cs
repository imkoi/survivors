using System.Collections;
using Core.Gameplay;
using DefaultNamespace;
using Fusion;
using Secs;
using Tools.HostMigrationPoC.Components;
using UnityEngine;

namespace Tools.HostMigrationPoC
{
    public class EnemiesDirector : NetworkBehaviour
    {
        [SerializeField]
        private Mesh _quadMesh;
        [SerializeField]
        private Material _quadMaterial;
        // [SerializeField]
        // private 
        
        private Registry _registry;
        
        private void Start()
        {
            EcsContext.TryGetRegistry(typeof(GameplayContext), out _registry);

            var batchEntity = _registry.CreateEntity();
            _registry.AddComponent(batchEntity, new RenderBatch
            {
                QuadMesh = _quadMesh,
                QuadMaterial = _quadMaterial
            });
            
            StartCoroutine(Schedule());
        }

        private IEnumerator Schedule()
        {
            while (Runner == null)
            {
                yield return new WaitForSeconds(5);

                var enemySpawnRequest = _registry.CreateEntity();

                _registry.AddComponent(enemySpawnRequest, new HordeSpawnRequest()
                {
                    Amount = 16
                });
            }

            //Runner.Spawn(SpawnEnemyHorde());
        }
        
        public void SpawnEnemyHorde(Vector3 position, int hordeId)
        {
            
        }
    }
}