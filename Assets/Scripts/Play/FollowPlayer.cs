using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private Transform _playerTransform;
    private Vector3 _offset;
    public float scrollSpeed = 1;


    // Use this for initialization
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;

        transform.LookAt(_playerTransform.position);
        _offset = transform.position - _playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _offset + _playerTransform.position;
        UpdateScrollView();
    }


    void UpdateScrollView()
    {
        float step = Input.GetAxis("Mouse ScrollWheel");//鼠标滚轮向前：正值，鼠标滚轮向后：负值

        float distance = _offset.magnitude;
        distance = distance + step * scrollSpeed;

        if (distance > 2 && distance < 18)
        {
            _offset = _offset.normalized * distance;

        }


    }
}
