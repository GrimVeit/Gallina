using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCards_MenuScene : IGlobalState
{
    private UnpackerCardsPresenter unpackerCardsPresenter;
    private SwipeClickAnimationPresenter swipeAnimationPresenter;
    private SwipePresenter swipePresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;
    public OpenCards_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine, 
        UnpackerCardsPresenter unpackerCardsPresenter,
        SwipeClickAnimationPresenter swipeAnimationPresenter,
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

        unpackerCardsPresenter.OnAllCardsOpen += ChangeStateToEndOpenCards;

        unpackerCardsPresenter.ActivateCards();
        swipeAnimationPresenter.ActivateAnimation("LeftRight_OpenCards");
        swipePresenter.Activate("OpenPackPanel");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN CARDS STATE");

        swipePresenter.OnSwipeRight -= unpackerCardsPresenter.MoveCardToClose_Right;
        swipePresenter.OnSwipeLeft -= unpackerCardsPresenter.MoveCardToClose_Left;

        unpackerCardsPresenter.OnAllCardsOpen -= ChangeStateToEndOpenCards;
        swipeAnimationPresenter.DeactivateAnimation("LeftRight_OpenCards");
        swipePresenter.Deactivate("OpenPackPanel");
    }

    private void ChangeStateToEndOpenCards()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<EndOpenCards_MenuScene>());
    }
}