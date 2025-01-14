using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCards_MenuScene : IGlobalState
{
    private UnpackerCardsPresenter unpackerCardsPresenter;
    private SwipeAnimationPresenter swipeAnimationPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;
    public OpenCards_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine, 
        UnpackerCardsPresenter unpackerCardsPresenter,
        SwipeAnimationPresenter swipeAnimationPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.unpackerCardsPresenter = unpackerCardsPresenter;
        this.swipeAnimationPresenter = swipeAnimationPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - OPEN CARDS STATE");

        unpackerCardsPresenter.OnAllCardsOpen += ChangeStateToOpenPageBook;

        unpackerCardsPresenter.ActivateCards();
        swipeAnimationPresenter.ActivateAnimation("LeftRight_OpenCards");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN CARDS STATE");

        unpackerCardsPresenter.OnAllCardsOpen -= ChangeStateToOpenPageBook;
        swipeAnimationPresenter.DeactivateAnimation("LeftRight_OpenCards");
    }

    private void ChangeStateToOpenPageBook()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<StartOpenBookPage_MenuScene>());
    }
}
