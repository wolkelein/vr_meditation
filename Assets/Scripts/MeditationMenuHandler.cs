using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR;

public class MeditationMenuHandler : MonoBehaviour
{
    /// <summary>
    /// Inspector Fields for references to the SetupMenu GameObjects.
    /// </summary>
    [SerializeField]
    private GameObject MenuBackgroundImage;
    [SerializeField]
    private GameObject WelcomeText;
    [SerializeField]
    private GameObject SetupMenu1;
    [SerializeField]
    private GameObject SetupMenu2;
    [SerializeField]
    private GameObject SetupMenu3;
    [SerializeField]
    private GameObject SetupMenu4;
    [SerializeField]
    private GameObject SetupMenu5;

    /// <summary>
    /// Inspector Fields for references to the HelpMenu GameObjects.
    /// </summary>
    [SerializeField]
    private GameObject HelpMenuBackgroundImage;
    [SerializeField]
    private GameObject HelpMenu1;
    [SerializeField]
    private GameObject HelpMenu2;
    [SerializeField]
    private GameObject HelpMenu3;
    [SerializeField]
    private GameObject HelpMenu4;

    private bool HelpMenuActive;

    private bool StartMenuActive;

    /// <summary>
    /// Checks if any SetupMenu GameObjects are active and deactivates them.
    /// </summary>
    public void CloseAllSetupMenus()
    {
        if (MenuBackgroundImage.activeSelf == true)
        {
            MenuBackgroundImage.SetActive(false);
        }
        else if (WelcomeText.activeSelf == true)
        {
            WelcomeText.SetActive(false);
        }
        else if (SetupMenu1.activeSelf == true)
        {
            SetupMenu1.SetActive(false);
        }
        else if (SetupMenu2.activeSelf == true)
        {
            SetupMenu2.SetActive(false);
        }
        else if (SetupMenu3.activeSelf == true)
        {
            SetupMenu3.SetActive(false);
        }
        else if (SetupMenu4.activeSelf == true)
        {
            SetupMenu4.SetActive(false);
        }
        else if (SetupMenu5.activeSelf == true)
        {
            SetupMenu5.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_EDITOR
        Google.XR.Cardboard.Api.Recenter();
#endif
        SetupMenu2.SetActive(false);
        SetupMenu3.SetActive(false);
        SetupMenu4.SetActive(false);
        SetupMenu5.SetActive(false);
        HelpMenuBackgroundImage.SetActive(false);
        HelpMenu1.SetActive(false);
        HelpMenu2.SetActive(false);
        HelpMenu3.SetActive(false);
        HelpMenu4.SetActive(false);
        HelpMenuActive = false;
        StartMenuActive = true;
    }

    /// <summary>
    /// Reopens the SetupMenu.
    /// </summary>
    public void ActivateSetUpMenu()
    {
        WelcomeText.SetActive(true);
        SetupMenu1.SetActive(true);
        MenuBackgroundImage.SetActive(true);
        StartMenuActive = true;

        if (SetupMenu2.activeSelf == true)
        {
            SetupMenu2.SetActive(false);
        }
        else if (SetupMenu3.activeSelf == true)
        {
            SetupMenu3.SetActive(false);
        }
        else if (SetupMenu4.activeSelf == true)
        {
            SetupMenu4.SetActive(false);
        }
        else if (SetupMenu5.activeSelf == true)
        {
            SetupMenu5.SetActive(false);
        }
    }

    /// <summary>
    /// Changes to the second GameObject of the Setup Menu.
    /// </summary>
    public void ChangeToSetupMenu2()
    {
        if (HelpMenuActive == false)
        {
            WelcomeText.SetActive(false);
            SetupMenu1.SetActive(false);
            SetupMenu2.SetActive(true);
        }
    }

    /// <summary>
    /// Changes to the third GameObject of the Setup Menu.
    /// </summary>
    public void ChangeToSetupMenu3()
    {
        if(HelpMenuActive == false)
        {
            SetupMenu2.SetActive(false);
            SetupMenu3.SetActive(true);
        }
    }

    /// <summary>
    /// Changes to the fourth GameObject of the Setup Menu.
    /// </summary>
    public void ChangeToSetupMenu4()
    {
        if (HelpMenuActive == false)
        {
            SetupMenu3.SetActive(false);
            SetupMenu4.SetActive(true);
        }
    }

    /// <summary>
    /// Changes to the fifth GameObject of the Setup Menu.
    /// </summary>
    public void ChangeToSetupMenu5()
    {
        if(HelpMenuActive == false)
        {
            SetupMenu4.SetActive(false);
            SetupMenu5.SetActive(true);
        }
    }

    /// <summary>
    /// Exits Setup Menu.
    /// </summary>
    public void ExitMenu()
    {
        CloseAllSetupMenus();
        SetupMenu5.SetActive(false);
        StartMenuActive = false;
    }

    /// <summary>
    /// Opens the HelpMenu.
    /// </summary>
    public void ActivateHelpMenu()
    {
        HelpMenuBackgroundImage.SetActive(true);
        HelpMenu1.SetActive(true);
        HelpMenuActive = true;
    }

    /// <summary>
    /// Opens the HelpMenu 2.
    /// </summary>
    public void HelpMenuMeditationSwitch()
    {
        HelpMenu1.SetActive(false);
        HelpMenu2.SetActive(true);
    }

    /// <summary>
    /// Opens the HelpMenu3 .
    /// </summary>
    public void HelpMenuVoiceSwitch()
    {
        HelpMenu1.SetActive(false);
        HelpMenu3.SetActive(true);
    }

    /// <summary>
    /// Opens the HelpMenu 4.
    /// </summary>
    public void HelpMenuSkySwitch()
    {
        HelpMenu1.SetActive(false);
        HelpMenu4.SetActive(true);
    }

    /// <summary>
    /// Exits Help Menu.
    /// </summary>
    public void ExitHelpMenu()
    {
        if (HelpMenu1.activeSelf == true)
        {
            HelpMenu1.SetActive(false);
        }
        else if (HelpMenu2.activeSelf == true)
        {
            HelpMenu2.SetActive(false);
        }
        else if (HelpMenu3.activeSelf == true)
        {
            HelpMenu3.SetActive(false);
        }
        else if (HelpMenu4.activeSelf == true)
        {
            HelpMenu4.SetActive(false);
        }
        HelpMenuActive = false;
        HelpMenuBackgroundImage.SetActive(false);
    }

    /// <summary>
    /// Shows whether the Help Menu is active.
    /// </summary>
    /// <returns>bool HelpMenuActive</returns>
    public bool IsHelpMenuActive()
    {
        return HelpMenuActive;
    }

    /// <summary>
    /// Shows whether the Setup Menu is active.
    /// </summary>
    /// <returns>bool StartMenuActive</returns>
    public bool IsStartMenuActive()
    {
        return StartMenuActive;
    }



}
