using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPackSpin_MenuScene : IGlobalState
{
    private ClickPresenter clickPresenter;
    private SwipeClickAnimationPresenter swipeClickAnimationPresenter;

    private IControlGlobalStateMachine globalMachineControl;

    public EndPackSpin_MenuScene(
        IControlGlobalStateMachine globalMachineControl,
        SwipeClickAnimationPresenter swipeClickAnimationPresenter,
        ClickPresenter clickPresenter)
    {
        this.globalMachineControl = globalMachineControl;
        this.swipeClickAnimationPresenter = swipeClickAnimationPresenter;
        this.clickPresenter = clickPresenter;
    }


    public void EnterState()
    {
        Debug.Log("Activate - END PACK SPIN STATE");

        clickPresenter.OnClick += ChangeStateToStartOpenPack;

        swipeClickAnimationPresenter.ActivateAnimation("Click_Spin");
        clickPresenter.Activate("Click_SpinZone");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - END PACK SPIN STATE");

        clickPresenter.OnClick -= ChangeStateToStartOpenPack;

        swipeClickAnimationPresenter.DeactivateAnimation("Click_Spin");
        clickPresenter.Deactivate("Click_SpinZone");
    }

    private void ChangeStateToStartOpenPack()
    {
        globalMachineControl.SetState(globalMachineControl.GetState<StartOpenPack_MenuScene>());
    }
}
