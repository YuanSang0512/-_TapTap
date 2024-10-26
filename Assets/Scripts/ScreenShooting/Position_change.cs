using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_change : MonoBehaviour
{
    public Transform Camera_;
    // Start is called before the first frame update
    Vector3 Vector3_;
    void Start()
    {
        Vector3_ = Camera_.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Camera_.position.x, Camera_.position.y, -2);
    }
}
