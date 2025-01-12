using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCardCollectionModel
{
    public event Action<CardInfo> OnAddNeweCard;

    public void AddCard(CardInfo cardInfo)
    {
        OnAddNeweCard?.Invoke(cardInfo);
    }
}
