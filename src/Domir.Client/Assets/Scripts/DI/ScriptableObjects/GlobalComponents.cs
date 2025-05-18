using Domir.Client.Core.Component;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.U2D;

namespace Domir.Client.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GlobalComponents", menuName = "ScriptableObjects/GlobalComponents")]
    public class GlobalComponents : ScriptableObject
    {
        [SerializeField] private InputActionAsset _inputAction;
        [SerializeField] private NetworkManager _networkManager;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private CameraSet _cameraSet;
        [SerializeField] private Light2DBase _globalLight;

        public InputActionAsset InputAction => _inputAction;

        public NetworkManager NetworkManager => _networkManager;

        public EventSystem EventSystem => _eventSystem;

        public CameraSet CameraSet => _cameraSet;

        public Light2DBase GlobalLight => _globalLight;
    }
}