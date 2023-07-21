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
                if (activeScene.name=="OceanScene(Clone)")
                {
                    meditationAudioSource.clip = femaleOceanAudio;
                }
                else if (activeScene.name == "GardenScene(Clone)")
                {
                    meditationAudioSource.clip = femaleGardenAudio;
                }
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu4();
            }
            if (sceneString == "male")
            {
                if (activeScene.name == "OceanScene(Clone)")
                {
                    meditationAudioSource.clip = maleOceanAudio;
                }
                else if (activeScene.name == "GardenScene(Clone)")
                {
                    meditationAudioSource.clip = maleGardenAudio;
                }
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu4();
            }
        }
    }
}
