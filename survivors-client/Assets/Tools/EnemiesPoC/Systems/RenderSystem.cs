using System;
using Common.Systems;
using Secs;
using Tools.HostMigrationPoC.Components;
using UnityEngine;

namespace Tools.HostMigrationPoC.Systems
{
    public class RenderSystem : ISystemExecutable
    {
        public void Execute(Registry registry, float deltaTime)
        {
            registry.Each(static (Registry registry, ref RenderBatch batch) =>
            {
                if (batch.Matrices == null)
                {
                    batch.Matrices = new Matrix4x4[256];
                }

                batch.Size = 0;
                
                foreach (var refMatrix in registry.Each<Matrix4x4>())
                {
                    ref var mat = ref refMatrix.Value;
                    
                    batch.Size++;
                    
                    if (batch.Matrices.Length <= batch.Size)
                    {
                        Array.Resize(ref batch.Matrices, batch.Size * 2);
                    }
                    
                    batch.Matrices[batch.Size - 1] = mat;
                }
                
                Graphics.DrawMeshInstanced(batch.QuadMesh, 0, batch.QuadMaterial, batch.Matrices, batch.Size);
            });
        }
    }
}