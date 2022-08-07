using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    public bool ButtonIsPressed()
    {
        return buttonPressed;
    }
}
