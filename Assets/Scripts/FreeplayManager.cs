using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeplayManager : MonoBehaviour
{
    private ScoreKeeper scoreKeeper;
    void Start()
    {
        scoreKeeper = ScoreKeeper.Instance;
        scoreKeeper.isFreePlay = false;
    }

    public void toggleFreeplay()
    {
        scoreKeeper.isFreePlay = !scoreKeeper.isFreePlay;
    }
}
