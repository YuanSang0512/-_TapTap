using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

/// <summary>
/// ���ص��ɽ���������ʹ��
/// </summary>

public class CameraEvent_withoutDialog : EventTrigger
{
    [SerializeField] GameObject ScreenShot;                  //��ͼϵͳ
    [SerializeField] Scene Scene_;                            //��ͼ�ű�
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

        Scene_.CaptureAndSave();            //��������
        Debug.Log("camera event");
    }
}
