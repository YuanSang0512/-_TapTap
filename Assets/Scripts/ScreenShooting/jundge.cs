using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static jundge;

public class jundge : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource  jundgeaudio;
    public AudioClip success;
    public Slider jindutiao;
    public bool once = true;
    [SerializeField]Material Picture;
    [SerializeField]GameObject Camera_system;
    [SerializeField] Material Fault;
    public SpriteRenderer  create_;
    [SerializeField] Sprite Sprite;
    
    void Start()
    {
        jindutiao.interactable= false;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        jiezou();


        if (Input.GetKeyDown(KeyCode.R) && once)
    {
        if(jindutiao.value >= -.5 && jindutiao.value <=0.5 ) 
        {
            Debug.Log("success");
                once= false;
                jundgeaudio.clip= success;
                jundgeaudio.Play();
                create_.sprite= Sprite;
                create_.transform.localScale = new Vector3( 1, 1, 1 );
                jindutiao.gameObject.SetActive(false);
                create_.material = Fault;
                StartCoroutine(Delay());
                
        }
        else
        { 
            Debug.Log("fail");
                once= false;
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


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
        Camera_system.SetActive(false);
    }



}
