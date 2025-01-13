using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard_MenuScene : IGlobalState
{
    private AddCardCollectionPresenter addCardCollectionPresenter;
    private CardCollectionPresenter cardCollectionPresenter;
    private SwipeAnimationPresenter swipeAnimationPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    private int indexCard;

    public AddCard_MenuScene(IControlGlobalStateMachine controlGlobalStateMachine, AddCardCollectionPresenter addCardCollectionPresenter, CardCollectionPresenter cardCollectionPresenter, SwipeAnimationPresenter swipeAnimationPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.addCardCollectionPresenter = addCardCollectionPresenter;
        this.cardCollectionPresenter = cardCollectionPresenter;
        this.swipeAnimationPresenter = swipeAnimationPresenter;
    }

    public void EnterState()
    {
        addCardCollectionPresenter.OnEndMove_Value += OnEndMove;
        addCardCollectionPresenter.OnEndMove += ChangeStateToOpenPageBook;

        addCardCollectionPresenter.ActivateCurrentCard();

        ActivateSwipeAnimation();
    }

    private void ActivateSwipeAnimation()
    {
        indexCard = (addCardCollectionPresenter.CurrentAddCard.CardInfo.Number + 1) % 9;

        Debug.Log($"SWIPE_CARD_{indexCard}");

        if(indexCard == 0)
        {
            swipeAnimationPresenter.ActivateAnimation("UpToDownCard_9");
        }
        else
        {
            swipeAnimationPresenter.ActivateAnimation($"UpToDownCard_{indexCard}");
        }

    }

    private void DeactivateSwipeAnimation()
    {
        if (indexCard == 0)
        {
            swipeAnimationPresenter.DeactivateAnimation("UpToDownCard_9");
        }
        else
        {
            swipeAnimationPresenter.DeactivateAnimation($"UpToDownCard_{indexCard}");
        }
    }

    public void ExitState()
    {
        addCardCollectionPresenter.OnEndMove_Value -= OnEndMove;
        addCardCollectionPresenter.OnEndMove -= ChangeStateToOpenPageBook;

        DeactivateSwipeAnimation();
    }

    private void OnEndMove(CardInfo cardInfo)
    {
        cardCollectionPresenter.UnlockCard(cardInfo.Number);
    }

    private void ChangeStateToOpenPageBook()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<OpenBookPage_MenuScene>());
    }
}
