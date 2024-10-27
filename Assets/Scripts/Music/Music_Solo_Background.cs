using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Solo_Background : MonoBehaviour
{
    public AudioSource BGM_Player;
    private void Start()
    {
    }
    void Update()
    {

        BGM_Player.volume = Music.Instance.MusicValue / 300;
    }
}

