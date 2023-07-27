using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Meta.WitAi;

public class MeditationVoiceHandler : MonoBehaviour
{
    /// <summary>
    /// Inspector Fields for the Audio Clips for the Meditation Audio (female and male for each scene seperately)
    /// </summary>
    [SerializeField]
    private AudioClip femaleOceanAudio;

    [SerializeField]
    private AudioClip maleOceanAudio;

    [SerializeField]
    private AudioClip femaleGardenAudio;

    [SerializeField]
    private AudioClip maleGardenAudio;

    private AudioSource meditationAudioSource; //AudioSource of Meditation Voice Audio 2 GameObject

    private GameObject MeditationMenu; //GameObject for Meditation Menu Handler

    private GameObject activeScene; //GameObject to hold the current scene

    private void Start()
    {
        meditationAudioSource = GameObject.Find("Meditation Voice Audio 2").GetComponent<AudioSource>();
        MeditationMenu = GameObject.Find("Meditation Menu Handler");
        activeScene = GameObject.Find("Meditation Scene Handler");
    }

    public void Update()
    {
        activeScene.GetComponent<MeditationEnvironmentHandler>().ShowActiveScene();
    }

    /// <summary>
    /// Sets the meditationAudioSource Clip depending on the string[] values and the activeScene (this is found through the 
    /// ShowActiveScene() function of the MeditationEnvironmentHandler. Calls the ChangeToSetupMenu4() function of the 
    /// MeditationMenuHandler.
    /// </summary>
    /// <param name="values">String values that are returned from Wit.ai</param>
    public void SetMeditationVoice(string[] values)
    {
        var sceneString = values[0];

        // Check the value of sceneString and switch scenes accordingly
        if (!string.IsNullOrEmpty(sceneString))
        {
            // Check the value of sceneString and switch scenes accordingly
            if (sceneString == "female")
            {
                if (activeScene.GetComponent<MeditationEnvironmentHandler>().ShowActiveScene() == "OceanScene(Clone)")
                {
                    meditationAudioSource.clip = femaleOceanAudio;
                }
                else if (activeScene.GetComponent<MeditationEnvironmentHandler>().ShowActiveScene() == "GardenScene(Clone)")
                {
                    meditationAudioSource.clip = femaleGardenAudio;
                }
                else
                {

                }
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu4();
            }
            else if (sceneString == "male")
            {
                if (activeScene.GetComponent<MeditationEnvironmentHandler>().ShowActiveScene() == "OceanScene(Clone)")
                {
                    meditationAudioSource.clip = maleOceanAudio;
                }
                else if (activeScene.GetComponent<MeditationEnvironmentHandler>().ShowActiveScene() == "GardenScene(Clone)")
                {
                    meditationAudioSource.clip = maleGardenAudio;
                }
                else
                {

                }
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu4();
            }
        }
    }
}
