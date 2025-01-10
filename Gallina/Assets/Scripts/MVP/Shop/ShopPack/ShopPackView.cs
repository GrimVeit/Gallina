using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ShopPackView : View
{
    [SerializeField] private GameObject objectBuy;
    [SerializeField] private float timeScale;
    [SerializeField] private TextMeshProUGUI textCoins;

    private Tween tweenScale;

    public void Show()
    {
        objectBuy.SetActive(true);
        tweenScale = objectBuy.transform.DOScale(Vector3.one, timeScale);
    }

    public void Hide()
    {
        if(tweenScale != null)
        {
            tweenScale.Kill();
            objectBuy.SetActive(false);
        }

        tweenScale = objectBuy.transform.DOScale(Vector3.zero, timeScale).OnComplete(()=> objectBuy.SetActive(false));
    }

    public void SetCoins(int coins)
    {
        textCoins.text = coins.ToString();
    }
}
