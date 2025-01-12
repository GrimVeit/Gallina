using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemSelectPresenter
{
    private ShopItemSelectModel model;
    private ShopItemSelectView view;

    public ShopItemSelectPresenter(ShopItemSelectModel model, ShopItemSelectView view)
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
        view.OnSelectPack += model.SelectPack;
        view.OnEndSelect += model.EndSelect;

        model.OnSelectPack_Data += view.SelectPack;
        model.OnUnselectPack += view.UnselectPack;
    }

    private void DeactivateEvents()
    {
        view.OnSelectPack -= model.SelectPack;
        view.OnEndSelect -= model.EndSelect;

        model.OnSelectPack_Data -= view.SelectPack;
        model.OnUnselectPack -= view.UnselectPack;
    }

    #region Input

    public event Action<ShopItemPack> OnSelectPack_Data
    {
        add { model.OnSelectPack_Data += value; }
        remove {  model.OnSelectPack_Data -= value; }
    }

    public event Action OnSelect
    {
        add { model.OnSelect += value; }
        remove { model.OnSelect -= value; }
    }

    public event Action OnUnselect
    {
        add { model.OnUnselect += value; }
        remove { model.OnUnselect -= value; }
    }

   
    public void Unselect()
    {
        model.Unselect();
    }

    #endregion
}
