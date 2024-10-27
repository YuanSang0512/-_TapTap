using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESC_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ESC;
    [SerializeField]GameObject ESC_Main;
    [SerializeField]GameObject GameSettingS;
    public Player player;
    private void Awake()
    {

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
            SceneSwitchTrigger.CanTo = false;
            ESC.SetActive(true);
            player.isBusy = true;
        }
    }

    public void GameContinue()
    {

        ESC.SetActive(false);

        SceneSwitchTrigger.CanTo =  true;
        player.isBusy = false;
    }

    public void Gamereturn()
    {
        SceneSwitchTrigger.CanTo = true;
        player.isBusy = false;

        UnityEngine.SceneManagement.Scene NowScene = SceneManager.GetActiveScene();
        SaveSystem.SaveCurrentSceene(NowScene.name);
        SceneManager.LoadScene(0);


        //Debug.Log("Exit");
        //StartCoroutine(TimeDelay());

//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//        #endif
    }

    public void GameSetting()
    {
        ESC_Main.SetActive(false);
        GameSettingS.SetActive(true);
    }

    public void ReGameSetting()
    {
        ESC_Main.SetActive(true);
        GameSettingS.SetActive(false);
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(1);
    }

}
