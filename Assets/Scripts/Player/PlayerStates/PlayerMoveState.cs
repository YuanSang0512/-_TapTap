using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : State
{
    public PlayerMoveState(Player _player, StateMachine _stateMachine, string _animationBoolName) : base(_player, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(inputX * player.moveSpeed, inputY * player.moveSpeed);
        if (inputX == 0 && inputY == 0)
            stateMachine.SwitchState(player.idleState);
    }
}
