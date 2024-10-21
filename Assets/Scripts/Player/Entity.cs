using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region 组件
    public Animator animator {  get; private set; }
    public Rigidbody2D rb { get; private set; }
    public SpriteRenderer sr { get; private set; }
    #endregion

    #region 基础信息
    [Header("base info")]
    public int facingDir;
    public float moveSpeed;
    static public bool isBusy;

    #endregion

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        if (isBusy)
            return;
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }

    public void SetBusy(bool _busy)
    {
        isBusy = _busy;
    }
}
