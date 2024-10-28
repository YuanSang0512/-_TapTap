using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField]
    private List<Text> texts = new List<Text>();
    [SerializeField]
    private float delayBetweenTexts = 1f; // 延迟时间
    [SerializeField]
    private float fadeDuration = 2f; // 每个文本渐变效果的持续时间
    [SerializeField] Scrollbar Scrollbar;
    public Text text1;
    public GameObject Father;

    float duration = 15f; // 滚动动画的持续时间

    void Start()
    {
        StartCoroutine(FadeInTexts());
    }

    private void Update()
    {
        Sceen_To_Main();
    }

    IEnumerator FadeInTexts()
    {
        foreach (Text text in texts)
        {
            yield return StartCoroutine(FadeTextIn(text, fadeDuration));
            yield return StartCoroutine(delay(delayBetweenTexts));
        }
        Debug.Log("字幕输出完毕");
        Father.SetActive(false);
        StartCoroutine(ScrollPlay());

    }

    IEnumerator FadeTextIn(Text text, float duration)
    {
        Color startColor = Color.clear;
        Color targetColor = Color.white;

        float time = 0;
        while (time < duration)
        {
            float t = time / duration;
            text.color = Color.Lerp(startColor, targetColor, t);
            time += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    IEnumerator ScrollPlay()
    {

        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            Scrollbar.value = Mathf.Lerp(0.8f, 0, t/2);
            yield return null;
        }

    }

    public void Sceen_To_Main()
    {
        if(Scrollbar.value < 0.1f)
        {
            text1.text = "点击回到游戏初始界面";
            if(Input.GetMouseButton(0))
            {
                AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
                List<AudioSource> loudAudioSources = new List<AudioSource>();
                foreach (AudioSource audioSource in allAudioSources)
                {
                    Destroy(audioSource);
                }
                SceneManager.LoadScene("main");
            }
        }
    }


}