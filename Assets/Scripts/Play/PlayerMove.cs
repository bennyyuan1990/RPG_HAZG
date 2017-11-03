using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    public enum PlayerStatus
    {
        Idle,
        Moving
    }


    private PlayerDirection _playerDirection;

    public float speed = 1;
    private CharacterController _characterController;
    public PlayerStatus playerStatus;

    // Use this for initialization
    void Start()
    {
        _playerDirection = GetComponent<PlayerDirection>();
        _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        double distance = Vector3.Distance(_playerDirection.targetPoint, transform.position);

        if (distance > 0.1f)
        {
            playerStatus = PlayerStatus.Moving;
            _characterController.SimpleMove(transform.forward * speed);
        }
        else
        {
            playerStatus = PlayerStatus.Idle;
        }

    }
}
