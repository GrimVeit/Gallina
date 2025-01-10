using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPackModel
{
    public event Action OnShow;
    public event Action OnHide;
    public event Action<int> OnGetData;

    private ShopItemPack shopItemPack;

    private IMoneyProvider moneyProvider;

    public ShopPackModel(IMoneyProvider moneyProvider)
    {
        this.moneyProvider = moneyProvider;
    }

    public void ShowBuy()
    {
        OnShow?.Invoke();
    }

    public void HideBuy()
    {
        OnHide?.Invoke();
    }

    public void SetData(ShopItemPack pack)
    {
        shopItemPack = pack;

        OnGetData?.Invoke(shopItemPack.Pack.Coins);
    }
}
