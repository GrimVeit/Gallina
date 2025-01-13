using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPack_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private UnpackerPackPresenter unpackerPackPresenter;
    private UnpackerCardsPresenter unpackerCardsPresenter;
    private ShopItemSelectPresenter itemSelectPresenter;
    private ShopPackPresenter shopPackPresenter;
    private SwipeAnimationPresenter swipeAnimationPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public OpenPack_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine, 
        UIMainMenuRoot sceneRoot, 
        UnpackerPackPresenter unpackerPackPresenter, 
        UnpackerCardsPresenter unpackerCardsPresenter,
        ShopItemSelectPresenter itemSelectPresenter,
        ShopPackPresenter shopPackPresenter,
        SwipeAnimationPresenter swipeAnimationPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.sceneRoot = sceneRoot;
        this.unpackerPackPresenter = unpackerPackPresenter;
        this.unpackerCardsPresenter = unpackerCardsPresenter;
        this.itemSelectPresenter = itemSelectPresenter;
        this.shopPackPresenter = shopPackPresenter;
        this.swipeAnimationPresenter = swipeAnimationPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - OPEN PACK STATE");

        itemSelectPresenter.OnUnselect += shopPackPresenter.HideBuy;
        unpackerPackPresenter.OnClosePack += ChangeStateToOpenCards;

        swipeAnimationPresenter.ActivateAnimation("LeftRight_OpenPack");
        sceneRoot.OpenPackPanel();
        itemSelectPresenter.Unselect();
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN PACK STATE");

        itemSelectPresenter.OnUnselect -= shopPackPresenter.HideBuy;
        unpackerPackPresenter.OnClosePack -= ChangeStateToOpenCards;

        swipeAnimationPresenter.DeactivateAnimation("LeftRight_OpenPack");
    }

    private void ChangeStateToOpenCards()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<OpenCards_MenuScene>());
    }
}
