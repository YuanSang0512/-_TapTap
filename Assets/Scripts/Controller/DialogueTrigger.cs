using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;



public class DialogueTrigger : MonoBehaviour, IEventTrigger
{
    [SerializeField] int dialog;
    [SerializeField]rollcharacter rollcharacter;
    [SerializeField]GameObject UI;
    public  bool IfUsed = false;
    public Player Player_;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& !IfUsed)
        {

            UI.SetActive(true);

            Player_.SetVelocity(0, 0);
            Player_.isBusy = true;

            Event();

            IfUsed = true;
        }

    }

    public void Event()
    {
        rollcharacter.Dialog_index = dialog;
    }
}
