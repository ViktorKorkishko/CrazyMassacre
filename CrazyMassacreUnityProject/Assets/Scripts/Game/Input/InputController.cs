using System;
using Game.Input.Models;
using UnityEngine;
using Zenject;

namespace Game.Input.Controllers
{
    public class InputController : IInitializable, IDisposable
    {
        [Inject] private InputModel InputModel { get; }

        public void Initialize()
        {
            InputModel.OnGetMousePosition += HandleOnGetMousePosition;
            InputModel.OnGetHorizontalAxisInput += HandleOnGetHorizontalAxisInput;
            InputModel.OnGetVerticalAxisInput += HandleOnGetVerticalAxisInput;
        }

        public void Dispose()
        {
            InputModel.OnGetMousePosition -= HandleOnGetMousePosition;
            InputModel.OnGetHorizontalAxisInput -= HandleOnGetHorizontalAxisInput;
            InputModel.OnGetVerticalAxisInput -= HandleOnGetVerticalAxisInput;
        }

        private Vector3 HandleOnGetMousePosition() => UnityEngine.Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        private float HandleOnGetHorizontalAxisInput() => UnityEngine.Input.GetAxis("Horizontal");
        private float HandleOnGetVerticalAxisInput() => UnityEngine.Input.GetAxis("Vertical");
    }
}
