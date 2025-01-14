using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOpenPack_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private UnpackerPackPresenter unpackerPackPresenter;
    private ShopItemSelectPresenter itemSelectPresenter;
    private ShopPackPresenter shopPackPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public StartOpenPack_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine,
        UIMainMenuRoot sceneRoot,
        UnpackerPackPresenter unpackerPackPresenter,
        ShopItemSelectPresenter itemSelectPresenter,
        ShopPackPresenter shopPackPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.sceneRoot = sceneRoot;
        this.unpackerPackPresenter = unpackerPackPresenter;
        this.itemSelectPresenter = itemSelectPresenter;
        this.shopPackPresenter = shopPackPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - START OPEN PACK STATE");

        itemSelectPresenter.OnUnselect += shopPackPresenter.HideBuy;
        unpackerPackPresenter.OnOpenPack += ChangeStateToOpenPack;
        
        sceneRoot.OpenPackPanel();
        itemSelectPresenter.Unselect();
        unpackerPackPresenter.MovePackToOpen();
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - START OPEN PACK STATE");

        itemSelectPresenter.OnUnselect -= shopPackPresenter.HideBuy;
        unpackerPackPresenter.OnOpenPack -= ChangeStateToOpenPack;
    }

    private void ChangeStateToOpenPack()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<OpenPack_MenuScene>());
    }
}
