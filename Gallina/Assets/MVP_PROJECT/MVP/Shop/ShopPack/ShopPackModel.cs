using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPackModel
{
    public event Action<ShopItemPack> OnBuyItemPack_Value;
    public event Action OnBuyItemPack;

    public event Action OnShow;
    public event Action OnHide;
    public event Action<int> OnGetData;

    private ShopItemPack currentItemPack;

    private IMoneyProvider moneyProvider;

    public ShopPackModel(IMoneyProvider moneyProvider)
    {
        this.moneyProvider = moneyProvider;
    }

    public void BuyPack()
    {
        if (moneyProvider.CanAfford(currentItemPack.Pack.Coins))
        {
            OnBuyItemPack_Value?.Invoke(currentItemPack);
            OnBuyItemPack?.Invoke();

            moneyProvider.SendMoney(-currentItemPack.Pack.Coins);
        }
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
        currentItemPack = pack;

        OnGetData?.Invoke(currentItemPack.Pack.Coins);
    }
}
