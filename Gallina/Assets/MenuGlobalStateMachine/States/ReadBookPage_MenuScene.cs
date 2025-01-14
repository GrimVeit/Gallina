using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadBookPage_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private BookPagesPresenter bookPagesPresenter;
    private SwipeAnimationPresenter swipeAnimationPresenter;
    private SwipePresenter swipePresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public ReadBookPage_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine,
        UIMainMenuRoot sceneRoot,
        BookPagesPresenter bookPagesPresenter,
        SwipeAnimationPresenter swipeAnimationPresenter,
        SwipePresenter swipePresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.sceneRoot = sceneRoot;
        this.bookPagesPresenter = bookPagesPresenter;
        this.swipeAnimationPresenter = swipeAnimationPresenter;
        this.swipePresenter = swipePresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - READ BOOK STATE");

        sceneRoot.OnClickBackButtonFromCollectionPanel += ChangeStateToMain;
        swipePresenter.OnSwipeRight += bookPagesPresenter.OpenPastPage;
        swipePresenter.OnSwipeLeft += bookPagesPresenter.OpenSecondPage;

        sceneRoot.OpenCollectionPanel();
        swipePresenter.Activate("CollectionPanel");
        swipeAnimationPresenter.ActivateAnimation("LeftRight_ReadBook");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - READ BOOK STATE");

        sceneRoot.OnClickBackButtonFromCollectionPanel -= ChangeStateToMain;
        swipePresenter.OnSwipeRight -= bookPagesPresenter.OpenPastPage;
        swipePresenter.OnSwipeLeft -= bookPagesPresenter.OpenSecondPage;

        swipePresenter.Deactivate("CollectionPanel");
        swipeAnimationPresenter.DeactivateAnimation("LeftRight_ReadBook");
    }

    private void ChangeStateToMain()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<Main_MenuScene>());
    }
}
