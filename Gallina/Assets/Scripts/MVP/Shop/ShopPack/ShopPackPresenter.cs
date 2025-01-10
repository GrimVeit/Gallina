using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPackPresenter
{
    private ShopPackModel model;
    private ShopPackView view;

    public ShopPackPresenter(ShopPackModel model, ShopPackView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        model.OnGetData += view.SetCoins;
        model.OnShow += view.Show;
        model.OnHide += view.Hide;
    }

    private void DeactivateEvents()
    {
        model.OnGetData += view.SetCoins;
        model.OnShow += view.Show;
        model.OnHide += view.Hide;
    }

    #region

    public void ShowBuy()
    {
        model.ShowBuy();
    }

    public void HideBuy()
    {
        model.HideBuy();
    }

    public void SetData(ShopItemPack pack)
    {
        model.SetData(pack);
    }

    #endregion
}
