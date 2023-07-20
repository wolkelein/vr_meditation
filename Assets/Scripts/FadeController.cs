using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Meta.WitAi;

public class FadeController : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup fadeCanvas;

    [SerializeField]
    private bool fadeToBlack = false;

    [SerializeField]
    private bool fadeToTransparent = false;

    private const float fadeSpeed = 1f;

    private GameObject meditationScene;
    private GameObject environment;

    //private Renderer

    private void Start()
    {
    }

    private void Update()
    {
        if (GameObject.Find("OceanScene(Clone)") != null)
        {
            meditationScene = GameObject.Find("OceanScene(Clone)");
        }
        else if (GameObject.Find("GardenScene(Clone)") != null)
        {
            meditationScene = GameObject.Find("GardenScene(Clone)");
        }

        if (fadeToBlack)
        {
            fadeCanvas.alpha += fadeSpeed * Time.deltaTime;
            if (fadeCanvas.alpha >= 1f)
            {
                fadeToBlack = false;
            }
        }

        if (fadeToTransparent)
        {
            fadeCanvas.alpha -= fadeSpeed * Time.deltaTime;
            if (fadeCanvas.alpha <= 0f)
            {
                fadeToTransparent = false;
            }
        }
    }
    /// <summary>
    /// Checks wether the string that is captured through the microphone corresponds to close/open
    /// in order to set the variable to be used by the Update function.
    /// </summary>
    /// <param name="values"></param>
    public void FadeScreen(string[] values)
    {
        var sceneString = values[0];

        if (!string.IsNullOrEmpty(sceneString))
        {
            if (sceneString == "close")
            {
                fadeToBlack = true;
                meditationScene.SetActive(false);
            }
            else if (sceneString == "open")
            {
                fadeToTransparent = true;
                meditationScene.SetActive(true);
            }
        }
    }
}

