using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    bool mouseCancelled = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouseCancelled = true;
            GameEvents.current.MouseCancel();
        }
    }
    public void OnMouseDown()
    {
        if (!mouseCancelled)
            GameEvents.current.MousePressed();
        Debug.Log("Mouse Pressed");
    }

    public void OnMouseUp()
    {
        if (!mouseCancelled)
            GameEvents.current.MouseReleased();
        else
            mouseCancelled = false;
        Debug.Log("Mouse Released");
    }
}
