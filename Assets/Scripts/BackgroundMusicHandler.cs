using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi;

public class BackgroundMusicHandler : MonoBehaviour
{
    [SerializeField]
    private AudioClip backgroundMusic1;

    [SerializeField]
    private AudioClip backgroundMusic2;

    private GameObject backgroundMusic;
    private AudioSource backgroundAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GameObject.Find("Background Audio");
        backgroundAudioSource = backgroundMusic.GetComponent<AudioSource>();
    }

    public void UpdateBackgroundAudio(string[] values)
    {
        var sceneString = values[0];

        // Check the value of sceneString and switch scenes accordingly
        if (!string.IsNullOrEmpty(sceneString))
        {
            if (sceneString == "music one")
            {
                backgroundAudioSource.clip = backgroundMusic1;
                backgroundAudioSource.Play();
            }
            else if (sceneString == "music two")
            {
                backgroundAudioSource.clip = backgroundMusic2;
                backgroundAudioSource.Play();
            }
        }
    }
}
