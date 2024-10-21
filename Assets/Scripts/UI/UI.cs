using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static int Index;
    // Start is called before the first frame update
    [SerializeField]
    GameObject GameSetting;
    [SerializeField]
    GameObject Settings;
    [SerializeField]
    List<Text> KeyBoard_txt = new List<Text>();

    private bool BeChoose = false ; 

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
        GameSetting.SetActive(false);
        Settings.gameObject.SetActive(true);
    }

    public void KeyBored_ReSetting_Up()
    {
        BeChoose = true;
        if (BeChoose)
        {
            // 检测是否有任意键盘按键被按下
            if (Input.anyKeyDown)
            {
                // 遍历所有可能的KeyCode值
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    // 检测当前KeyCode是否被按下
                    if (Input.GetKeyDown(kcode))
                    {
                        Debug.Log(kcode.ToString());
                    }
                }
            }
        }
    }

}
