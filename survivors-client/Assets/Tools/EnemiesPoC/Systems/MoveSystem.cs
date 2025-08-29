using System;
using Common.Systems;
using Secs;
using Tools.HostMigrationPoC.Components;
using UnityEngine;

namespace Tools.HostMigrationPoC.Systems
{
    public class MoveSystem : ISystemInitializable, ISystemExecutable
    {
        private static Registry.EachMutable<Enemy, Position, Velocity> _enemyMove = Move;
        
        private static float _deltaTime; 
        
        public void Initialize(Registry registry)
        {
            _enemyMove = Move;
        }
        
        public void Execute(Registry registry, float deltaTime)
        {
            _deltaTime = deltaTime;
 
            registry.Each(_enemyMove);
        }
        
        private static void Move(Registry r, ref Enemy enemy, ref Position pos, ref Velocity vel)
        {
            bool found = false;
            Vector2 closest = default;
            float minDistSq = float.PositiveInfinity;

            foreach (var (refPlayer, refPlayerPos, refPlayerVel) in r.Each<Player, Position, Velocity>())
            {
                ref var player = ref refPlayer.Value;
                ref var playerPos = ref refPlayerPos.Value;
                ref var playerVel = ref refPlayerVel.Value;
                
                Vector2 toPlayer = playerPos.Value - pos.Value;
                float distSq = toPlayer.x * toPlayer.x + toPlayer.y * toPlayer.y;

                if (distSq < minDistSq)
                {
                    minDistSq = distSq;
                    closest = playerPos.Value;
                    found = true;
                }
            }

            if (!found)
            {
                return;
            }

            Vector2 delta = closest - pos.Value;
            float distSq2 = delta.x * delta.x + delta.y * delta.y;
            if (distSq2 > 1e-12f)
            {
                float speed = vel.Value.sqrMagnitude; // длина текущей скорости

                // если скорость = 0, можно задать минимальную, чтобы враг двинулся
                if (speed <= 1e-4f)
                    speed = 3f;

                Vector2 dir = delta / MathF.Sqrt(distSq2);
                vel.Value = dir * speed;

                // (опционально) остановка, если почти достигли цели
                float stopRadius = 0.05f;
                if (distSq2 <= stopRadius * stopRadius)
                    vel.Value = Vector2.zero;
            }
        }
    }
}