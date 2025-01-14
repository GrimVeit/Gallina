using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCards_MenuScene : IGlobalState
{
    private UnpackerCardsPresenter unpackerCardsPresenter;
    private SwipeAnimationPresenter swipeAnimationPresenter;
    private SwipePresenter swipePresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;
    public OpenCards_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine, 
        UnpackerCardsPresenter unpackerCardsPresenter,
        SwipeAnimationPresenter swipeAnimationPresenter,
        SwipePresenter swipePresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.unpackerCardsPresenter = unpackerCardsPresenter;
        this.swipeAnimationPresenter = swipeAnimationPresenter;
        this.swipePresenter = swipePresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - OPEN CARDS STATE");

        swipePresenter.OnSwipeRight += unpackerCardsPresenter.MoveCardToClose_Right;
        swipePresenter.OnSwipeLeft += unpackerCardsPresenter.MoveCardToClose_Left;

        unpackerCardsPresenter.OnAllCardsOpen += ChangeStateToOpenPageBook;

        unpackerCardsPresenter.ActivateCards();
        swipeAnimationPresenter.ActivateAnimation("LeftRight_OpenCards");
        swipePresenter.Activate("All");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN CARDS STATE");

        swipePresenter.OnSwipeRight -= unpackerCardsPresenter.MoveCardToClose_Right;
        swipePresenter.OnSwipeLeft -= unpackerCardsPresenter.MoveCardToClose_Left;

        unpackerCardsPresenter.OnAllCardsOpen -= ChangeStateToOpenPageBook;
        swipeAnimationPresenter.DeactivateAnimation("LeftRight_OpenCards");
        swipePresenter.Deactivate("All");
    }

    private void ChangeStateToOpenPageBook()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<StartOpenBookPage_MenuScene>());
    }
}
