using Fusion;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    [SerializeField] private NetworkRunner _networkRunner;
    [SerializeField] private NetworkEvents _networkEvents;
    
    void Start()
    {
        _networkEvents.OnConnectedToServer.AddListener(nr =>
        {
            Debug.Log($"Connected to server {nr.LobbyInfo.Name}");
        });
        
        _networkRunner.StartGame(new StartGameArgs
        {
            GameMode = GameMode.Shared,
            //ClientTickRate = 64, ClientSendRate = 32, ServerTickRate = 64, ServerSendRate = 32
        });
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
