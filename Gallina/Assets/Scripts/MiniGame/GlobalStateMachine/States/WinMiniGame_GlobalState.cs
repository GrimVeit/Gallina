using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMiniGame_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;
    private EggCatcherPresenter eggCatcherPresenter;
    private PointAnimationPresenter pointAnimationPresenter;

    private IControlGlobalStateMachine machineControl;

    public WinMiniGame_GlobalState(IControlGlobalStateMachine machineControl, UIMiniGameSceneRoot sceneRoot, EggCatcherPresenter eggCatcherPresenter, PointAnimationPresenter pointAnimationPresenter)
    {
        this.machineControl = machineControl;
        this.sceneRoot = sceneRoot;
        this.eggCatcherPresenter = eggCatcherPresenter;
        this.pointAnimationPresenter = pointAnimationPresenter;
    }

    public void EnterState()
    {
        eggCatcherPresenter.OnEggDown_Position += pointAnimationPresenter.PlayAnimation;

        sceneRoot.OpenWinPanel();
        sceneRoot.CloseFooterPanel();
        sceneRoot.CloseHeaderPanel();
    }

    public void ExitState()
    {
        eggCatcherPresenter.OnEggDown_Position -= pointAnimationPresenter.PlayAnimation;

        sceneRoot.CloseWinPanel();
    }
}
