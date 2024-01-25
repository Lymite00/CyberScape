using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    [SerializeField] private TextMeshProUGUI skin1;
    [SerializeField] private TextMeshProUGUI skin2;
    [SerializeField] private TextMeshProUGUI skin3;

    private void Start()
    {
        skin1.gameObject.SetActive(true);
        skin2.gameObject.SetActive(false);
        skin3.gameObject.SetActive(false);
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter<0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void ChangeCharSkin()
    {
        if (selectedCharacter==0)
        {
            skin1.gameObject.SetActive(true);
            skin2.gameObject.SetActive(false);
            skin3.gameObject.SetActive(false);
        }
        else if (selectedCharacter==1)
        {
            skin1.gameObject.SetActive(false);
            skin3.gameObject.SetActive(false);
            skin2.gameObject.SetActive(true);
        }
        else if (selectedCharacter==2)
        {
            skin1.gameObject.SetActive(false);
            skin3.gameObject.SetActive(true);
            skin2.gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter",selectedCharacter);
    }
}
