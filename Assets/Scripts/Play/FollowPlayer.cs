using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public float scrollSpeed = 1;
    public float rotateSpeed = 10;

    private Transform _playerTransform;
    private Vector3 _offset;

    private bool _isRotating = false;


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
       
        UpdateRotateView();

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



    void UpdateRotateView()
    {
        float moveX = Input.GetAxis("Mouse X");
        float moveY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(1))
        {
            _isRotating = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isRotating = false;
        }


        if (_isRotating)
        {
            transform.RotateAround(_playerTransform.position, _playerTransform.up, rotateSpeed * moveX);

            Vector3 oldPositon = transform.position;
            Quaternion oldQuaternion = transform.rotation;

            transform.RotateAround(_playerTransform.position, transform.right, rotateSpeed * moveY);

            Vector3 newRotation = transform.eulerAngles;
            if (newRotation.x < 10 || newRotation.x > 70)
            {
                transform.position = oldPositon;
                transform.rotation = oldQuaternion;
            }
        }

        _offset = transform.position - _playerTransform.position;
    }
}
