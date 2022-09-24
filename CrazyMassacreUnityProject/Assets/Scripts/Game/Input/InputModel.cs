using System;
using UnityEngine;

namespace Game.Input.Models
{
    public class InputModel
    {
        public Vector3 MousePosition => OnGetMousePosition != null ? OnGetMousePosition.Invoke() : Vector3.zero;
        public float VerticalAxisInput => OnGetVerticalAxisInput != null ? OnGetVerticalAxisInput.Invoke() : 0;
        public float HorizontalAxisInput => OnGetHorizontalAxisInput != null ? OnGetHorizontalAxisInput.Invoke() : 0;

        public event Func<Vector3> OnGetMousePosition;
        public event Func<float> OnGetVerticalAxisInput;
        public event Func<float> OnGetHorizontalAxisInput;
    }
}
