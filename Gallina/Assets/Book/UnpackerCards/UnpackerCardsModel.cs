using System;
using UnityEngine;

public class UnpackerCardsModel
{
    public event Action OnActivatedCards;

    public event Action<CardInfo> OnSpawnDuplicateCard;
    public event Action<CardInfo> OnSpawnNewCard;

    private Cards cards;

    private ICardCollection cardCollection;

    public UnpackerCardsModel(Cards cards, ICardCollection cardCollection)
    {
        this.cards = cards;
        this.cardCollection = cardCollection;
    }

    public void SpawnCards(ShopItemPack pack)
    {
        Debug.Log(pack.Pack.Coins);

        for (int i = 0; i < pack.Pack.Items.Count; i++)
        {
            GetRandom(pack.Pack.Items[i]);
        }
    }

    private void GetRandom(TypeCard typeCard)
    {
        var cardInfo = cards.GetRandomCardInfo(typeCard);

        Debug.Log(cardCollection);

        if (cardCollection.IsOpenCard(cardInfo.Number))
        {
            OnSpawnDuplicateCard?.Invoke(cardInfo);
        }
        else
        {
            OnSpawnNewCard?.Invoke(cardInfo);
        }
    }

    public void ActivateCards()
    {
        OnActivatedCards?.Invoke();
    }
}
