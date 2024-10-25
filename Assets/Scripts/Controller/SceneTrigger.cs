using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour, IEventTrigger
{
    [Header("HotKey info")]
    [SerializeField] protected GameObject hotKeyPrefab;
    protected GameObject hotKey;
    [SerializeField] protected KeyCode keyCode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetUpHotKey(keyCode, transform.position + new Vector3(0, 2));
        }
    }

    public virtual void Update()
    {

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

    }
}
