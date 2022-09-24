using Game.Camera.Models;
using Game.Input.Models;
using Game.Player.Movement.Models;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Game.Player.Movement.Controllers
{
    public class PlayerMovementController : ITickable
    {
        [Inject] private InputModel InputModel { get; }
        [Inject] private CameraModel CameraModel { get; }
        [Inject] private PlayerMovementModel PlayerMovementModel { get; }

        [Inject] private PhotonView PhotonView { get; }
        [Inject] private Rigidbody2D Rigidbody { get; }

        private UnityEngine.Camera MainCamera => CameraModel.GetMainCamera();
        private bool IsControlledByThisClient => PhotonView.IsMine;

        public void Tick()
        {
            if (!IsControlledByThisClient)
                return;

            HandleInput();
        }

        private void Move(Vector2 direction)
        {
            Rigidbody.MovePosition(Rigidbody.transform.position + new Vector3(direction.x, direction.y) * (PlayerMovementModel.Speed * Time.deltaTime));
        }

        private void Rotate()
        {
            Vector2 mousePosition = MainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

            Vector2 lookDirection = mousePosition - Rigidbody.position;

            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg/* - 90f*/;
            Rigidbody.rotation = angle;
        }

        private void HandleInput()
        {
            var direction = new Vector2(InputModel.HorizontalAxisInput, InputModel.VerticalAxisInput).normalized;
            Move(direction);
            Rotate();
        }
    }
}
