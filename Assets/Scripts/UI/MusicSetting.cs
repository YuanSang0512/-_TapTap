using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider MusicValue_Slider;
    private void Awake()
    {
        MusicValue_Slider.value = Music.Instance.MusicValue;
    }

    // Update is called once per frame
    void Update()
    {
        Music.Instance.MusicValue = MusicValue_Slider.value;
    }
}
