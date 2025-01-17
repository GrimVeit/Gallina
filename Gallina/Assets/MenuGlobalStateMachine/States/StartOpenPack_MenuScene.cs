using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOpenPack_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private UnpackerPackPresenter unpackerPackPresenter;
    private ShopItemSelectPresenter shopItemSelectPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public StartOpenPack_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine,
        UIMainMenuRoot sceneRoot,
        UnpackerPackPresenter unpackerPackPresenter,
        ShopItemSelectPresenter shopItemSelectPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.sceneRoot = sceneRoot;
        this.unpackerPackPresenter = unpackerPackPresenter;
        this.shopItemSelectPresenter = shopItemSelectPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - START OPEN PACK STATE");

        unpackerPackPresenter.OnOpenPack += ChangeStateToOpenPack;
        
        sceneRoot.OpenPackPanel();
        shopItemSelectPresenter.Unselect();
        unpackerPackPresenter.MovePackToOpen();
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - START OPEN PACK STATE");

        unpackerPackPresenter.OnOpenPack -= ChangeStateToOpenPack;
    }

    private void ChangeStateToOpenPack()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<OpenPack_MenuScene>());
    }
}
