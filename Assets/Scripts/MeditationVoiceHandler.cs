using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Meta.WitAi;

public class MeditationVoiceHandler : MonoBehaviour
{
    [SerializeField]
    private AudioClip femaleOceanAudio;

    [SerializeField]
    private AudioClip maleOceanAudio;

    [SerializeField]
    private AudioClip femaleGardenAudio;

    [SerializeField]
    private AudioClip maleGardenAudio;

    private AudioSource meditationAudioSource;

    private GameObject MeditationMenu;

    private GameObject activeScene;

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
                    Debug.LogWarning("Scene name not recognized.");
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
                    Debug.LogWarning("Scene name not recognized.");
                }
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu4();
            }
        }
    }
}
