using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeplayManager : MonoBehaviour
{
    public static FreeplayManager instance;
    private ScoreKeeper scoreKeeper;
    public bool isFreePlay = false;


    void Start()
    {
        if (instance == null) // If there is no instance already
            instance = this;
        else
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
            return;
        }
        DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes

        GameEvents.instance.onExitToMainMenu += resetFreeplay;

        scoreKeeper = ScoreKeeper.instance;
        isFreePlay = false;
    }

    void OnDestroy()
    {
        GameEvents.instance.onExitToMainMenu += resetFreeplay;
    }

    public void toggleFreeplay()
    {
        isFreePlay = !isFreePlay;
    }

    public void resetFreeplay()
    {
        isFreePlay = false;
    }
}
