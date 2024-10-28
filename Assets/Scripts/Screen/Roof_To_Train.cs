using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof_To_Train : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Take_thing one;
    [SerializeField] Take_thing two;
    [SerializeField] CameraEvent three;
    [SerializeField] SceneSwitchTrigger four;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (one.isUsed && two.isUsed && three.isUsed)
        {
            four.enabled = true;
        }
        else
            four.enabled = false;
    }
}
