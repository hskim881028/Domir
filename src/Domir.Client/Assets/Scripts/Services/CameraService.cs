using Domir.Client.Core.Component;
using UnityEngine;

namespace Domir.Client.Services
{
    public sealed class CameraService
    {
        private readonly CameraSet _cameraSet;

        public Camera MainCamera => _cameraSet.MainCamera;
        public Camera UICamera => _cameraSet.UICamera;

        public CameraService(CameraSet cameraSet)
        {
            _cameraSet = cameraSet;
        }

        public void SetColor(Color color)
        {
            _cameraSet.MainCamera.backgroundColor = color;
        }
    }
}