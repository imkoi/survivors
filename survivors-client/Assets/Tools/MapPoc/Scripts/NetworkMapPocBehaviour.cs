using UnityEngine;

namespace Tools.MapPoc.Scripts
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