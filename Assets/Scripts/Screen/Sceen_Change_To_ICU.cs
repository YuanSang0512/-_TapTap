using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceen_Change_To_ICU : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enumerator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(33f);
        SceneManager.LoadScene("ICU");
    }
}
