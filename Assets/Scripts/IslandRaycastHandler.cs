using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandRaycastHandler: MonoBehaviour
{
    private GameObject birdflock;
    private GameObject birdflock2;
    private AudioSource meditationAudioSource;

    Ray ray2;

    private bool focusDetected;

    private void Start()
    {
        birdflock = GameObject.Find("Birdflock");
        birdflock.SetActive(false);
        birdflock2 = GameObject.Find("Birdflock 2");
        birdflock2.SetActive(false);
        meditationAudioSource = GameObject.Find("Meditation Voice Audio 2").GetComponent<AudioSource>();
    }

    IEnumerator FlyBirds()
    {
        meditationAudioSource.Pause();
        birdflock.SetActive(true);
        yield return new WaitForSeconds(3);
        focusDetected = false;
        meditationAudioSource.UnPause();
    }
    IEnumerator FlyBirds2()
    {
        meditationAudioSource.Pause();
        birdflock2.SetActive(true);
        yield return new WaitForSeconds(3);
        focusDetected = false;
        meditationAudioSource.UnPause();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 origin2 = transform.position;
        Vector3 direction2 = transform.forward;

        //Debug.DrawRay(origin, direction * 100f, Color.red);
        ray2 = new Ray(origin2, direction2);

        if (Physics.Raycast(ray2, out RaycastHit raycastHit2) && focusDetected==true)
        {
            if (raycastHit2.transform.tag == "island")
            {
                StartCoroutine(FlyBirds());
            }
            else if (raycastHit2.transform.tag == "tree")
            {
                StartCoroutine(FlyBirds2());
            }
            
        }
    }
    public void FocusReward(string[] values)
    {
        var sceneString = values[0];

        // Check the value of sceneString and switch scenes accordingly
        if (!string.IsNullOrEmpty(sceneString))
        {
            // Check the value of sceneString and switch scenes accordingly
            if (sceneString == "focus")
            {
                focusDetected = true;
            }
  
        }
    }
}
