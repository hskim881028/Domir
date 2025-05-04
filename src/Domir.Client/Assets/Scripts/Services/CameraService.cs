using UnityEngine;

namespace Domir.Client.Services
{
    public sealed class CameraService
    {
        private readonly Camera _mainCamera;
        public CameraService(Camera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        public void SetColor(Color color)
        {
            _mainCamera.backgroundColor = color;
        }
    }
}