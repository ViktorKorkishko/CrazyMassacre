using Photon.Pun;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private PhotonView _view;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Update()
    {
        if (!_view.IsMine)
            return;
            
        HandleInput();
    }

    private void Move(Vector2 direction)
    {
        _rigidbody.MovePosition(transform.position + new Vector3(direction.x, direction.y) * (_speed * Time.deltaTime));
    }

    private void HandleInput()
    {
        var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical")).normalized;
        Move(direction);
    }
}
