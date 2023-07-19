using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    public void pauseButtonClicked()
    {
        pauseMenu.SetActive(pauseMenu.activeSelf ? false: true);
        Time.timeScale = pauseMenu.activeSelf ? 0f : 1.0f;
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1.0f;
        if (sceneName.Equals("MainMenu"))
            GameEvents.instance.ExitToMainMenu();


        SceneTransitioner.instance.FadeToLevel(sceneName);
    }

    public void PlayAudio(string name) { AudioManager.instance.Play(name); }
}
