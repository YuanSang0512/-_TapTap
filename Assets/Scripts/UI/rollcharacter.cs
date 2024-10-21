using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class rollcharacter : MonoBehaviour
{


    [SerializeField]bool IfFinish = false;
    [SerializeField]bool IfJump = false;

    public TextAsset peibiao;
    public TMP_Text textComponent; 
    public float delayBetweenChars = 0.1f;
    public string[] dialog;
    public int index;


    private string TempString = "";
    public GameObject GameStory;

    void Start()
    {
        dialog = peibiao.text.Split('\n');
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        { 
            if(IfFinish)
            {
                index++;
                if(index >= dialog.Length -1)
                {
                    index = 0;
                    GameStory.SetActive(false); 
                }
                StartCoroutine(ShowText());
            }
            else if(!IfJump && !IfFinish)
            {
                IfJump = true;
            }

            
        }
    }
    IEnumerator ShowText()
    {
        textComponent.color= Color.red;
        IfFinish = false;
        textComponent.text = TempString;
        int letter = 0;
        while (!IfJump && letter < dialog[index].Length)
        {
            textComponent.text += dialog[index][letter];
            letter++;
            yield return new WaitForSeconds(delayBetweenChars);
        }
        IfJump = false;
        textComponent.text = dialog[index];
        IfFinish  = true;   
    }

    public void NpcStart()
    {
        GameStory.SetActive(true);
        StartCoroutine(ShowText());
    }
}

