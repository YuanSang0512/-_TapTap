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
        Debug.Log("��Ϸ�����˳�");
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
            // ����Ƿ���������̰���������
            if (Input.anyKeyDown)
            {
                // �������п��ܵ�KeyCodeֵ
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    // ��⵱ǰKeyCode�Ƿ񱻰���
                    if (Input.GetKeyDown(kcode))
                    {
                        Debug.Log(kcode.ToString());
                    }
                }
            }
        }
    }

}
