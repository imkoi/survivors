using System;
using System.Linq;
using DefaultNamespace;
using Ecs;
using UnityEngine;

namespace Core.Gameplay.Enemies
{
    public class Crowd : MonoBehaviour
    {
        [SerializeField] 
        private Mesh _quadMesh;
    
        [SerializeField] 
        private Material _quadMaterial;
    
        [SerializeField]
        private Texture[] _moveSprites;

        [SerializeField]
        private int _crowdMaxCount;
    
        private Matrix4x4[] _matrices;
    
        private Registry _registry;

        private void Awake()
        {
            _quadMaterial.mainTexture = _moveSprites.First();
        }

        private void Start()
        {
            EcsContext.TryGetRegistry(typeof(GameplayContext), out _registry);
        }

        private void Update()
        {
            var matrices = GetMatrix(_crowdMaxCount);
            var len = _crowdMaxCount;

            var rot = Quaternion.identity;
            var s = Vector3.one;
        
            for (var i = 0; i < len; i++)
            {
                ref var mat = ref matrices[i];

                mat.SetTRS(new Vector3(i % 100, i / 100, 0), rot, s);
            }

            Graphics.DrawMeshInstanced(_quadMesh, 0, _quadMaterial, matrices, _crowdMaxCount);
        }

        private Matrix4x4[] GetMatrix(int amount)
        {
            if (_matrices == null)
            {
                _matrices = new Matrix4x4[amount];
            }

            if (_matrices.Length < amount)
            {
                Array.Resize(ref _matrices, amount);
            }
        
            return _matrices;
        }
    }
}
