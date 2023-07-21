using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        SetupMenu2.SetActive(false);
        SetupMenu3.SetActive(false);
        SetupMenu4.SetActive(false);
        SetupMenu5.SetActive(false);
    }

   public void ChangeToSetupMenu2()
    {
        WelcomeText.SetActive(false);
        SetupMenu1.SetActive(false);
        SetupMenu2.SetActive(true);
    }

    public void ChangeToSetupMenu3()
    {
        SetupMenu2.SetActive(false);
        SetupMenu3.SetActive(true);
    }

    public void ChangeToSetupMenu4()
    {
        SetupMenu3.SetActive(false);
        SetupMenu4.SetActive(true);
    }

    public void ChangeToSetupMenu5()
    {
        SetupMenu4.SetActive(false);
        SetupMenu5.SetActive(true);
    }

    public void ExitMenu()
    {
        MenuBackgroundImage.SetActive(false);
        WelcomeText.SetActive(false);
        SetupMenu1.SetActive(false);
        SetupMenu2.SetActive(false);
        SetupMenu3.SetActive(false);
        SetupMenu4.SetActive(false);
        SetupMenu5.SetActive(false);
    }
}
