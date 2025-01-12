using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard_MenuScene : IGlobalState
{
    private AddCardCollectionPresenter addCardCollectionPresenter;
    private CardCollectionPresenter cardCollectionPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public AddCard_MenuScene(IControlGlobalStateMachine controlGlobalStateMachine, AddCardCollectionPresenter addCardCollectionPresenter, CardCollectionPresenter cardCollectionPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.addCardCollectionPresenter = addCardCollectionPresenter;
        this.cardCollectionPresenter = cardCollectionPresenter;
    }

    public void EnterState()
    {
        addCardCollectionPresenter.OnEndMove_Value += OnEndMove;
        addCardCollectionPresenter.OnEndMove += ChangeStateToOpenPageBook;

        addCardCollectionPresenter.ActivateCurrentCard();
    }

    public void ExitState()
    {
        addCardCollectionPresenter.OnEndMove_Value -= OnEndMove;
        addCardCollectionPresenter.OnEndMove -= ChangeStateToOpenPageBook;
    }

    private void OnEndMove(CardInfo cardInfo)
    {
        cardCollectionPresenter.UnlockCard(cardInfo.Number);
    }

    private void ChangeStateToOpenPageBook()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<OpenBookPage_MenuScene>());
    }
}
