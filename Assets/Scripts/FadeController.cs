using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Meta.WitAi;

public class FadeController : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup fadeCanvas; //Inspector Field for Canvas that holds black image for fade screen

    private bool fadeToBlack = false;
    private bool fadeToTransparent = false;

    private const float fadeSpeed = 1f; //speed, at which fade should be executed

    private GameObject activeScene; //GameObject for Meditation Scene Handler

    private GameObject meditationAudio; //GameObject for Meditation Voice Audio 2
    private AudioSource meditationAudioSource; //AudioSource of meditationAudio GameObject

    private GameObject MeditationMenu;//GameObject for Meditation Menu Handler

    private void Start()
    {
        activeScene = GameObject.Find("Meditation Scene Handler");
        meditationAudio = GameObject.Find("Meditation Voice Audio 2");
        meditationAudioSource = meditationAudio.GetComponent<AudioSource>();
        MeditationMenu = GameObject.Find("Meditation Menu Handler");
    }

    /// <summary>
    /// PauseMeditationAudio() pauses the meditationAudioSource for 5 seconds (a little bit longer then the fade duration) and unpauses it afterwards. 
    /// </summary>
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
            fadeCanvas.alpha += fadeSpeed * Time.deltaTime; //changes alphaValue of Canvas GameObject gradually to 1f
            if (fadeCanvas.alpha >= 1f)
            {
                fadeToBlack = false; //resets fadeToTransparent bool to false as soon as an alphaValue of 1f is reached
            }
        }

        if (fadeToTransparent)
        {
            fadeCanvas.alpha -= fadeSpeed * Time.deltaTime; //changes alphaValue of Canvas GameObject gradually to 0f
            if (fadeCanvas.alpha <= 0f)
            {
                fadeToTransparent = false; //resets fadeToTransparent bool to false as soon as an alphaValue of 0f is reached
            }
        }
    }
    /// <summary>
    /// Checks wether the string that is captured through the microphone corresponds to close/open
    /// in order to set the variable to be used by the Update function. If the string[] values is "close", fadeToBlack is set to true and as a 
    /// precaution all SetupMenus are closed by calling the CloseAllSetupMenus() function of the MeditationMenuHandler. If it is "open", fadeToTransparent is
    /// set to true, the Coroutinge PauseMeditationAudio() executes and the function ActivateScene() from the MeditationEnvironmentHandler is called.
    /// </summary>
    /// <param name="values">String values that are returned from Wit.ai</param>
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

