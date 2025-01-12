using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBookPage_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private BookPagesPresenter bookPagesPresenter;
    private AddCardCollectionPresenter addCardCollectionPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public OpenBookPage_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine,
        UIMainMenuRoot sceneRoot,
        BookPagesPresenter bookPagesPresenter, 
        AddCardCollectionPresenter addCardCollectionPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.sceneRoot = sceneRoot;
        this.bookPagesPresenter = bookPagesPresenter;
        this.addCardCollectionPresenter = addCardCollectionPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - OPEN BOOK PAGE STATE");
        //Debug.Log(addCardCollectionPresenter.CurrentCardInfo.Number);
        Debug.Log(addCardCollectionPresenter.CurrentAddCard);

        if (addCardCollectionPresenter.CurrentAddCard != null)
        {
            sceneRoot.OpenCollectionPanel();
            bookPagesPresenter.OpenPage(addCardCollectionPresenter.CurrentAddCard.CardInfo.PageNumber);
            ChangeStateToAddCard();
        }
        else
        {
            ChangeStateToMain();
        }
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN BOOK PAGE STATE");
    }

    private void ChangeStateToAddCard()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<AddCard_MenuScene>());
    }

    private void ChangeStateToMain()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<Main_MenuScene>());
    }
}
