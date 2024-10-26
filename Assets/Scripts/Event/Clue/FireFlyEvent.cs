using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyEvent : EventTrigger
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


        Debug.Log("FireFly event");
    }
}