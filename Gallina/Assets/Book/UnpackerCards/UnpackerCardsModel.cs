using System;
using System.Collections.Generic;
using UnityEngine;

public class UnpackerCardsModel
{
    public event Action OnMoveCardToClose_Left;
    public event Action OnMoveCardToClose_Right;

    public event Action OnActivatedCards;

    public event Action<CardInfo> OnSpawnDuplicateCard;
    public event Action<CardInfo> OnSpawnNewCard;

    private Cards cards;

    private ICardCollection cardCollection;

    private List<CardInfo> newCardList = new List<CardInfo>();

    public UnpackerCardsModel(Cards cards, ICardCollection cardCollection)
    {
        this.cards = cards;
        this.cardCollection = cardCollection;
    }

    public void SpawnCards(Pack pack)
    {
        newCardList.Clear();

        for (int i = 0; i < pack.Items.Count; i++)
        {
            GetRandom(pack.Items[i]);
        }
    }

    private void GetRandom(TypeCard typeCard)
    {
        var cardInfo = cards.GetRandomCardInfo(typeCard);

        //Debug.Log(cardCollection);

        if (cardCollection.IsOpenCard(cardInfo.Number, this))
        {
            OnSpawnDuplicateCard?.Invoke(cardInfo);
        }
        else
        {
            if (IsAlreadyOpen(cardInfo))
            {
                OnSpawnDuplicateCard?.Invoke(cardInfo);
            }
            else
            {
                OnSpawnNewCard?.Invoke(cardInfo);
                newCardList.Add(cardInfo);
            }
        }
    }

    private bool IsAlreadyOpen(CardInfo cardInfo)
    {
        return newCardList.Contains(cardInfo);
    }

    public void ActivateCards()
    {
        OnActivatedCards?.Invoke();
    }

    public void MoveCardToClose_Right()
    {
        OnMoveCardToClose_Right?.Invoke();
    }

    public void MoveCardToClose_Left()
    {
        OnMoveCardToClose_Left?.Invoke();
    }
}
