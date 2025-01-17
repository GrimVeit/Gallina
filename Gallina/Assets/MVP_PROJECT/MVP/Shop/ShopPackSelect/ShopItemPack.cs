using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItemPack : MonoBehaviour
{
    public Transform Transform => transformItem;
    [SerializeField] private Transform transformItem;

    public event Action OnEndSelect;
    public event Action OnSelectPack;
    public Pack Pack;

    private float timeMove = 0.5f;

    private Tween tweenMove;
    private Tween tweenScale;

    public void SelectPack(Vector2 vectorMove, Vector2 vectorScale)
    {
        tweenMove?.Kill();
        tweenScale?.Kill();

        tweenMove = transform.DOMove(vectorMove, timeMove).OnComplete(()=> OnEndSelect?.Invoke());
        tweenScale = transform.DOScale(vectorScale, timeMove);
    }

    public void UnselectPack()
    {
        tweenMove?.Kill();
        tweenScale?.Kill();

        tweenMove = transform.DOLocalMove(Vector3.zero, timeMove);
        tweenScale = transform.DOScale(Vector2.one, timeMove);
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
