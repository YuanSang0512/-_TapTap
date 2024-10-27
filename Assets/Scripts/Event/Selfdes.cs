using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SELF());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SELF()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
