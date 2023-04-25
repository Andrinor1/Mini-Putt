using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

enum LevelPars
{
    // Changes to this enum should also reflect on the findPar() method in ScoreUI
    // Currently changing this to a dictionary, refer to the code below
    Level1 = 1,
    Level2 = 2,
    Level3 = 3,
    ScoreUI = 99
}

public class ScoreKeeper : MonoBehaviour
{
    public string note = "MAIN MENU ONLY";
    // The par of each level
    private Dictionary<string, int> levelPars = new Dictionary<string, int> {
        {"Level1", 1},
        {"Level2", 2},
        {"Level3", 3},
        {"ScoreUI", 99}
    };
    public static ScoreKeeper Instance; // A static reference to the GameManager instance
    private int strokeCount = 0;
    private List<int> score = new List<int>();

    void Start()
    {
        // Subscribing to onBallHit. When the onBallHit event happens, it will callback the increaseStroke method.
        GameEvents.current.onBallHit += increaseStroke;
        GameEvents.current.onExitLevel += resetScore;

        if (Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }

    public void increaseStroke()
    {
        strokeCount++;
    }

    public void resetScore()
    {
        strokeCount = 0;
        score.Clear();
    }

    public void endLevel()
    {
        score.Add(strokeCount);
        strokeCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public int getStroke()
    {
        return strokeCount;
    }

    public int getPar(string levelName)
    {
        if (!levelPars.ContainsKey(levelName))
            return -1;
        return levelPars[levelName];
    }
}
