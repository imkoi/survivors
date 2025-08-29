using Common.Systems;
using Secs;
using Tools.HostMigrationPoC.Components;
using UnityEngine;

namespace Tools.HostMigrationPoC.Systems
{
    public class MatrixTransformSystem : ISystemExecutable
    {
        public void Execute(Registry registry, float deltaTime)
        {
            registry.Each(static (Registry _, ref Position position, ref Rotation rotation, ref Scale scale, ref Matrix4x4 matrix) =>
            {
                matrix.SetTRS(position.Value, Quaternion.Euler(rotation.Value), scale.Value);
            });
        }
    }
}