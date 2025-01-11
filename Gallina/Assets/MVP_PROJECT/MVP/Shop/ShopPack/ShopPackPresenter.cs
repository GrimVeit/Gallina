using System;
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

        view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        view.Dispose();
    }

    private void ActivateEvents()
    {
        view.OnClickToBuyButton += model.BuyPack;

        model.OnGetData += view.SetCoins;
        model.OnShow += view.Show;
        model.OnHide += view.Hide;
    }

    private void DeactivateEvents()
    {
        view.OnClickToBuyButton -= model.BuyPack;

        model.OnGetData += view.SetCoins;
        model.OnShow += view.Show;
        model.OnHide += view.Hide;
    }

    #region Input

    public event Action<ShopItemPack> OnBuyItemPack_Value
    {
        add { model.OnBuyItemPack_Value += value; }
        remove { model.OnBuyItemPack_Value -= value; }
    }

    public event Action OnBuyItemPack
    {
        add { model.OnBuyItemPack += value; }
        remove { model.OnBuyItemPack -= value; }
    }

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
