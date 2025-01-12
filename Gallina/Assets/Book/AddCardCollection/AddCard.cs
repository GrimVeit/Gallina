using System;
using DG.Tweening;
using UnityEngine;

public class AddCard : MonoBehaviour
{
    public event Action<CardInfo> OnEndMove;

    [SerializeField] private Transform transformSpawn;
    [SerializeField] private Transform transformParent;
    [SerializeField] private Transform transformEnd;

    private Card currentCard;
    private CardInfo currentCardInfo;

    public void SetData(Card cardPrefab, CardInfo cardInfo)
    {
        currentCardInfo = cardInfo;

        currentCard = Instantiate(cardPrefab, transformParent);
        currentCard.transform.SetPositionAndRotation(transformSpawn.position, transformSpawn.rotation);
        currentCard.SetData(currentCardInfo.Sprite);
        currentCard.gameObject.SetActive(false);
    }

    public void ActivateCard()
    {
        currentCard?.gameObject.SetActive(true);
    }

    public void DestroyCard()
    {
        Destroy(currentCard.gameObject);
    }

    public void MoveCard()
    {
        currentCard.transform.DOMove(transformEnd.position, 1).OnComplete(()=> OnEndMove?.Invoke(currentCardInfo));
    }
}
