using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemSelectView : View
{
    public event Action OnEndSelect;
    public event Action<ShopItemPack> OnSelectPack;

    [SerializeField] private List<ShopItemPack> packs = new List<ShopItemPack>();

    [SerializeField] private Transform transformSelect;

    public void Initialize()
    {
        packs.ForEach(task =>
        {
            task.OnEndSelect += HandleEndSelect;
            task.OnSelectPack += HandleSelectPack;
        });
    }

    public void Dispose()
    {
        packs.ForEach(task =>
        {
            task.OnEndSelect -= HandleEndSelect;
            task.OnSelectPack -= HandleSelectPack;
        });
    }

    public void SelectPack(ShopItemPack pack)
    {
        pack.SelectPack(transformSelect.position, new Vector2(2, 2));
    }

    public void UnselectPack(ShopItemPack pack)
    {
        pack.UnselectPack();
    }

    #region Input

    private void HandleSelectPack(ShopItemPack pack)
    {
        OnSelectPack?.Invoke(pack);
    }

    private void HandleEndSelect()
    {
        OnEndSelect?.Invoke();
    }

    #endregion
}
