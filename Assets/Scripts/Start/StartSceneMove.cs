using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneMove : MonoBehaviour
{
    private float _endZ = -20;

    public float speed = 10;


    void Update()
    {
        if (transform.position.z < _endZ)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }
}
