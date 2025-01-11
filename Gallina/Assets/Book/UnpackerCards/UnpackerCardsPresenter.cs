using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackerCardsPresenter
{
    private UnpackerCardsModel model;
    private UnpackerCardsView view;

    public UnpackerCardsPresenter(UnpackerCardsModel model, UnpackerCardsView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        view.Dispose();
    }

    private void ActivateEvents()
    {
        model.OnActivatedCards += view.ActivateCards;
        model.OnSpawnNewCard += view.SpawnNewCard;
        model.OnSpawnDuplicateCard += view.SpawnDuplicateCard;
    }

    private void DeactivateEvents()
    {
        model.OnActivatedCards -= view.ActivateCards;
        model.OnSpawnNewCard -= view.SpawnNewCard;
        model.OnSpawnDuplicateCard -= view.SpawnDuplicateCard;
    }

    #region Input

    public void SpawnCards(ShopItemPack pack)
    {
        model.SpawnCards(pack);
    }

    public void ActivateCards()
    {
        model.ActivateCards();
    }

    #endregion
}
