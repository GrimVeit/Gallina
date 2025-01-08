using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameGlobalStateMachine : IMiniGameGlobalMachineControl
{
    private Dictionary<Type, IGlobalState> states = new Dictionary<Type, IGlobalState>();

    private IGlobalState currentGlobalState;

    public MiniGameGlobalStateMachine(
        UIMiniGameSceneRoot sceneRoot, 
        BasketPresenter basketPresenter, 
        EggCatcherPresenter eggCatcherPresenter, 
        ScorePresenter scorePresenter)
    {
        states[typeof(IGlobalState)] = new MiniGame_GlobalState(this, sceneRoot, basketPresenter, eggCatcherPresenter, scorePresenter);
        states[typeof(IGlobalState)] = new WinMiniGame_GlobalState();
        states[typeof(IGlobalState)] = new FailMiniGame_GlobalState();
    }

    public void Initialize()
    {
        SetState(GetState<MiniGame_GlobalState>());
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

public interface IMiniGameGlobalMachineControl
{
    public IGlobalState GetState<T>() where T : IGlobalState;

    public void SetState(IGlobalState state);
}
