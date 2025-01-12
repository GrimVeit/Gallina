using System;
using System.Collections.Generic;

public class MenuGlobalStateMachine : IControlGlobalStateMachine
{
    private Dictionary<Type, IGlobalState> states = new Dictionary<Type, IGlobalState>();

    private IGlobalState currentGlobalState;

    public MenuGlobalStateMachine(
        UIMainMenuRoot sceneRoot,
        ShopItemSelectPresenter shopItemSelectPresenter,
        ShopPackPresenter shopPackPresenter,
        UnpackerPackPresenter unpackerPackPresenter,
        UnpackerCardsPresenter unpackerCardsPresenter,
        BookPagesPresenter bookPagesPresenter,
        AddCardCollectionPresenter addCardCollectionPresenter,
        CardCollectionPresenter cardCollectionPresenter)
    {
        states[typeof(Hello_MenuScene)] = new Hello_MenuScene(this, sceneRoot);
        states[typeof(Main_MenuScene)] = new Main_MenuScene(this, sceneRoot, shopItemSelectPresenter, shopPackPresenter, unpackerPackPresenter, unpackerCardsPresenter, addCardCollectionPresenter);
        states[typeof(OpenPack_MenuScene)] = new OpenPack_MenuScene(this, sceneRoot, unpackerPackPresenter, unpackerCardsPresenter, shopItemSelectPresenter, shopPackPresenter);
        states[typeof(OpenCards_MenuScene)] = new OpenCards_MenuScene(this, unpackerCardsPresenter);
        states[typeof(OpenBookPage_MenuScene)] = new OpenBookPage_MenuScene(this, sceneRoot, bookPagesPresenter, addCardCollectionPresenter);
        states[typeof(AddCard_MenuScene)] = new AddCard_MenuScene(this, addCardCollectionPresenter, cardCollectionPresenter);
    }

    public void Initialize()
    {
        SetState(GetState<Hello_MenuScene>());
    }

    public void Dispose()
    {

    }

    public IGlobalState GetState<T>() where T : IGlobalState
    {
        return states[typeof(T)];
    }

    public void SetState(IGlobalState state)
    {
        currentGlobalState?.ExitState();

        currentGlobalState = state;
        currentGlobalState.EnterState();
    }
}
