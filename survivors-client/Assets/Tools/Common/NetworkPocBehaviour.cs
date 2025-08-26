using Tools.HostMigrationPoC;
//using Unity.Netcode;
using UnityEngine;

namespace Tools.Common
{
    public class NetworkPocBehaviour : MonoBehaviour
    {
        [SerializeField] 
        private Lobby _lobbyPrefab;
        
        private void Awake()
        {
            //Instantiate(_lobbyPrefab);
            
            // if (!Unity.Multiplayer.Playmode.CurrentPlayer.IsMainEditor)
            // {
            //     NetworkManager.Singleton.StartHost();
            // }
            // else
            // {
            //     NetworkManager.Singleton.StartClient();
            // }
        }
    }
}