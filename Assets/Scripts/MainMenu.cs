using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static string NOTE = "Loading '<LevelName>Freeplay' loads the level in freeplay mode.";
    public void LoadScene(string sceneName)
    {
        int freeplayIndex = sceneName.IndexOf("Freeplay");

        if (freeplayIndex == -1)
            SceneTransitioner.instance.FadeToLevel(sceneName);
        else
        {
            FreeplayManager.instance.isFreePlay = true;
            SceneTransitioner.instance.FadeToLevel(sceneName.Substring(0, freeplayIndex));
        }
    }

    public void PlayAudio(string name) { AudioManager.instance.Play(name); }

    public void Quit() { Application.Quit(); }
}
