using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemSelectView : View
{
    [SerializeField] private Transform transformSelect;

    public void SelectPack(ShopItemPack itemPack)
    {
        itemPack.SelectPack(transformSelect.position, Vector3.one);
    }

    public void UnselectPack(ShopItemPack itemPack)
    {
        itemPack.UnselectPack();
    }
}
