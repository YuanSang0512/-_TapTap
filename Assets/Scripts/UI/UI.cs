using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static int Index;
    // Start is called before the first frame update
    [SerializeField]
    GameObject MainMenue;
    //[SerializeField]
    //GameObject MainState;        //暂时停用
    [SerializeField]
    GameObject SettingS;        //设置

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gamebegin_New()
    {
        SaveSystem.ClearData();

        SceneManager.LoadScene("Forest");
    } 
    
    public void Gamebegin_Old()
    {
        string NowScene = SaveSystem.GetCurrentScene();
        Debug.Log(NowScene);
        
        SceneManager.LoadScene(NowScene);

    }

    public void Gameend()
    {
        
        //SaveSystem.SaveByJson();
        Debug.Log("游戏即将退出");
        StartCoroutine(wait());
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void Setting()
    {
        MainMenue.SetActive(false);
        SettingS.gameObject.SetActive(true);
    }

    public void ReSetting()
    {
        MainMenue.SetActive(true);
        SettingS.gameObject.SetActive(false);
    }
}
