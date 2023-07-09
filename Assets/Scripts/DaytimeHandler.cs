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

    // Start is called before the first frame update
    void Start()
    {
        
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
            }
            else if (daytimeString == "night" || daytimeString == "Night")
            {
                RenderSettings.skybox = night;
            }
        }

    }
}
