using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;

    private BasketPresenter basketPresenter;
    private EggCatcherPresenter eggCatcherPresenter;
    private ScorePresenter scorePresenter;

    private IMiniGameGlobalMachineControl machineControl;

    public MiniGame_GlobalState(IMiniGameGlobalMachineControl machineControl, UIMiniGameSceneRoot sceneRoot, BasketPresenter basketPresenter, EggCatcherPresenter eggCatcherPresenter, ScorePresenter scorePresenter)
    {
        this.machineControl = machineControl;
        this.sceneRoot = sceneRoot;
        this.basketPresenter = basketPresenter;
        this.eggCatcherPresenter = eggCatcherPresenter;
        this.scorePresenter = scorePresenter;
    }

    public void EnterState()
    {
        scorePresenter.OnGameFailed += ChangeStateToLose;
        scorePresenter.OnGameWinned += ChangeStateToWin;
        eggCatcherPresenter.OnEggDown += scorePresenter.RemoveHealth;
        eggCatcherPresenter.OnEggWin_EggValue += scorePresenter.AddScore;

        eggCatcherPresenter.SetTimerSpawnerData(2, 0.5f, 0.01f, 1);
        eggCatcherPresenter.StartSpawner();
        basketPresenter.Start();

        sceneRoot.OpenMainPanel();
        sceneRoot.OpenFooterPanel();
        sceneRoot.OpenHeaderPanel();
    }

    public void ExitState()
    {
        scorePresenter.OnGameFailed -= ChangeStateToLose;
        scorePresenter.OnGameWinned -= ChangeStateToWin;
        eggCatcherPresenter.OnEggDown -= scorePresenter.RemoveHealth;
        eggCatcherPresenter.OnEggWin_EggValue -= scorePresenter.AddScore;

        eggCatcherPresenter.DeactivateSpawner();
        basketPresenter.Stop();

        sceneRoot.OpenMainPanel();
        sceneRoot.OpenFooterPanel();
        sceneRoot.OpenHeaderPanel();
    }

    private void ChangeStateToWin()
    {
        machineControl.SetState(machineControl.GetState<WinMiniGame_GlobalState>());
    }
    
    private void ChangeStateToLose()
    {
        machineControl.SetState(machineControl.GetState<WinMiniGame_GlobalState>());
    }
}
