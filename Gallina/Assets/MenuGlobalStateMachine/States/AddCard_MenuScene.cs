using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard_MenuScene : IGlobalState
{
    private IControlGlobalStateMachine controlGlobalStateMachine;

    public AddCard_MenuScene(IControlGlobalStateMachine controlGlobalStateMachine)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
    }

    public void EnterState()
    {

    }

    public void ExitState()
    {

    }
}
