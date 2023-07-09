using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi;
public class ActivateVoice : MonoBehaviour
{

    [SerializeField]
    private Wit wit;

    // Start is called before the first frame update
    void Start()
    {
        if (wit == null)
        {
            wit = GetComponent<Wit>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!wit.Active)
        {
            wit.Activate();
        }
    }

}
