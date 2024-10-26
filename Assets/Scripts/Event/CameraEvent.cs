using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

/// <summary>
/// ���ص��ɽ���������ʹ��
/// </summary>

public class CameraEvent : EventTrigger
{
    [SerializeField]GameObject ScreenShot;                  //��ͼϵͳ
    [SerializeField]DialogueTrigger DialogueTriggerDialogue;        //�Ի��ű�������
    [SerializeField] Scene Scene_;                            //��ͼ�ű�
    public override void Update()
    {
        base.Update();
        if (hotKey != null && Input.GetKeyDown(keyCode) && !isUsed)
        {
            isUsed = true;

            ScreenShot.SetActive(true);

            Event();

            DialogueTriggerDialogue.IfUsed = false;

        }
    }

    public override void Event()
    {
        base.Event();

        Scene_.CaptureAndSave();            //��������
        Debug.Log("camera event");
    }
}
