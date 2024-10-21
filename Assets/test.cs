using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 此脚本用于临时进入游戏与测试初始化存档
/// </summary>

public class test : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadSceneAsync("Forest");

        if(Input.GetKeyDown(KeyCode.P))
            SaveSystem.ClearData();
    }
}
