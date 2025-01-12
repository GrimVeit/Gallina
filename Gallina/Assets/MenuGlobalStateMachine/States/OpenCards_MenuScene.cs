using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCards_MenuScene : IGlobalState
{
    private UnpackerCardsPresenter unpackerCardsPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;
    public OpenCards_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine, 
        UnpackerCardsPresenter unpackerCardsPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.unpackerCardsPresenter = unpackerCardsPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - OPEN CARDS STATE");

        unpackerCardsPresenter.OnAllCardsOpen += ChangeStateToOpenPageBook;

        unpackerCardsPresenter.ActivateCards();
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN CARDS STATE");

        unpackerCardsPresenter.OnAllCardsOpen -= ChangeStateToOpenPageBook;
    }

    private void ChangeStateToOpenPageBook()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<OpenBookPage_MenuScene>());
    }
}
