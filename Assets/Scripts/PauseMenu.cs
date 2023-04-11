using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Mathf.MoveTowards(Time.timeScale, 0, Time.deltaTime);
        // Time.timeScale = .05f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1.0f;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
