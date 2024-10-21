using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESC_UI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ESC;
    [SerializeField] GameObject Gamesetting;
    [SerializeField]  GameObject MusciSettin_Slider;

    private void Awake()
    {
        ESC.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jundge();
    }

    void Jundge()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            ESC.SetActive(true);
            Entity.isBusy = true;
        }
    }

    public void GameContinue()
    {
        ESC.SetActive(false);
        Entity.isBusy = false;
    }

    public void Gamereturn()
    {
        Entity.isBusy = false;
        Debug.Log("Exit");
        StartCoroutine(TimeDelay());
        //UnityEngine.SceneManagement.Scene NowScene = SceneManager.GetActiveScene();
        //SaveSystem.SaveCurrentSceene(NowScene.name);

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void GameSetting()
    {
        Gamesetting.SetActive(false);
        MusciSettin_Slider.SetActive(true);
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(1);
    }

}
