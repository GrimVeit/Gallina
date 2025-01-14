using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPack_MenuScene : IGlobalState
{
    private UnpackerPackPresenter unpackerPackPresenter;
    private SwipeAnimationPresenter swipeAnimationPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public OpenPack_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine, 
        UnpackerPackPresenter unpackerPackPresenter, 
        SwipeAnimationPresenter swipeAnimationPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.unpackerPackPresenter = unpackerPackPresenter;
        this.swipeAnimationPresenter = swipeAnimationPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - OPEN PACK STATE");

        unpackerPackPresenter.OnStartClosePack += ChangeStateToEndOpenPack;

        swipeAnimationPresenter.ActivateAnimation("LeftRight_OpenPack");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN PACK STATE");

        unpackerPackPresenter.OnStartClosePack -= ChangeStateToEndOpenPack;

        swipeAnimationPresenter.DeactivateAnimation("LeftRight_OpenPack");
    }

    private void ChangeStateToEndOpenPack()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<EndOpenPack_MenuScene>());
    }
}
