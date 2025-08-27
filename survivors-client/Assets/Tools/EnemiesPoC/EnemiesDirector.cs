using System.Collections;
using Fusion;
using UnityEngine;

namespace Tools.HostMigrationPoC
{
    public class EnemiesDirector : NetworkBehaviour
    {
        // [SerializeField]
        // private 
        
        private void Start()
        {
            StartCoroutine(Schedule());
        }

        private IEnumerator Schedule()
        {
            while (Runner == null)
            {
                yield return null;
            }

            //Runner.Spawn(SpawnEnemyHorde());
        }
        
        public void SpawnEnemyHorde(Vector3 position, int hordeId)
        {
            
        }
    }
}