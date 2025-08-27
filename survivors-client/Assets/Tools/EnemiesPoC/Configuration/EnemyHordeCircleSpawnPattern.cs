using System;
using Survivors.Common;
using UnityEngine;

namespace Tools.HostMigrationPoC
{
    [CreateAssetMenu(menuName = GameAssetCategory.Enemies + nameof(EnemyHordeCircleSpawnPattern), fileName = nameof(EnemyHordeCircleSpawnPattern))]
    public class EnemyHordeCircleSpawnPattern : ScriptableObject
    {
        [SerializeField]
        private EnemyHordeSpawnPattern _spawnPattern;
    }
}