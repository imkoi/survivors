using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace Tools.HostMigrationPoC
{
    public class DisconnectButtonBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }
        
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }
        
        private void OnClick()
        {
            NetworkManager.Singleton.Shutdown();
        }
    }
}