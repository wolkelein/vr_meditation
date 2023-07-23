using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR;

public class MeditationMenuHandler : MonoBehaviour
{
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

   public void ChangeToSetupMenu2()
    {
        if (HelpMenuActive == false)
        {
            WelcomeText.SetActive(false);
            SetupMenu1.SetActive(false);
            SetupMenu2.SetActive(true);
        }
    }

    public void ChangeToSetupMenu3()
    {
        if(HelpMenuActive == false)
        {
            SetupMenu2.SetActive(false);
            SetupMenu3.SetActive(true);
        }
    }

    public void ChangeToSetupMenu4()
    {
        if (HelpMenuActive == false)
        {
            SetupMenu3.SetActive(false);
            SetupMenu4.SetActive(true);
        }
    }

    public void ChangeToSetupMenu5()
    {
        if(HelpMenuActive == false)
        {
            SetupMenu4.SetActive(false);
            SetupMenu5.SetActive(true);
        }
    }

    public void ExitMenu()
    {
        MenuBackgroundImage.SetActive(false);
       // WelcomeText.SetActive(false);
        //SetupMenu1.SetActive(false);
        //SetupMenu2.SetActive(false);
        //SetupMenu3.SetActive(false);
        //SetupMenu4.SetActive(false);
        SetupMenu5.SetActive(false);
        StartMenuActive = false;
    }

    public void ActivateHelpMenu()
    {
        HelpMenuBackgroundImage.SetActive(true);
        HelpMenu1.SetActive(true);
        HelpMenuActive = true;
    }

    public void HelpMenuMeditationSwitch()
    {
        HelpMenu1.SetActive(false);
        HelpMenu2.SetActive(true);
    }

    public void HelpMenuVoiceSwitch()
    {
        HelpMenu1.SetActive(false);
        HelpMenu3.SetActive(true);
    }

    public void HelpMenuSkySwitch()
    {
        HelpMenu1.SetActive(false);
        HelpMenu4.SetActive(true);
    }
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

    public bool IsHelpMenuActive()
    {
        return HelpMenuActive;
    }

    public bool IsStartMenuActive()
    {
        return StartMenuActive;
    }



}
