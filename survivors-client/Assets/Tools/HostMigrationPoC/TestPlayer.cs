using System;
using Unity.Netcode;
using UnityEngine;

namespace Tools.HostMigrationPoC
{
    public class TestPlayer : NetworkBehaviour
    {
        private NetworkVariable<Vector3> _position = new NetworkVariable<Vector3>(
            readPerm: NetworkVariableReadPermission.Everyone,
            writePerm: NetworkVariableWritePermission.Owner);
        
        public override void OnNetworkSpawn()
        {
            Console.WriteLine($"Player[{OwnerClientId}] Spawned");
        }
        
        public override void OnNetworkDespawn()
        {
            Console.WriteLine($"Player[{OwnerClientId}] Despawned");
        }

        private void Update()
        {
            if (!IsSpawned)
            {
                return;
            }
            
            if (IsOwner)
            {
                var vertical = Input.GetAxis("Vertical");
                var horizontal = Input.GetAxis("Horizontal");
                var input = new Vector3(horizontal, 0, vertical);

                transform.position += input * 2f * Time.deltaTime;
                
                _position.Value = transform.position;
            }
            else
            {
                transform.position = _position.Value;
            }
        }
    }
}