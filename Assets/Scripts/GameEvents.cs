using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public string note = "MAIN MENU ONLY";
    public static GameEvents current;
    public event Action onBallHit;

    void Awake()
    {
        current = this;
        DontDestroyOnLoad(this);
    }

    public void BallHit()
    {
        if (onBallHit != null)
        {
            onBallHit();
        }
    }
}
