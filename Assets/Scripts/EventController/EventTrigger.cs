using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 场景交互触发器
/// keyCode为交互按键
/// isUsed为是否被触发
/// </summary>

public class EventTrigger : MonoBehaviour, IEventTrigger
{
    [Header("HotKey info")]
    [SerializeField] protected GameObject hotKeyPrefab;
    [SerializeField] protected GameObject hotKey;
    [SerializeField] protected KeyCode keyCode;
    public bool isUsed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isUsed)
        {
            SetUpHotKey(keyCode, transform.position + new Vector3(0, 2));
        }
    }

    public virtual void Update()
    {

    }

    public void DeleteEvent()
    {
        Destroy(hotKey);
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && hotKey != null)
        {
            Destroy(hotKey);
        }
    }

    public void SetupInfo(KeyCode _keyCode)
    {
        keyCode = _keyCode;
    }

    private void SetUpHotKey(KeyCode _keyCode, Vector3 _position)
    {
        hotKey = Instantiate(hotKeyPrefab, _position, Quaternion.identity);
    }

    public virtual void Event()
    {
        EventManager.instance.eventIndex++;
        EventManager.instance.CheckEventProgress();
    }
}
