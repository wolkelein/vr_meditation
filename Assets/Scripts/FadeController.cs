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

    private GameObject activeScene;

    private GameObject meditationAudio;
    private AudioSource meditationAudioSource;

    private GameObject MeditationMenu;

    private void Start()
    {
        activeScene = GameObject.Find("Meditation Scene Handler");
        meditationAudio = GameObject.Find("Meditation Voice Audio 2");
        meditationAudioSource = meditationAudio.GetComponent<AudioSource>();
        MeditationMenu = GameObject.Find("Meditation Menu Handler");
    }

    IEnumerator PauseMeditationAudio()
    {
        meditationAudioSource.Pause();
        yield return new WaitForSeconds(5);
        meditationAudioSource.UnPause();
    }

    private void Update()
    {
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
                MeditationMenu.GetComponent<MeditationMenuHandler>().CloseAllSetupMenus();
            }
            else if (sceneString == "open")
            {
                StartCoroutine(PauseMeditationAudio());
                fadeToTransparent = true;
                activeScene.GetComponent<MeditationEnvironmentHandler>().ActivateScene();
            }
        }
    }
}

