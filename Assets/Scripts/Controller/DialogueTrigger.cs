using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class DialogueTrigger : MonoBehaviour, IEventTrigger
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Event();
        }
    }

    public void Event()
    {
        
    }
}
