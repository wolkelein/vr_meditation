using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi;

public class MeditationEnvironmentHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject seaMeditation; //Inspector Field for reference to sea meditation environment prefab

    [SerializeField]
    private GameObject gardenMeditation; //Inspector Field for reference to garden meditation environment prefab

    [SerializeField]
    private GameObject menu; //Inspector Field for reference to menu environment prefab

    private GameObject activeScene; //GameObject to hold the current scene

    private GameObject MeditationMenu; //GameObject for Meditation Menu Handler

    private string scene;


    private void Start()
    {
        activeScene = menu;
        MeditationMenu = GameObject.Find("Meditation Menu Handler");
    }

    /// <summary>
    /// Checks wether the string that is captured through the microphone corresponds to sea, garden or menu and their
    /// synonyms. Destroys the active scene as soon as a different scene is chosen and sets the scene to the game object
    /// that was set in the Inspector, as well as the audio clip that was set in the Inspector.
    /// </summary>
    /// <param name="values"> String values that are returned from Wit.ai</param>
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
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu3();
                activeScene.SetActive(false);
            }
            else if (sceneString == "garden" || sceneString == "nature")
            {
                GameObject.Destroy(activeScene);
                activeScene = Instantiate(gardenMeditation, new Vector3(0, 0, 0), Quaternion.identity);
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu3();
                activeScene.SetActive(false);
            }
            else if (sceneString == "menu" || sceneString == "back" || sceneString == "home")
            {
                GameObject.Destroy(activeScene);
                activeScene = Instantiate(menu, new Vector3(0, 0, 0), Quaternion.identity);
                MeditationMenu.GetComponent<MeditationMenuHandler>().ActivateSetUpMenu();
                activeScene.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Stores the activeScene.name in a string.
    /// </summary>
    /// <returns>string name of the currently active scene</returns>
    public string ShowActiveScene()
    {
       return scene = activeScene.name;
    }

    /// <summary>
    /// Activates the scene that should currently be active.
    /// </summary>
    public void ActivateScene()
    {
        activeScene.SetActive(true);
    }
}
