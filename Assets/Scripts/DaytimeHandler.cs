using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi;

public class DaytimeHandler : MonoBehaviour
{
    [SerializeField]
    Material day;

    [SerializeField]
    Material night;

    private GameObject MeditationMenu;

    // Start is called before the first frame update
    void Start()
    {
        MeditationMenu = GameObject.Find("Meditation Menu Handler");
    }
 
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
