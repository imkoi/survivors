using Unity.Netcode;
using UnityEngine;

namespace Tools.HostMigrationPoC
{
    public class Lobby : MonoBehaviour
    {
        private void Awake()
        {
            NetworkManager.Singleton.OnClientConnectedCallback += v =>
            {
                Debug.Log($"Client[{v}] Connected to server");
            };
            
            NetworkManager.Singleton.OnClientDisconnectCallback += v =>
            {
                Debug.Log($"Client[{v}] Disconnected from server");
            };
        }
    }
}