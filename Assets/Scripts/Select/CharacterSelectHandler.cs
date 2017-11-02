using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectHandler : MonoBehaviour
{

    public GameObject[] CharacterGameObject;

    private int _selectedIndex = 0;

    private GameObject[] _characterInstance;

    public UIInput CharacterName;

    public const string CHARACTER_SELECTED_INDEX = "CHARACTER_SELECTED_INDEX";

    public const string CHARACTER_NAME = "CHARACTER_NAME";

    // Use this for initialization
    void Start()
    {
        if (CharacterGameObject != null)
        {
            _characterInstance = new GameObject[CharacterGameObject.Length];
            for (int i = 0; i < _characterInstance.Length; i++)
            {
                _characterInstance[i] = Instantiate(CharacterGameObject[i], transform.position, transform.rotation);
            }
        }

        UpdateSelectCharacter();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void SelectPreCharacter()
    {
        _selectedIndex = Math.Abs((--_selectedIndex) % _characterInstance.Length);
        
        UpdateSelectCharacter();
    }

    public void SelectNextCharacter()
    {
        _selectedIndex = (++_selectedIndex) % _characterInstance.Length;
        UpdateSelectCharacter();
    }


    public void SaveSelectedCharacter()
    {
        PlayerPrefs.SetInt(CHARACTER_SELECTED_INDEX, _selectedIndex);
        PlayerPrefs.SetString(CHARACTER_NAME, CharacterName.value);

    }

    private void UpdateSelectCharacter()
    {

        for (int i = 0; i < _characterInstance.Length; i++)
        {
            _characterInstance[i].SetActive(i == _selectedIndex);

        }
    }
}
