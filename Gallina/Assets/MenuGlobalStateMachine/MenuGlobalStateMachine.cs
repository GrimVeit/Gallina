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
        UnpackerCardsPresenter unpackerCardsPresenter)
    {
        states[typeof(Main_MenuScene)] = new Main_MenuScene(this, sceneRoot, shopItemSelectPresenter, shopPackPresenter, unpackerPackPresenter, unpackerCardsPresenter);
        states[typeof(OpenPack_MenuScene)] = new OpenPack_MenuScene(this, sceneRoot, unpackerPackPresenter, unpackerCardsPresenter);
        states[typeof(OpenCards_MenuScene)] = new OpenCards_MenuScene(this, unpackerCardsPresenter);
    }

    public void Initialize()
    {
        SetState(GetState<Main_MenuScene>());
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
