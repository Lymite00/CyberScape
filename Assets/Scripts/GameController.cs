using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static GameController instance;
    
    public bool isButtonPressed = false;

    private void Awake()
    {
        instance = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonPressed = false;
    }
}