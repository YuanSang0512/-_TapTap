using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例模式获取唯一的玩家对象
/// </summary>

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Player player;

    private void Awake()
    {
        if(instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }
}
