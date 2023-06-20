using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PromptManager : MonoBehaviour
{
    public Image videoBorder;
    public RawImage videoHolder;
    public VideoPlayer videoPlayer;
    public float timeUntilPrompt = 4f;
    public float fadeSpeed = 1f;
    private bool fadedIn = false;
    private bool mouseClicked = false;
    private float currentTime = 0f;


    void Start()
    {
        GameEvents.instance.onMousePressed += OnMouseDown;
    }

    void OnDestroy()
    {
        GameEvents.instance.onMousePressed -= OnMouseDown;
    }

    // Update is called once per frame
    void Update()
    {
        // If the mouse has been clicked, then don't display the prompt
        if (!mouseClicked)
        {

            // Getting the current time since the scene was loaded
            currentTime = Time.timeSinceLevelLoad;

            // If enough time has passed, then fade in the prompt and play the video tutorial
            if (currentTime > timeUntilPrompt)
            {
                if (!fadedIn)
                    StartCoroutine(FadeImage(false));
                videoPlayer.Play();
            }
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                // set color with i as alpha
                videoHolder.color = new Color(1, 1, 1, i);
                videoBorder.color = new Color(0, 0, 0, i);
                yield return null;
            }
            fadedIn = false;
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
            {
                // set color with i as alpha
                videoHolder.color = new Color(1, 1, 1, i);
                videoBorder.color = new Color(0, 0, 0, i);
                yield return null;
            }
            fadedIn = true;
        }
    }

    public void OnMouseDown()
    {
        // If the mouse was clicked, then set it to true, which prevents the prompt from showing again
        mouseClicked = true;

        // If we haven't faded away yet, then do so
        if (fadedIn)
            StartCoroutine(FadeImage(true));

        videoPlayer.Stop();
    }
}
