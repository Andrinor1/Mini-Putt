using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public static SceneTransitioner instance;
    public Animator animator;

    private string levelToLoad;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void FadeToLevel(string levelName)
    {
        Debug.Log("Fading to Level " +  levelName);
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void FadeToNextLevel() { FadeToLevel(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name); }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        animator.SetTrigger("FadeIn");
    }
}
