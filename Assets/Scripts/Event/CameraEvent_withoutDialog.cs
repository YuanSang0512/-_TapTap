using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

/// <summary>
/// 挂载到可交互物体上使用
/// </summary>

public class CameraEvent_withoutDialog : EventTrigger
{
    [SerializeField] GameObject ScreenShot;                  //截图系统
    [SerializeField] Scene Scene_;                            //截图脚本
    public override void Update()
    {
        base.Update();
        if (hotKey != null && Input.GetKeyDown(keyCode) && !isUsed)
        {
            isUsed = true;

            ScreenShot.SetActive(true);

            Event();

        }
    }

    public override void Event()
    {
        base.Event();

        Scene_.CaptureAndSave();            //启动拍照
        Debug.Log("camera event");
    }
}
