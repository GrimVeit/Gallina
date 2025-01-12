using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPack_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private UnpackerPackPresenter unpackerPackPresenter;
    private UnpackerCardsPresenter unpackerCardsPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public OpenPack_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine, 
        UIMainMenuRoot sceneRoot, 
        UnpackerPackPresenter unpackerPackPresenter, 
        UnpackerCardsPresenter unpackerCardsPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.sceneRoot = sceneRoot;
        this.unpackerPackPresenter = unpackerPackPresenter;
        this.unpackerCardsPresenter = unpackerCardsPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - OPEN PACK STATE");

        unpackerPackPresenter.OnClosePack += ChangeStateToOpenCards;

        sceneRoot.OpenPackPanel();
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN PACK STATE");

        unpackerPackPresenter.OnClosePack -= ChangeStateToOpenCards;
    }

    private void ChangeStateToOpenCards()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<OpenCards_MenuScene>());
    }
}
