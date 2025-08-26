using System;
using Fusion;
//using Unity.Netcode;
using UnityEngine;

namespace Tools.HostMigrationPoC
{
    public class TestPlayer : NetworkBehaviour
    {
        private void Update()
        {
            if (!HasStateAuthority)
            {
                return;
            }
            
            
        }
        
        public override void FixedUpdateNetwork()
        {
            var vertical = Input.GetAxis("Vertical");
            var horizontal = Input.GetAxis("Horizontal");
            var input = new Vector3(horizontal, 0, vertical);
        
            transform.position += input * 4f * Runner.DeltaTime;
        }
    }
}