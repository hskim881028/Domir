using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VContainer;

namespace Domir.Client.Core.Component
{
    public class CameraSet : MonoBehaviour
    {
        public Camera MainCamera { get; private set; }
        public Camera UICamera { get; private set; }

        [Inject]
        public void Construct()
        {
            var cameras = GetComponentsInChildren<Camera>();
            foreach (var cam in cameras)
            {
                switch (cam.GetUniversalAdditionalCameraData().renderType)
                {
                    case CameraRenderType.Base:
                        MainCamera = cam;
                        break;
                    case CameraRenderType.Overlay:
                        UICamera = cam;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}