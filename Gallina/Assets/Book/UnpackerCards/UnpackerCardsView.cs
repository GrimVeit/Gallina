using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnpackerCardsView : View
{
    [SerializeField] private UnpackCard unpackCardPrefab;
    [SerializeField] private Transform transformParentSpawn;
    [SerializeField] private Transform transformSpawn;
    [SerializeField] private Transform transformLeftEnd;
    [SerializeField] private Transform transformRightEnd;

    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;

    [SerializeField] private List<UnpackCard> unpackedCards;

    private UnpackCard currentUnpackCard;

    private bool isActive;

    public void Initialize()
    {
        buttonLeft.onClick.AddListener(MoveCardToClose_Left);
        buttonRight.onClick.AddListener(MoveCardToClose_Right);
    }

    public void Dispose()
    {
        buttonLeft.onClick.RemoveListener(MoveCardToClose_Left);
        buttonRight.onClick.RemoveListener(MoveCardToClose_Right);
    }

    public void SpawnNewCard(CardInfo cardInfo)
    {
        var currentCard = Instantiate(unpackCardPrefab, transformParentSpawn);
        currentCard.transform.position = transformSpawn.position;
        currentCard.transform.eulerAngles = new Vector3(0, 90, 0);
        currentCard.SetData(cardInfo.Sprite);

        unpackedCards.Add(currentCard);
    }

    public void SpawnDuplicateCard(CardInfo cardInfo)
    {
        var currentCard = Instantiate(unpackCardPrefab, transformParentSpawn);
        currentCard.transform.position = transformSpawn.position;
        currentCard.transform.eulerAngles = new Vector3(0, 90, 0);
        currentCard.SetData(cardInfo.Sprite);
        currentCard.ActivateDuplicate();

        unpackedCards.Add(currentCard);
    }

    public void ClearCards()
    {
        for (int i = 0; i < unpackedCards.Count; i++)
        {
            unpackedCards[i].DeatroyCard();
        }

        unpackedCards.Clear();
    }

    public void ActivateCards()
    {
        unpackedCards.ForEach(task => task.RotateTo(Vector3.zero, 0.2f));

        currentUnpackCard = unpackedCards[unpackedCards.Count - 1];

        isActive = false;
    }

    private void MoveCardToClose_Right()
    {
        if(isActive) return;

        isActive = true;

        currentUnpackCard?.MoveTo(transformLeftEnd.position, 0.4f, SetNextCard);
        currentUnpackCard?.RotateTo(new Vector3(0, 0, 30), 0.3f);
    }

    private void MoveCardToClose_Left()
    {

        if (isActive) return;

        isActive = true;

        currentUnpackCard?.MoveTo(transformRightEnd.position, 0.4f, SetNextCard);
        currentUnpackCard?.RotateTo(new Vector3(0, 0, -30), 0.3f);
    }


    private void SetNextCard()
    {
        unpackedCards.Remove(currentUnpackCard);

        currentUnpackCard.DeatroyCard();

        if(unpackedCards.Count > 0)
        {
            currentUnpackCard = unpackedCards[unpackedCards.Count - 1];
        }
        else
        {
            Debug.Log("FINISH");
            ClearCards();
            OnAllCardsOpen?.Invoke();
        }

        isActive = false;
    }

    #region Input

    public event Action OnAllCardsOpen;

    #endregion
}
