using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItemPack : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform transformGroup;
    public event Action OnEndSelect;
    public event Action<ShopItemPack> OnSelectPack;
    public Pack Pack;

    private float timeMove = 0.5f;

    private Tween tweenMove;
    private Tween tweenScale;
    private bool isSelect;

    public void SelectPack(Vector2 vectorMove, Vector2 vectorScale)
    {
        tweenMove?.Kill();
        tweenScale?.Kill();

        isSelect = true;
        transform.parent.SetSiblingIndex(transformGroup.childCount - 1);
        tweenMove = transform.DOMove(vectorMove, timeMove).OnComplete(()=> OnEndSelect?.Invoke());
        tweenScale = transform.DOScale(vectorScale, timeMove);
    }

    public void UnselectPack()
    {
        tweenMove?.Kill();
        tweenScale?.Kill();

        tweenMove = transform.DOLocalMove(Vector3.zero, timeMove).OnComplete(()=> 
        { 
            isSelect = false;
            transform.parent.SetSiblingIndex(0);
        });
        tweenScale = transform.DOScale(Vector2.one, timeMove);
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
    public List<TypeCard> Items;
    public Sprite SpritePack;
    public int Coins;
}

public enum TypeCard
{
    common, rare, epic, legendary, gold
}
