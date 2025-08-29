using UnityEngine;

namespace Tools.HostMigrationPoC.Components
{
    public struct RenderBatch
    {
        public Mesh QuadMesh;
        public Material QuadMaterial;
        public Matrix4x4[] Matrices;
        public int Size;
    }
}