using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi;

public class BackgroundMusicHandler : MonoBehaviour
{
    [SerializeField]
    private AudioClip backgroundMusic1; //Inspector Field for Backgroundmusic Track 1

    [SerializeField]
    private AudioClip backgroundMusic2; //Inspector Field for Backgroundmusic Track 2

    private GameObject backgroundMusic; //GameObject for Background Audio
    private AudioSource backgroundAudioSource; //AudioSource of backgroundMusic GameObject

    private GameObject MeditationMenu; //GameObject for Meditation Menu Handler

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GameObject.Find("Background Audio");
        backgroundAudioSource = backgroundMusic.GetComponent<AudioSource>();
        MeditationMenu = GameObject.Find("Meditation Menu Handler");
    }

    /// <summary>
    /// BackgroundMusicTrial() plays a short excerpt (3 seconds) from the current backgroundAudioSource (either Track 1 or Track 2). 
    /// </summary>
    /// <returns></returns>
    IEnumerator BackgroundMusicTrial()
    {
        backgroundAudioSource.Play();
        yield return new WaitForSeconds(3);
        backgroundAudioSource.Stop();
    }

    /// <summary>
    /// This function sets the backgroundAudioSource Clip to a value depending on the string[] values. For values "Try ..." a track,
    /// the Coroutine BackgroundMusicTrial() executes. For valeus "Set ..." a track, the backgroundAudioSource Clip starts playing in a loop
    /// and the function ChangeToSetupMenu2() from the MeditationMenuHandler component is called.
    /// </summary>
    /// <param name="values">String values that are returned from Wit.ai</param>
    public void UpdateBackgroundAudio(string[] values)
    {
        var sceneString = values[0];

        // Check the value of sceneString and switch scenes accordingly
        if (!string.IsNullOrEmpty(sceneString))
        {
            if (sceneString == "Try one")
            {
                backgroundAudioSource.clip = backgroundMusic1;
                backgroundAudioSource.volume = 0.5f;
                StartCoroutine(BackgroundMusicTrial());
            }
            else if (sceneString == "Try two")
            {
                backgroundAudioSource.clip = backgroundMusic2;
                backgroundAudioSource.volume = 0.083f;
                StartCoroutine(BackgroundMusicTrial());
            }
            else if (sceneString == "Set one")
            {
                backgroundAudioSource.clip = backgroundMusic1;
                backgroundAudioSource.volume = 0.5f;
                backgroundAudioSource.Play();
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu2();
            }
            else if (sceneString == "Set two")
            {
                backgroundAudioSource.clip = backgroundMusic2;
                backgroundAudioSource.volume = 0.083f;
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
