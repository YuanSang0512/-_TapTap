using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    [SerializeField]
    private List<Text> texts = new List<Text>();
    [SerializeField]
    private float delayBetweenTexts = 1f; // 延迟时间
    [SerializeField]
    private float fadeDuration = 2f; // 每个文本渐变效果的持续时间
    [SerializeField] Scrollbar Scrollbar;

    public GameObject Father;

    float duration = 15f; // 滚动动画的持续时间

    void Start()
    {
        StartCoroutine(FadeInTexts());
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
            Scrollbar.value = Mathf.Lerp(0.7f, 0, t);
            yield return null;
        }
        Scrollbar.value = 1;
    }


}