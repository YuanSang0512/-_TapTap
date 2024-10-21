using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static jundge;

public class jundge : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource  jundgeaudio;
    public AudioClip success;
    public AudioClip failure;
    public Slider jindutiao;
    public bool once = true;
    [SerializeField]Material Picture; 

    void Start()
    {
        jindutiao.interactable= false;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        jiezou();


        if (Input.GetKeyDown(KeyCode.Space) && once)
    {
        if(jindutiao.value >= -.5 && jindutiao.value <=0.5 ) 
        {
            Debug.Log("success");
                once= false;
                jundgeaudio.clip= success;
                jundgeaudio.Play();
        }
        else
        { 
            Debug.Log("fail");
                once= false;
                jundgeaudio.clip = failure;
                jundgeaudio.Play();
            }

    }
           
    }
    void jiezou()
    {
        Picture.SetFloat("_BlurSize", jindutiao.value);
        jindutiao.value += 0.01f;
        if (jindutiao.value >= 3)
        {
            jindutiao.value = -3;
            once = true;
        }
    }






}
