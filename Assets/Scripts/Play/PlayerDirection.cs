using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{

    public GameObject clickGroundPrefab;

    private bool isMoving = false;

    public Vector3 targetPoint;

    // Use this for initialization
    void Start()
    {
        targetPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isHit = Physics.Raycast(ray, out hitInfo);

            //点击地面
            if (isHit && hitInfo.collider.tag.Equals(Tags.GROUND))
            {
                ShowClikcEffect(hitInfo.point);

                targetPoint = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }


        if (isMoving)
        {

            transform.LookAt(targetPoint);

        }

    }



    void ShowClikcEffect(Vector3 point)
    {

        GameObject.Instantiate(clickGroundPrefab, new Vector3(point.x, point.y + 0.1f, point.z), Quaternion.identity);

    }
}
