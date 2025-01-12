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

        shopItemSelectPresenter.OnSelectPack_Data += shopPackPresenter.SetData;
        shopItemSelectPresenter.OnSelect += shopPackPresenter.ShowBuy;
        shopItemSelectPresenter.OnUnselect += shopPackPresenter.HideBuy;

        shopPackPresenter.OnBuyItemPack_Value += unpackerPackPresenter.SpawnPack;
        shopPackPresenter.OnBuyItemPack_Value += unpackerCardsPresenter.SpawnCards;
        shopPackPresenter.OnBuyItemPack += ChangeStateToOpenPack;

        unpackerCardsPresenter.OnSpawnNewCard += addCardCollectionPresenter.AddCard;

        sceneRoot.OpenMainPanel();
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - MAIN STATE");

        shopItemSelectPresenter.OnSelectPack_Data -= shopPackPresenter.SetData;
        shopItemSelectPresenter.OnSelect -= shopPackPresenter.ShowBuy;
        shopItemSelectPresenter.OnUnselect -= shopPackPresenter.HideBuy;

        shopPackPresenter.OnBuyItemPack_Value -= unpackerPackPresenter.SpawnPack;
        shopPackPresenter.OnBuyItemPack_Value -= unpackerCardsPresenter.SpawnCards;
        shopPackPresenter.OnBuyItemPack -= ChangeStateToOpenPack;

        unpackerCardsPresenter.OnSpawnNewCard -= addCardCollectionPresenter.AddCard;
    }

    private void ChangeStateToOpenPack()
    {
        globalMachineControl.SetState(globalMachineControl.GetState<OpenPack_MenuScene>());
    }
}
