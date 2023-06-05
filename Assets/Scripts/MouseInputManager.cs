using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    public void OnMouseDown()
    {
        GameEvents.current.MousePressed();
        Debug.Log("Mouse Pressed");
    }

    public void OnMouseUp()
    {
        GameEvents.current.MouseReleased();
        Debug.Log("Mouse Released");
    }
}
