using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private void Start()
    {
        activeScene = menu;
    }
    /// <summary>
    /// Checks wether the string that is captured through the microphone corresponds to sea, garden or menu and their
    /// synonyms. Destroys the active scene as soon as a different scene is chosen.
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
            }
            else if (sceneString == "garden" || sceneString == "nature")
            {
                GameObject.Destroy(activeScene);
                activeScene = Instantiate(gardenMeditation, new Vector3(0, 0, 0), Quaternion.identity);

            }
            else if (sceneString == "menu" || sceneString == "back" || sceneString == "home")
            {
                GameObject.Destroy(activeScene);
                activeScene = Instantiate(menu, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }
}
