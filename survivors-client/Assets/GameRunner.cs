using System.Collections;
using System.Collections.Generic;
using Fusion;
using Fusion.Photon.Realtime;
using Survivors.Core.Loading;
using UnityEngine;

namespace Survivors
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private NetworkRunner _networkRunner;
        [SerializeField] private LoadingStep _loading;
        
        private void Awake()
        {
            _networkRunner.StartGame(new StartGameArgs
            {
                SessionName = "Koi Session",
                SessionProperties = new Dictionary<string, SessionProperty>(),
                CustomLobbyName = "Koi Lobby",
                EnableClientSessionCreation = true,
                PlayerCount = 32,
                IsOpen = true,
                IsVisible = true,
                MatchmakingMode = MatchmakingMode.SerialMatching,
            });
            
            //_networkRunner.
        }

        private IEnumerator StartGame()
        {
            yield return StartCoroutine(_loading.Schedule());
            
            Debug.Log("game loaded");
        }
    }
}