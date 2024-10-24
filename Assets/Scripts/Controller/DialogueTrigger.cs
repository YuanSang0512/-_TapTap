using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class DialogueTrigger : MonoBehaviour, IEventTrigger
{
    [SerializeField] int dialog;
    [SerializeField]rollcharacter rollcharacter;
    [SerializeField]GameObject UI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI.SetActive(true);

            Event();
        }
    }

    public void Event()
    {
        rollcharacter.Dialog_index = dialog;
    }
}
