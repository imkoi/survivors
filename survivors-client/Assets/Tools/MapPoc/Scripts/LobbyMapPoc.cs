using Fusion;
using UnityEngine;

namespace Tools.MapPoc.Scripts
{
    public class LobbyMapPoc : SimulationBehaviour, IPlayerJoined
    {
        [SerializeField] private GameObject _playerPrefab;
        
        public void PlayerJoined(PlayerRef playerRef)
        {
            Debug.Log($"[LobbyMapPoc][PlayerJoined] playerRef={playerRef.PlayerId}");
            
            if (playerRef == Runner.LocalPlayer)
            {
                Runner.Spawn(_playerPrefab);
            }
        }
    }
}