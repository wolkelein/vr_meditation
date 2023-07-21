using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditationMenuHandler : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
        SetupMenu2.SetActive(false);
        SetupMenu3.SetActive(false);
        SetupMenu4.SetActive(false);
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
}
