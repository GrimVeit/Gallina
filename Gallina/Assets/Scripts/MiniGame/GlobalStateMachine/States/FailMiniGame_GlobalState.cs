using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailMiniGame_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;

    private IMiniGameGlobalMachineControl machineControl;

    public FailMiniGame_GlobalState(IMiniGameGlobalMachineControl machineControl, UIMiniGameSceneRoot sceneRoot)
    {
        this.machineControl = machineControl;
        this.sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        sceneRoot.OpenFailPanel();
        sceneRoot.CloseFooterPanel();
        sceneRoot.CloseHeaderPanel();
    }

    public void ExitState()
    {
        sceneRoot.CloseFailPanel();
    }
}
