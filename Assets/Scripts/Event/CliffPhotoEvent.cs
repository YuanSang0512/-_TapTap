using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffPhotoEvent : EventTrigger
{
    public override void Update()
    {
        base.Update();
        if (hotKey != null && Input.GetKeyDown(keyCode) && !isUsed)
        {
            isUsed = true;


            Event();
            
        }
    }

    public override void Event()
    {
        base.Event();

        Debug.Log("camera event");
    }
}
