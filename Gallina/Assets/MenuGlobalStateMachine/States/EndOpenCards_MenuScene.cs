using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOpenCards_MenuScene : IGlobalState
{
    private ClickPresenter clickPresenter;
    private SwipeClickAnimationPresenter swipeClickAnimationPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public EndOpenCards_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine,
        SwipeClickAnimationPresenter swipeClickAnimationPresenter,
        ClickPresenter clickPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.swipeClickAnimationPresenter = swipeClickAnimationPresenter;
        this.clickPresenter = clickPresenter;
    }


    public void EnterState()
    {
        Debug.Log("Activate - END PACK SPIN STATE");

        clickPresenter.OnClick += ChangeStateToOpenPageBook;

        swipeClickAnimationPresenter.ActivateAnimation("Click_OpenCollection");
        clickPresenter.Activate("Click_CollectionZone");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - END PACK SPIN STATE");

        clickPresenter.OnClick -= ChangeStateToOpenPageBook;

        swipeClickAnimationPresenter.DeactivateAnimation("Click_OpenCollection");
        clickPresenter.Deactivate("Click_CollectionZone");
    }

    private void ChangeStateToOpenPageBook()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<StartOpenBookPage_MenuScene>());
    }
}
