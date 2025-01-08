using DG.Tweening;
using UnityEngine;

public class BookPage : MonoBehaviour
{
    public int Index => index;

    [SerializeField] private int index;
    [SerializeField] private float duration;
    [SerializeField] private Transform transformPage;

    private Vector3 vectorRotateClose = new Vector3(0, -180, 0);
    private Vector3 vectorRotateOpen = Vector3.zero;

    private Tween tweenRotate;

    public void ClosePage()
    {
        tweenRotate?.Kill();

        tweenRotate = transformPage.DORotate(vectorRotateClose, duration).SetEase(Ease.InOutCubic);
    }

    public void OpenPage()
    {
        tweenRotate?.Kill();

        tweenRotate = transformPage.DORotate(vectorRotateOpen, duration).SetEase(Ease.InOutCubic);
    }
}
