using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi;

public class MeditationEnvironmentHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject seaMeditation;

    [SerializeField]
    private GameObject gardenMeditation;

    [SerializeField]
    private GameObject menu;

    private GameObject activeScene;

    [SerializeField]
    private AudioClip seaAudioVoice;

    [SerializeField]
    private AudioClip gardenAudioVoice;

    [SerializeField]
    private AudioClip menuAudioVoice;

    private GameObject meditationAudio;
    private AudioSource meditationAudioSource;

    private GameObject MeditationMenu;

    private void Start()
    {
        activeScene = menu;
        //meditationAudio = GameObject.Find("Meditation Voice Audio");
        //meditationAudioSource = meditationAudio.GetComponent<AudioSource>();
        MeditationMenu = GameObject.Find("Meditation Menu Handler");
    }

    /// <summary>
    /// Checks wether the string that is captured through the microphone corresponds to sea, garden or menu and their
    /// synonyms. Destroys the active scene as soon as a different scene is chosen and sets the scene to the game object
    /// that was set in the Inspector, as well as the audio clipt that was set in the Inspector.
    /// </summary>
    /// <param name="values"></param>
    public void UpdateMeditationScene(string[] values)
    {
        var sceneString = values[0];

        // Check the value of sceneString and switch scenes accordingly
        if (!string.IsNullOrEmpty(sceneString))
        {
            // Check the value of sceneString and switch scenes accordingly
            if (sceneString == "sea" || sceneString == "ocean" || sceneString == "water")
            {
                GameObject.Destroy(activeScene);
                activeScene = Instantiate(seaMeditation, new Vector3(0, 0, 0), Quaternion.identity);
                //meditationAudioSource.clip = seaAudioVoice;
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu3();
            }
            else if (sceneString == "garden" || sceneString == "nature")
            {
                GameObject.Destroy(activeScene);
                activeScene = Instantiate(gardenMeditation, new Vector3(0, 0, 0), Quaternion.identity);
                //meditationAudioSource.clip = gardenAudioVoice;
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu3();
                
                //new Vector3(-1858, -18, -288)
            }
            else if (sceneString == "menu" || sceneString == "back" || sceneString == "home")
            {
                GameObject.Destroy(activeScene);
                activeScene = Instantiate(menu, new Vector3(0, 0, 0), Quaternion.identity);
                //meditationAudioSource.clip = menuAudioVoice;
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu3();
                
            }
        }
    }
}
