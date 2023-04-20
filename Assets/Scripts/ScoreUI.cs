using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class ScoreUI : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    public TextMeshProUGUI par;
    public TextMeshProUGUI score;

    void Start()
    {
        GameEvents.current.onBallHit += IncreaseScore;
        scoreKeeper = ScoreKeeper.Instance;
        string levelName = SceneManager.GetActiveScene().name;
        par.text += scoreKeeper.getPar(levelName);
        score.text += scoreKeeper.getStroke();
    }

    public void IncreaseScore()
    {
        score.text = Regex.Replace(score.text, @"[\d-]", string.Empty);
        score.text = "Score: " + scoreKeeper.getStroke();
    }
}
