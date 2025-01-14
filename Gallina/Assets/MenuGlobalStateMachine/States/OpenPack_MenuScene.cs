using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPack_MenuScene : IGlobalState
{
    private UnpackerPackPresenter unpackerPackPresenter;
    private SwipeAnimationPresenter swipeAnimationPresenter;
    private SwipePresenter swipePresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public OpenPack_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine, 
        UnpackerPackPresenter unpackerPackPresenter, 
        SwipeAnimationPresenter swipeAnimationPresenter,
        SwipePresenter swipePresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.unpackerPackPresenter = unpackerPackPresenter;
        this.swipeAnimationPresenter = swipeAnimationPresenter;
        this.swipePresenter = swipePresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - OPEN PACK STATE");

        swipePresenter.OnSwipeRight += unpackerPackPresenter.MovePackToClose_Right;
        swipePresenter.OnSwipeLeft += unpackerPackPresenter.MovePackToClose_Left;
        unpackerPackPresenter.OnStartClosePack += ChangeStateToEndOpenPack;

        swipeAnimationPresenter.ActivateAnimation("LeftRight_OpenPack");
        swipePresenter.Activate("OpenPackPanel");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN PACK STATE");

        unpackerPackPresenter.OnStartClosePack -= ChangeStateToEndOpenPack;

        swipeAnimationPresenter.DeactivateAnimation("LeftRight_OpenPack");
        swipePresenter.Deactivate("OpenPackPanel");
    }

    private void ChangeStateToEndOpenPack()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<EndOpenPack_MenuScene>());
    }
}
