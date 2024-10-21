using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderController : MonoBehaviour
{
    public static FaderController instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
}
