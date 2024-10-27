using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_Solo : MonoBehaviour
{
    public AudioSource BGM_Player;
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
       
        BGM_Player.volume = Music.Instance.MusicValue / 100;
    }
}


