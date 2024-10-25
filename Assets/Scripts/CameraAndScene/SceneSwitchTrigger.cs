using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ³¡¾°×ª»»´¥·¢Æ÷
/// </summary>

public class SceneSwitchTrigger : SceneTrigger
{
    [SerializeField] private string sceneName;

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(keyCode) && hotKey != null)
        {
            EventManager.instance.SaveData();
            StartCoroutine(CameraController.instance.LoadScene(sceneName));
        }

    }

    public override void Event()
    {
        base.Event();
    }
}
