using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    [SerializeField]
    private List<Text> texts = new List<Text>();
    [SerializeField]
    private float delayBetweenTexts = 1f; // �ӳ�ʱ��
    [SerializeField]
    private float fadeDuration = 2f; // ÿ���ı�����Ч���ĳ���ʱ��
    [SerializeField] Scrollbar Scrollbar;

    public GameObject Father;

    float duration = 15f; // ���������ĳ���ʱ��

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
        Debug.Log("��Ļ������");
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