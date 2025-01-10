using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemSelectModel
{

    public event Action<ShopItemPack> OnSelectPack_Data;
    public event Action OnSelect;
    public event Action<ShopItemPack> OnUnselectPack;
    public event Action OnUnselect;

    private ShopItemPack currentSelectPack;

    public void SelectPack(ShopItemPack pack)
    {
        if(currentSelectPack != null)
        {
            OnUnselectPack?.Invoke(currentSelectPack);
            OnUnselect?.Invoke();
        }

        currentSelectPack = pack;
        OnSelectPack_Data?.Invoke(currentSelectPack);
    }

    public void EndSelect()
    {
        OnSelect?.Invoke();
    }
}
