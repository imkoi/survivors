using System.Collections.Generic;
using Fusion;
using UnityEngine;

namespace Tools.MapPoc.Scripts
{
    public class NetworkManagerMapPoc : MonoBehaviour
    {
        [SerializeField] private NetworkRunner _networkRunner;
        [SerializeField] private NetworkEvents _networkEvents;
    
        void Start()
        {
            _networkRunner.StartGame(new StartGameArgs
            {
                GameMode = GameMode.Shared,
                //SessionName = "Koi Session",
                SessionProperties = new Dictionary<string, SessionProperty>(),
                //CustomLobbyName = "Koi Lobby",
                //EnableClientSessionCreation = true,
                PlayerCount = 32,
                IsOpen = true,
                IsVisible = true,
                //MatchmakingMode = MatchmakingMode.SerialMatching,
            });
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
