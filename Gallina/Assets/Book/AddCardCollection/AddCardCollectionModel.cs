using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCardCollectionModel
{
    public event Action OnMoveCurrentCard;
    public event Action<CardInfo> OnAddNewCard;

    public void AddCard(CardInfo cardInfo)
    {
        OnAddNewCard?.Invoke(cardInfo);
    }

    public void MoveCurrentCard()
    {
        OnMoveCurrentCard?.Invoke();
    }
}
