using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackerPackPresenter
{
    private UnpackerPackModel model;
    private UnpackerPackView view;

    public UnpackerPackPresenter(UnpackerPackModel model, UnpackerPackView view)
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
        model.OnSpawnPack += view.SpawnPack;
        model.OnMovePackToOpen += view.MovePackToOpen;
    }

    private void DeactivateEvents()
    {
        model.OnSpawnPack -= view.SpawnPack;
        model.OnMovePackToOpen -= view.MovePackToOpen;
    }

    #region Input

    public event Action OnOpenPack
    {
        add { view.OnOpenPack += value; }
        remove { view.OnOpenPack -= value; }
    }

    public event Action OnClosePack
    {
        add { view.OnClosePack += value; }
        remove { view.OnClosePack -= value; }
    }

    public void SpawnPack(ShopItemPack pack)
    {
        model.SpawnPack(pack.Pack);
    }

    public void MovePackToOpen()
    {
        model.MovePackToOpen();
    }

    #endregion
}
