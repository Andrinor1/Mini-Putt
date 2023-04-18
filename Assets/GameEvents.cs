using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    // TODO Edit the ClickAndDrag to do events.
    void Awake()
    {
        current = this;
    }

    public event Action onScoreKeeperIncreaseStroke;
    public void ScoreKeeperIncreaseStroke()
    {
        if (onScoreKeeperIncreaseStroke != null)
        {
            onScoreKeeperIncreaseStroke();
        }
    }
}
