using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Meta.WitAi;

public class MeditationAudioHandler : MonoBehaviour
{
    private GameObject meditationAudio;
    private AudioSource meditationAudioSource;

    private void Start()
    {
        meditationAudio = GameObject.Find("Meditation Voice Audio");
        meditationAudioSource = meditationAudio.GetComponent<AudioSource>();
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
                Debug.Log("Playing audio");
            }
            else if (sceneString == "pause")
            {
                meditationAudioSource.Pause();
                Debug.Log("Pausing audio");
            }
            else if (sceneString == "continue")
            {
                meditationAudioSource.UnPause();
                Debug.Log("Continuing audio");
            }
            else if (sceneString == "stop")
            {
                meditationAudioSource.Stop();
                Debug.Log("Stopping audio");
            }
        }
    }
}
