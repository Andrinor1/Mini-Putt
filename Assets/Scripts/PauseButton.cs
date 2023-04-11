using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenu;

    public void pauseButtonClicked()
    {
        pauseMenu.SetActive(pauseMenu.activeSelf ? false: true);
    }
}
