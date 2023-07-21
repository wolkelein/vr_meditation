using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Meta.WitAi;

public class MeditationAudioHandler : MonoBehaviour
{
    private GameObject meditationAudio;
    private AudioSource meditationAudioSource;
    private GameObject MeditationMenu;
    

    private void Start()
    {
        meditationAudio = GameObject.Find("Meditation Voice Audio 2");
        meditationAudioSource = meditationAudio.GetComponent<AudioSource>();
        MeditationMenu = GameObject.Find("Meditation Menu Handler");
    }

    public void PlayMeditation(string[] values)
    {
        var sceneString = values[0];

        // Check the value of sceneString and switch scenes accordingly
        if (!string.IsNullOrEmpty(sceneString))
        {
            // Check the value of sceneString and switch scenes accordingly
            if (sceneString == "start" || sceneString == "Start" || sceneString == "play")
            {
                meditationAudioSource.Play();
                MeditationMenu.GetComponent<MeditationMenuHandler>().ExitMenu();
            }
            else if (sceneString == "pause")
            {
                meditationAudioSource.Pause();
            }
            else if (sceneString == "continue")
            {
                meditationAudioSource.UnPause();
            }
            else if (sceneString == "stop")
            {
                meditationAudioSource.Stop();
            }
        }
    }
}
