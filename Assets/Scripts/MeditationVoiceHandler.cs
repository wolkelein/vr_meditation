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

    private void Start()
    {
        meditationAudioSource = GameObject.Find("Meditation Voice Audio 2").GetComponent<AudioSource>();
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
                if (GameObject.Find("OceanScene(Clone)") != null)
                {
                    meditationAudioSource.clip = femaleOceanAudio;
                }
                else if (GameObject.Find("GardenScene(Clone)") != null)
                {
                    meditationAudioSource.clip = femaleGardenAudio;
                }
            }
            if (sceneString == "male")
            {
                if (GameObject.Find("OceanScene(Clone)") != null)
                {
                    meditationAudioSource.clip = maleOceanAudio;
                }
                else if (GameObject.Find("GardenScene(Clone)") != null)
                {
                    meditationAudioSource.clip = maleGardenAudio;
                }
            }
        }
    }
}
