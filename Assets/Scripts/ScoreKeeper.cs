using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance; // A static reference to the GameManager instance
    private int strokeCount = 0;
    private List<int> score = new List<int>();

    void Awake()
    {
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
}
