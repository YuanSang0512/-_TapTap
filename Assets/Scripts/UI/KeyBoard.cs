using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoard 
{
    public static  KeyBoard Keyboard;
    // Start is called before the first frame update
    KeyBoard() 
    {
        Left = "A";
        Right = "D";
        Up = "W";
        Down= "S";
        Camera_R = "R";
        Camera_L = "L";
    }

    public string Left { get; set; }
    public string Right { get; set; }
    public string Up { get; set; }
    public string Down { get; set; }

    public string Camera_R { get; set; }
    public string Camera_L { get; set; }
}
