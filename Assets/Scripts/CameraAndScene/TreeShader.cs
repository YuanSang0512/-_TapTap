using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShader : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer���δ�ҵ�");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Color color = spriteRenderer.color;
            color.a = 0.5f; 
            spriteRenderer.color = color;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Color color = spriteRenderer.color;
            color.a = 1f; 
            spriteRenderer.color = color;
        }
    }
}