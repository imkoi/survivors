using UnityEngine;

namespace Tools.HostMigrationPoC
{
    public abstract class EnemyHordeMovePattern : ScriptableObject
    {
        public abstract Vector2 GetVelocity(int enemyIndex);
    }
}