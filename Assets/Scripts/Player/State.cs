using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Player player;
    protected StateMachine stateMachine;
    protected Rigidbody2D rb;


    protected string animationBoolName;
    protected float inputX;
    protected float inputY;

    public State(Player _player, StateMachine _stateMachine, string _animationBoolName)
    {
        player = _player;
        stateMachine = _stateMachine;
        animationBoolName = _animationBoolName;
    }

    public virtual void Enter()
    {
        player.animator.SetBool(animationBoolName, true);
        //Debug.Log("Enter " + animationBoolName);
    }

    public virtual void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
    }

    public virtual void Exit()
    {
        player.animator.SetBool(animationBoolName, false);
        //Debug.Log("Exit " + animationBoolName);
    }

}
