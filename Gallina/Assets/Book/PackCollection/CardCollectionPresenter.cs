using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollectionPresenter
{
    private CardCollectionModel model;
    private CardCollectionView view;

    public CardCollectionPresenter(CardCollectionModel model, CardCollectionView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        model.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        model.Dispose();
    }

    private void ActivateEvents()
    {
        model.OnOpenCard += view.OpenCard;
    }

    private void DeactivateEvents()
    {
        model.OnOpenCard -= view.OpenCard;
    }
}
