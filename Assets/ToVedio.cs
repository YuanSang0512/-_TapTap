using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToVedio : MonoBehaviour
{
    [SerializeField] DialogueTrigger one;
    [SerializeField] DialogueTrigger two;
    [SerializeField] CameraEvent three;

    void Start()
    {
        SceneSwitchTrigger.CanTo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (one.IfUsed && two.IfUsed && three.isUsed && SceneSwitchTrigger.CanTo)
        {
            SceneManager.LoadScene("Vedio");
        }
    }
}
