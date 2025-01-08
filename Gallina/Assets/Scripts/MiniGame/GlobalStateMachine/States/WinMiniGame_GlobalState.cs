using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMiniGame_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;

    private IMiniGameGlobalMachineControl machineControl;

    public WinMiniGame_GlobalState(IMiniGameGlobalMachineControl machineControl, UIMiniGameSceneRoot sceneRoot)
    {
        this.machineControl = machineControl;
        this.sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        sceneRoot.OpenWinPanel();
        sceneRoot.CloseFooterPanel();
        sceneRoot.CloseHeaderPanel();
    }

    public void ExitState()
    {
        sceneRoot.CloseWinPanel();
    }
}
