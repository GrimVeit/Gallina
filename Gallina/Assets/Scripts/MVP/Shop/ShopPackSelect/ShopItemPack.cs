using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItemPack : MonoBehaviour, IPointerDownHandler
{
    public event Action OnEndSelect;
    public event Action<ShopItemPack> OnSelectPack;
    public Pack Pack;

    private float timeMove = 0.5f;

    private Tween tweenMove;
    private bool isSelect;

    public void SelectPack(Vector2 vectorMove)
    {
        tweenMove?.Kill();
        isSelect = true;
        tweenMove = transform.DOMove(vectorMove, timeMove).OnComplete(()=> OnEndSelect?.Invoke());
    }

    public void UnselectPack()
    {
        tweenMove?.Kill();
        tweenMove = transform.DOLocalMove(Vector3.zero, timeMove).OnComplete(()=> { isSelect = false; });
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isSelect) return;

        OnSelectPack?.Invoke(this);
    }
}

[Serializable]
public class Pack
{
    public List<TypeItem> Items;
    public Sprite SpritePack;
    public int Coins;
}

public enum TypeItem
{
    common, rare, epic, legendary, gold
}
