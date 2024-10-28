using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_load : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]AudioClip AudioClipaudioClip;
    [SerializeField] AudioSource AudioSource_Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioSource_Player.clip= AudioClipaudioClip;
            AudioSource_Player.loop = false;
        }
    }
}
