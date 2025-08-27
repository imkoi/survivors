using UnityEngine;

namespace Tools.HostMigrationPoC
{
    public abstract class EnemyHordeSpawnPattern : ScriptableObject
    {
        public abstract Vector2 GetSpawnPosition(int enemyIndex);
    }
}