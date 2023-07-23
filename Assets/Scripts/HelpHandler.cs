using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpHandler : MonoBehaviour
{
    [SerializeField]
    private Color activeHelp;

    [SerializeField]
    private Color inactiveHelp;

    [SerializeField]
    private GameObject HelpMark;

    private GameObject MeditationMenu;

    private void Start()
    {
        MeditationMenu = GameObject.Find("Meditation Menu Handler");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        //Debug.DrawRay(origin, direction * 100f, Color.red);
        Ray ray = new Ray(origin, direction);
        if(MeditationMenu.GetComponent<MeditationMenuHandler>().IsStartMenuActive() == true)
        {}
        else if (MeditationMenu.GetComponent<MeditationMenuHandler>().IsStartMenuActive() == false)
        {
            if (Physics.Raycast(ray, out RaycastHit raycastHit) && raycastHit.transform.tag == "help")
            {
                HelpMark.GetComponent<Renderer>().material.color = activeHelp;
                MeditationMenu.GetComponent<MeditationMenuHandler>().ActivateHelpMenu();
            }
            else
            {
                HelpMark.GetComponent<Renderer>().material.color = inactiveHelp;
            }
        }
        
    }
    public void ChooseHelpMenu(string[] values)
    {
        var sceneString = values[0];

        // Check the value of sceneString and switch scenes accordingly
        if (!string.IsNullOrEmpty(sceneString))
        {
            // Check the value of sceneString and switch scenes accordingly
            if (sceneString == "Change sky")
            {
                MeditationMenu.GetComponent<MeditationMenuHandler>().HelpMenuSkySwitch();
            }
            else if (sceneString == "Different voice")
            {
                MeditationMenu.GetComponent<MeditationMenuHandler>().HelpMenuVoiceSwitch();
            }
            else if (sceneString == "Meditation switch")
            {
                MeditationMenu.GetComponent<MeditationMenuHandler>().HelpMenuMeditationSwitch();
            }
            else if (sceneString == "Exit help menu")
            {
                MeditationMenu.GetComponent<MeditationMenuHandler>().ExitHelpMenu();
            }
            else if (sceneString == "Change something else")
            {
                MeditationMenu.GetComponent<MeditationMenuHandler>().ExitHelpMenu();
                MeditationMenu.GetComponent<MeditationMenuHandler>().ActivateHelpMenu();
            }
        }
    }
}
