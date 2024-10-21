using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State currentState {  get; private set; }
    public void Initalize(State _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void SwitchState(State _newStateName)
    {
        currentState.Exit();
        currentState = _newStateName;
        currentState.Enter();
    }
}
