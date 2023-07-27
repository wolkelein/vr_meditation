using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi;

public class DaytimeHandler : MonoBehaviour
{
    [SerializeField]
    Material day;  //Inspector Field for Skybox Material for a day meditation

    [SerializeField]
    Material night; //Inspector Field for Skybox Material for a night meditation

    private GameObject MeditationMenu; //GameObject for Meditation Menu Handler

    // Start is called before the first frame update
    void Start()
    {
        MeditationMenu = GameObject.Find("Meditation Menu Handler");
    }

    /// <summary>
    /// This function sets the Skybox depending on the string[] values and calls the function ChangeToSetupMenu5() from the MeditationMenuHandler component.
    /// </summary>
    /// <param name="values">String values that are returned from Wit.ai</param>
    public void ChooseDaytime(string[] values)
    {
        var daytimeString = values[0];

        // Check the value of sceneString and switch scenes accordingly
        if (!string.IsNullOrEmpty(daytimeString))
        {
            // Check the value of sceneString and switch scenes accordingly
            if (daytimeString == "day" || daytimeString == "Day")
            {
                RenderSettings.skybox = day;
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu5();
            }
            else if (daytimeString == "night" || daytimeString == "Night")
            {
                RenderSettings.skybox = night;
                MeditationMenu.GetComponent<MeditationMenuHandler>().ChangeToSetupMenu5();
            }
        }

    }
}
