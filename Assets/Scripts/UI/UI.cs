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
    GameObject GameSetting;
    [SerializeField]
    GameObject MainState;
    [SerializeField]
    Slider Slider_Musci;

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
        Debug.Log("ÓÎÏ·¼´½«ÍË³ö");
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
        Slider_Musci.gameObject.SetActive(true);
    }
}
