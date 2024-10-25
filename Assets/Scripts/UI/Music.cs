using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music
{
        private static Music instance;

    private Music()
    {
        MusicValue = 50f; 
    }

    public static Music Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Music();
                }
                return instance;
            }
        }

        // 一个公共属性，可以从外部访问和修改
        public float MusicValue { get; set; }

}


