using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    public event Action onBallHit;
    public event Action onExitToMainMenu;
    public event Action onMousePressed;
    public event Action onMouseReleased;
    public event Action onMouseCancel;

    void Awake()
    {
        if (instance == null) // If there is no instance already
            instance = this;
        else
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
            return;
        }

        DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
    }

    public void BallHit()
    {
        if (onBallHit != null)
            onBallHit();
    }

    public void ExitToMainMenu()
    {
        if (onExitToMainMenu != null)
            onExitToMainMenu();
    }

    public void MousePressed()
    {
        if (onMousePressed != null)
            onMousePressed();
    }

    public void MouseReleased()
    {
        if (onMouseReleased != null)
            onMouseReleased();
    }

    public void MouseCancel()
    {
        if (onMouseCancel != null)
            onMouseCancel();
    }
}
