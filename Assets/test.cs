using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �˽ű�������ʱ������Ϸ����Գ�ʼ���浵
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
