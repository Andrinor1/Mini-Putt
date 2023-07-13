using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    // The par of each level
    private Dictionary<string, int> levelPars = new Dictionary<string, int> {
        {"Level1-1", 2},
        {"Level1-2", 2},
        {"Level1-3", 4}
    };
    public static ScoreKeeper instance; // A static reference to the GameManager instance
    private int levelGroup = 1; // This is for when we create more levels
    private int strokeCount = 0;
    private Dictionary<string, string> score = new Dictionary<string, string>();

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

        // Subscribing to onBallHit. When the onBallHit event happens, it will callback the increaseStroke method.
        GameEvents.instance.onBallHit += increaseStroke;
        GameEvents.instance.onExitToMainMenu += resetScore;

        // Instantiate score dictionary
        foreach (KeyValuePair<string, int> par in levelPars)
            score[par.Key] = "None";

    }

    void OnDestroy()
    {
        GameEvents.instance.onBallHit -= increaseStroke;
        GameEvents.instance.onExitToMainMenu -= resetScore;
    }

    public void resetScore()
    {
        strokeCount = 0;
        score.Clear();
    }

    public void endLevel()
    {
        score[SceneManager.GetActiveScene().name] = strokeCount.ToString();
        strokeCount = 0;
        if (!FreeplayManager.instance.isFreePlay)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene("Scoreboard");
    }

    public int getPar(string levelName)
    {
        if (!levelPars.ContainsKey(levelName))
            return -1;
        return levelPars[levelName];
    }

    public void increaseStroke() { strokeCount++; }

    public int getStroke() { return strokeCount; }

    public int getLevelGroup() { return levelGroup; }

    public Dictionary<string, int> getPars() { return levelPars; }

    public Dictionary<string, string> getScore() { return score; }
}
