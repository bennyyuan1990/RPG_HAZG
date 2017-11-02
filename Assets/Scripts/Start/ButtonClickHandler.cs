using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{

    private bool _isKeyDown = false;
    private GameObject _buttonMenu;

    void Start()
    {
        _buttonMenu = transform.parent.Find("ButtonContainer").gameObject;
    }


    // Update is called once per frame
    void Update()
    {

        if (!_isKeyDown)
        {

            if (Input.anyKey)
            {
                Debug.Log("ButtonClickHandler");
                _isKeyDown = true;

                _buttonMenu.SetActive(true);
                gameObject.SetActive(false);
                Destroy(this);
            }
        }

    }
}
