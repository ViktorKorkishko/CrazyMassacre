using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private PhotonView _view;

    private void Update()
    {
        if (!_view.IsMine)
            return;

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-Time.deltaTime * _speed, 0, 0);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Time.deltaTime * _speed, 0, 0);
    }
}
