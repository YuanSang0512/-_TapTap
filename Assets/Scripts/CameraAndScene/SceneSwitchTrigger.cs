using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景转换触发器
/// </summary>

public class SceneSwitchTrigger : SceneTrigger
{
    [SerializeField] private string sceneName;
    static public bool CanTo = true;

    // 当场景加载完成时调用


    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(keyCode) && hotKey != null && CanTo)
        {
            EventManager.instance.SaveData();
            StartCoroutine(CameraController.instance.LoadScene(sceneName));
        }

    }

    public override void Event()
    {
        base.Event();
    }

    public void ToNext()
    {
        EventManager.instance.SaveData();
        StartCoroutine(CameraController.instance.LoadScene(sceneName));
    }
}
