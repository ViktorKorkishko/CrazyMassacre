using System;
using Game.Resolution.Models;
using UnityEngine;
using Zenject;

namespace Game.Resolution.Controllers
{
    public class ResolutionController : IInitializable, IDisposable
    {
        [Inject] private ResolutionModel ResolutionModel { get; }

        public void Initialize()
        {
#if UNITY_STANDALONE_WIN
            SetupWindowsDebugScreen();
#endif
        }

        public void Dispose()
        {

        }

        private void SetupWindowsDebugScreen()
        {
            var fullscreenMode = FullScreenMode.Windowed;
            var targetResolution = new UnityEngine.Resolution()
            {
                width = 1280,
                height = 720,
                refreshRate = 60,
            };

            SetResolution(targetResolution, fullscreenMode);
        }

        private void SetResolution(UnityEngine.Resolution resolution, FullScreenMode fullScreenMode)
        {
            Screen.SetResolution(resolution.width, resolution.height, fullScreenMode, resolution.refreshRate);
        }
    }
}
