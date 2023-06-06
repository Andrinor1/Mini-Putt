using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public string note = "MAIN MENU ONLY";
    public static GameEvents current;
    public event Action onBallHit;
    public event Action onExitLevel;
    public event Action onMousePressed;
    public event Action onMouseReleased;

    void Awake()
    {
        if (current == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            current = this;
        }
        else if (current != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }

    public void BallHit()
    {
        if (onBallHit != null)
        {
            onBallHit();
        }
    }

    public void ExitLevel()
    {
        if (onExitLevel != null)
        {
            onExitLevel();
        }
    }

    public void MousePressed()
    {
        if (onMousePressed != null)
        {
            onMousePressed();
        }
    }

    public void MouseReleased()
    {
        if (onMouseReleased != null)
        {
            onMouseReleased();
        }
    }
}
