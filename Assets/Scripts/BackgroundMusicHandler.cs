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

    private GameObject MeditationMenu;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GameObject.Find("Background Audio");
        backgroundAudioSource = backgroundMusic.GetComponent<AudioSource>();
        MeditationMenu = GameObject.Find("Meditation Menu Handler");
    }

    IEnumerator BackgroundMusicTrial()
    {
        backgroundAudioSource.Play();
        yield return new WaitForSeconds(3);
        backgroundAudioSource.Stop();
    }

        public void UpdateBackgroundAudio(string[] values)
    {
        var sceneString = values[0];

        // Check the value of sceneString and switch scenes accordingly
        if (!string.IsNullOrEmpty(sceneString))
        {
            if (sceneString == "Try one")
            {
                backgroundAudioSource.clip = backgroundMusic1;
                StartCoroutine(BackgroundMusicTrial());
            }
            else if (sceneString == "Try two")
            {
                backgroundAudioSource.clip = backgroundMusic2;
                StartCoroutine(BackgroundMusicTrial());
            }
            else if (sceneString == "Set one")
            {
                backgroundAudioSource.clip = backgroundMusic1;
                backgroundAudioSource.Play();
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu2();
            }
            else if (sceneString == "Set two")
            {
                backgroundAudioSource.clip = backgroundMusic2;
                backgroundAudioSource.Play();
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu2();
            }
            else if (sceneString == "Set nothing")
            {
                backgroundAudioSource.Stop();
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu2();
            }
        }
    }
}
