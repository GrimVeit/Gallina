using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCardCollectionView : MonoBehaviour
{
    [SerializeField] private List<AddCard> allAddCards = new List<AddCard>();

    [SerializeField] private List<AddCard> usedAddCards = new List<AddCard>();

    private AddCard currentAddCard;

    private bool isActive;

    [SerializeField] private Button buttonActivate;

    public void Initialize()
    {

    }

    public void Dispose()
    {
        
    }

    public void AddNewCard(CardInfo cardInfo)
    {
        var card = allAddCards[cardInfo.Number];

        usedAddCards.Add(card);
    }

    public void ActivateAddCards()
    {
        currentAddCard = usedAddCards[0];

        isActive = false;
    }

    private void MoveCardToClose_Right()
    {
        if (isActive) return;

        isActive = true;

        currentAddCard.MoveCard();
    }

    public void OnEndMoveCard(CardInfo cardInfo)
    {
        OnMoveCardEnd?.Invoke(cardInfo);

        SetNextAddCard();
    }

    private void SetNextAddCard()
    {
        usedAddCards.Remove(currentAddCard);

        if(usedAddCards.Count > 0)
        {
            currentAddCard = usedAddCards[0];
        }
        else
        {
            OnFinish?.Invoke();
        }
    }

    #region Input

    public event Action OnFinish;

    public event Action<CardInfo> OnMoveCardEnd;

    #endregion
}
