using System;
using Game.Camera.Models;
using Zenject;

namespace Game.Camera.Controllers
{
    public class CameraController : IInitializable, IDisposable
    {
        [Inject] private CameraModel CameraModel { get; }

        private UnityEngine.Camera _mainCamera;

        public void Initialize()
        {
            CameraModel.OnGetMainCamera += HandleOnGetMainCamera;
        }

        public void Dispose()
        {
            CameraModel.OnGetMainCamera -= HandleOnGetMainCamera;
        }

        private UnityEngine.Camera HandleOnGetMainCamera()
        {
            return _mainCamera == null ? _mainCamera = UnityEngine.Camera.main : _mainCamera;
        }
    }
}
