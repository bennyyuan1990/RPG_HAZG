using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animation _animation;
    private PlayerMove _playerMove;

    // Use this for initialization
    void Start()
    {
        _animation = GetComponent<Animation>();
        _playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_playerMove.playerStatus == PlayerMove.PlayerStatus.Idle)
        {
            _animation.Play("Idle");
        }
        else if (_playerMove.playerStatus == PlayerMove.PlayerStatus.Moving)
        {

            _animation.Play("Walk");
        }
    }
}
