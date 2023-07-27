using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandRaycastHandler: MonoBehaviour
{
    private GameObject birdflock; //Inspector Field for reference to Birdflock GameObject
    private GameObject birdflock2; //Inspector Field for reference to Birdflock 2 GameObject
    private AudioSource meditationAudioSource; //AudioSource of Meditation Voice Audio 2 GameObject

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

    /// <summary>
    /// Pauses the meditationAudioSource, activates the birdflock GameObject, resets focusDetected bool and unpauses meditationAudioSource.
    /// </summary>
    IEnumerator FlyBirds()
    {
        meditationAudioSource.Pause();
        birdflock.SetActive(true);
        yield return new WaitForSeconds(3);
        focusDetected = false;
        meditationAudioSource.UnPause();
    }

    /// <summary>
    /// Pauses the meditationAudioSource, activates the birdflock2 GameObject, resets focusDetected bool and unpauses meditationAudioSource.
    /// </summary>
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

        ray2 = new Ray(origin2, direction2);

        if (Physics.Raycast(ray2, out RaycastHit raycastHit2) && focusDetected==true)
        {
            if (raycastHit2.transform.tag == "island") //island tag is used for ocean meditation scene
            {
                StartCoroutine(FlyBirds());
            }
            else if (raycastHit2.transform.tag == "tree") //tree tag is used for garden meditation scene
            {
                StartCoroutine(FlyBirds2());
            }
            
        }
    }

    /// <summary>
    /// Sets the focusDetected bool to true when string[] values matches "focus".
    /// </summary>
    /// <param name="values">String values that are returned from Wit.ai</param>
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
