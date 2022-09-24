using System;
using UnityEngine;

namespace Game.Camera.Models
{
    public class CameraModel
    {
        public event Func<UnityEngine.Camera> OnGetMainCamera;

        public UnityEngine.Camera GetMainCamera() => OnGetMainCamera?.Invoke();
    }
}
