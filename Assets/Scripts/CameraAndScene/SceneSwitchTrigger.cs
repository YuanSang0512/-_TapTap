using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ����ת��������
/// </summary>

public class SceneSwitchTrigger : SceneTrigger
{
    [SerializeField] private string sceneName;
    static public bool CanTo = true;

    // �������������ʱ����


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
