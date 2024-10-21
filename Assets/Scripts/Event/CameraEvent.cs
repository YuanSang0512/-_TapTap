using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

/// <summary>
/// 挂载到可交互物体上使用
/// </summary>

public class CameraEvent : EventTrigger
{
    public override void Update()
    {
        base.Update();
        if (hotKey != null && Input.GetKeyDown(keyCode))
        {
            isUsed = true;

            Event();

            DeleteEvent();
        }
    }

    public override void Event()
    {
        base.Event();
        Debug.Log("camera event");
    }
}
