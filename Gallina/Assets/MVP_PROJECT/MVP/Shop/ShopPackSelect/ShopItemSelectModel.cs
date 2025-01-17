using System;

public class ShopItemSelectModel
{

    public event Action OnEndSelect;

    public event Action<ShopItemPack> OnSelectPack;
    public event Action<ShopItemPack> OnUnselectPack;
    public event Action OnUnselect;

    private ShopItemPack currentSelectPack;

    public void SelectPack(ShopItemPack pack)
    {
        if(currentSelectPack != null)
        {
            currentSelectPack.OnEndSelect -= OnSelectPackMethod;
            OnUnselectPack?.Invoke(currentSelectPack);
            OnUnselect?.Invoke();
        }

        currentSelectPack = pack;
        currentSelectPack.OnEndSelect += OnSelectPackMethod;
        OnSelectPack?.Invoke(currentSelectPack);
    }

    public void Unselect()
    {
        if (currentSelectPack != null)
        {
            OnUnselectPack?.Invoke(currentSelectPack);
            OnUnselect?.Invoke();
        }
    }


    private void OnSelectPackMethod()
    {
        OnEndSelect?.Invoke();
    }
}
