using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ³¡¾°×ª»»´¥·¢Æ÷
/// </summary>

public class SceneSwitchTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EventManager.instance.SaveData();
            StartCoroutine(CameraController.instance.LoadScene(sceneName));
        }
    }
}
