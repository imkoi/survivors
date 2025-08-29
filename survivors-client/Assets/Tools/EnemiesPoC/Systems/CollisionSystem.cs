using System;
using Common.Systems;
using Secs;
using Tools.HostMigrationPoC.Components;
using UnityEngine;
using Collider = Tools.HostMigrationPoC.Components.Collider;

namespace Tools.HostMigrationPoC.Systems
{
    public class CollisionSystem : ISystemExecutable
    {
        public void Execute(Registry registry, float deltaTime)
        {
            registry.EachWithEntity(static (Registry iRegistry, int entity, ref Collider col, ref Position pos, ref Velocity vel) =>
            {
                foreach (var (otherEntity, refOtherCollider, refOtherPosition, refOtherVelocity) in iRegistry
                             .EachWithEntity<Collider, Position, Velocity>())
                {
                    if (entity == otherEntity)
                    {
                        continue;
                    }

                    ref var otherPos = ref refOtherPosition.Value;
                    ref var otherCol = ref refOtherCollider.Value;
                    ref var otherVel = ref refOtherVelocity.Value;

                    var delta = pos.Value - otherPos.Value;
                    var distSq = delta.sqrMagnitude;
                    var radii = col.Radius + otherCol.Radius;
                    var radiiSq = radii * radii;

                    if (distSq > radiiSq)
                    {
                        continue;
                    }
                    
                    var dist = MathF.Sqrt(distSq);
                    var n = dist > 1e-6f ? delta / dist : new Vector2(1f, 0f);

                    var penetration = radii - dist;
                    var move = penetration * 0.5f;

                    pos.Value += n * move;
                    otherPos.Value -= n * move;

                    const float restitution = 0.2f;

                    var relV = vel.Value - otherVel.Value;
                    var relAlongN = Vector2.Dot(relV, n);

                    if (relAlongN < 0f)
                    {
                        var j = -(1f + restitution) * relAlongN / 2f;

                        var impulse = j * n;

                        vel.Value += impulse;
                        otherVel.Value -= impulse;
                    }
                }
            });
        }
    }
}