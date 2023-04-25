using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    public TextMeshProUGUI par;
    public TextMeshProUGUI score;

    void Start()
    {
        GameEvents.current.onBallHit += ChangeScore;
        scoreKeeper = ScoreKeeper.Instance;
        string levelName = SceneManager.GetActiveScene().name;
        par.text += scoreKeeper.getPar(levelName);
        score.text += scoreKeeper.getStroke();
    }

    public void ChangeScore()
    {
        score.text = Regex.Replace(score.text, @"[\d-]", string.Empty);
        score.text = "Score: " + scoreKeeper.getStroke();
    }

    private void OnDestroy()
    {
        GameEvents.current.onBallHit -= ChangeScore;
    }
}
