using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_value : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource BGM_Player;
    public List<AudioClip> BGM = new List<AudioClip>();
    void Start()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        List<AudioSource> loudAudioSources = new List<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.name == "Audio Source")
            {
                BGM_Player = audioSource;
            }
        }
        string currentSceneName = SceneManager.GetActiveScene().name;
        OnloadDo(currentSceneName);

    }
    void OnloadDo(string name)
    {
        if (name == "Forest")
        {
            BGM_Player.clip = BGM[0];
            BGM_Player.Play();
        }
        else if (name == "City")
        {
            BGM_Player.clip = BGM[1];
            BGM_Player.Play();
        }
        else if (name == "Hospital")
        {
            BGM_Player.clip = BGM[2];
            BGM_Player.Play();
        }
        else if (name == "School")
        {
            BGM_Player.clip = BGM[3];
            BGM_Player.Play();
        }
        else if (name == "Sch_RoofTop")
        {
            BGM_Player.clip = BGM[4];
            BGM_Player.Play();
        }
        else if (name == "Train")
        {
            BGM_Player.clip = null;
        }
        else if (name == "Cliff")
        {
            BGM_Player.clip = BGM[5];
            BGM_Player.Play();
        }
        else if (name == "gameover")
        {
            BGM_Player.clip = BGM[6];
            BGM_Player.Play();
        }
    }

    public void Delete_Player()
    {
        Destroy(BGM_Player);
    }
    // Update is called once per frame
}

