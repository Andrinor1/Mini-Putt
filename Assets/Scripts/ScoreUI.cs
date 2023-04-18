using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = ScoreKeeper.Instance; // Assign the `gameManager` variable by using the static reference
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
