using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 这是控制背景跟随玩家移动的脚本
 parallaxEffect是背景移动速度与玩家移动速度的比值
*/

public class ParallaxBackGround : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    private GameObject cam;

    private float xPosition;
    private float yPosition;

    private void Start()
    {
        cam = GameObject.Find("Virtual Camera");
        xPosition = transform.position.x;
        yPosition = transform.position.y;
    }

    private void Update()
    {
        float xdistanceToMove = cam.transform.position.x * parallaxEffect;
        float ydistanceToMove = cam.transform.position.y * parallaxEffect;
        transform.position = new Vector3(xPosition + xdistanceToMove, yPosition + ydistanceToMove);
    }

}
