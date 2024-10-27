using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Take_thing : EventTrigger
{
    //[SerializeField] DialogueTrigger DialogueTriggerDialogue;        //对话脚本启动器
    public string Clue_text;
    //public Text Text;
    //[SerializeField] string guide;
    [SerializeField]private Text Clue;
    [SerializeField] private GameObject Clue_Fa;
    [SerializeField]ParticleSystem Particle;
    public override void Update()
    {
        base.Update();
        if (hotKey != null && Input.GetKeyDown(keyCode))
        {
            isUsed = true;
            Text Clue_TMP =  Instantiate(Clue);
            Clue_TMP.text = Clue_text;
            Clue_TMP.transform.SetParent(Clue_Fa.transform, false);

            var main = Particle.main;
            main.loop = false;

            DeleteEvent();
            Event();

            //DialogueTriggerDialogue.IfUsed = false;
        }
    }

    public override void Event()
    {
        base.Event();

        Debug.Log("Take clue");
    }
}
