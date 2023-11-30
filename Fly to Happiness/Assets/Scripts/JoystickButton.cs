using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool keyPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        keyPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        keyPressed = false;
    }
}
