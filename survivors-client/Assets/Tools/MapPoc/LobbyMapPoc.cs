using Fusion;
using UnityEngine;

namespace Tools.HostMigrationPoC
{
    public class LobbyMapPoc : SimulationBehaviour, IPlayerJoined
    {
        [SerializeField] private GameObject _playerPrefab;
        
        public void PlayerJoined(PlayerRef player)
        {
            Debug.Log("PlayerJoined");
            
            if (player == Runner.LocalPlayer)
            {
                Runner.Spawn(_playerPrefab);
            }
        }
    }
}