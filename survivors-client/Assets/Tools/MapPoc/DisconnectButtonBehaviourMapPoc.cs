//using Unity.Netcode;

using Fusion;
using UnityEngine;
using UnityEngine.UI;

namespace Tools.HostMigrationPoC
{
    public class DisconnectButtonBehaviourMapPoc : MonoBehaviour
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
            FindAnyObjectByType<NetworkRunner>().Shutdown();
        }
    }
}