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

    public void FadeToNextLevel()
    {
        // This is a huge work around simply to get the name of the next scene in build settings
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("nextSceneIndex: " +  nextSceneIndex + " | sceneCount: " + SceneManager.sceneCountInBuildSettings);

        if (nextSceneIndex > SceneManager.sceneCountInBuildSettings)
            nextSceneIndex -= 1;

        string pathToScene = SceneUtility.GetScenePathByBuildIndex(nextSceneIndex);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(pathToScene);
        FadeToLevel(sceneName);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        animator.SetTrigger("FadeIn");
    }
}
