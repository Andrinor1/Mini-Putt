using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject menu;

    public void Play()
    {
        // Just loads the 1st level. This is just placeholder code for now.
        SceneManager.GetSceneAt(1);
    }

    public void OnApplicationQuit()
    {
        SceneManager.GetSceneAt(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
