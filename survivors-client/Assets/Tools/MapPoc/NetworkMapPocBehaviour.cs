using Tools.HostMigrationPoC;
//using Unity.Netcode;
using UnityEngine;

namespace Tools.Common
{
    public class NetworkMapPocBehaviour : MonoBehaviour
    {
        [SerializeField] 
        private LobbyMapPoc _lobbyPrefab;
        
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