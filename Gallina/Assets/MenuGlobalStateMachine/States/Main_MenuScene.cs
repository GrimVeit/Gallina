using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private ShopItemSelectPresenter shopItemSelectPresenter;
    private ShopPackPresenter shopPackPresenter;
    private UnpackerPackPresenter unpackerPackPresenter;
    private UnpackerCardsPresenter unpackerCardsPresenter;
    private AddCardCollectionPresenter addCardCollectionPresenter;


    private IControlGlobalStateMachine globalMachineControl;

    public Main_MenuScene(
        IControlGlobalStateMachine globalMachineControl, 
        UIMainMenuRoot sceneRoot, 
        ShopItemSelectPresenter shopItemSelectPresenter, 
        ShopPackPresenter shopPackPresenter,
        UnpackerPackPresenter unpackerPackPresenter,
        UnpackerCardsPresenter unpackerCardsPresenter,
        AddCardCollectionPresenter addCardCollectionPresenter)
    {
        this.globalMachineControl = globalMachineControl;
        this.sceneRoot = sceneRoot;
        this.shopItemSelectPresenter = shopItemSelectPresenter;
        this.shopPackPresenter = shopPackPresenter;
        this.unpackerPackPresenter = unpackerPackPresenter;
        this.unpackerCardsPresenter = unpackerCardsPresenter;
        this.addCardCollectionPresenter = addCardCollectionPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - MAIN STATE");

        ActivateTransitions();

        shopItemSelectPresenter.OnSelectPack_Data += shopPackPresenter.SetData;
        shopItemSelectPresenter.OnSelect += shopPackPresenter.ShowBuy;
        shopItemSelectPresenter.OnUnselect += shopPackPresenter.HideBuy;

        shopPackPresenter.OnBuyItemPack_Value += unpackerPackPresenter.SpawnPack;
        shopPackPresenter.OnBuyItemPack_Value += unpackerCardsPresenter.SpawnCards;
        shopPackPresenter.OnBuyItemPack += ChangeStateToStartOpenPack;

        unpackerCardsPresenter.OnSpawnNewCard += addCardCollectionPresenter.AddCard;

        sceneRoot.OpenShopPanel();
    }

    private void ActivateTransitions()
    {
        sceneRoot.OnClickCollectionsButton += ChangeStateToReadBook;
        sceneRoot.OnClickBackButtonFromShopPanel += ChangeStateToHello;
    }

    private void DeactivateTransitions()
    {
        sceneRoot.OnClickCollectionsButton -= ChangeStateToReadBook;
        sceneRoot.OnClickBackButtonFromShopPanel -= ChangeStateToHello;
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - MAIN STATE");

        DeactivateTransitions();

        shopItemSelectPresenter.OnSelectPack_Data -= shopPackPresenter.SetData;
        shopItemSelectPresenter.OnSelect -= shopPackPresenter.ShowBuy;
        shopItemSelectPresenter.OnUnselect -= shopPackPresenter.HideBuy;

        shopPackPresenter.OnBuyItemPack_Value -= unpackerPackPresenter.SpawnPack;
        shopPackPresenter.OnBuyItemPack_Value -= unpackerCardsPresenter.SpawnCards;
        shopPackPresenter.OnBuyItemPack -= ChangeStateToStartOpenPack;

        unpackerCardsPresenter.OnSpawnNewCard -= addCardCollectionPresenter.AddCard;
    }

    private void ChangeStateToHello()
    {
        globalMachineControl.SetState(globalMachineControl.GetState<Hello_MenuScene>());
    }

    private void ChangeStateToStartOpenPack()
    {
        globalMachineControl.SetState(globalMachineControl.GetState<StartOpenPack_MenuScene>());
    }

    private void ChangeStateToReadBook()
    {
        globalMachineControl.SetState(globalMachineControl.GetState<ReadBookPage_MenuScene>());
    }
}
