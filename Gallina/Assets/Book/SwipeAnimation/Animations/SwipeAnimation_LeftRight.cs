using System;
using DG.Tweening;
using UnityEngine;

public class SwipeAnimation_LeftRight : SwipeAnimation
{
    public override string GetID() => id;

    [SerializeField] private string id;

    [SerializeField] private Transform parent;
    [SerializeField] private Transform transformMiddle;
    [SerializeField] private Transform transformLeft;
    [SerializeField] private Transform transformRight;

    private Swipe swipePrefab;

    private Swipe currentSwipe;

    public override void SetSwipe(Swipe swipe)
    {
        swipePrefab = swipe;
    }

    public override void ActivateAnimation()
    {
        currentSwipe = Instantiate(swipePrefab, parent);
        currentSwipe.SetScale(Vector2.zero);
        ScaleToMaxFromLeft();
    }


    private void MoveToLeft()
    {
        currentSwipe.MoveTo(transformLeft.position, 1f, Ease.InOutCubic, ScaleToMinFromLeft);
    }

    private void MoveToRight()
    {
        currentSwipe.MoveTo(transformRight.position, 1f, Ease.InOutCubic, ScaleToMinFromRight);
    }

    private void ScaleToMinFromLeft()
    {
        ScaleMin(ScaleToMaxFromLeft);
    }

    private void ScaleToMinFromRight()
    {
        ScaleMin(ScaleToMaxFromRight);
    }

    private void ScaleToMaxFromLeft()
    {
        currentSwipe.transform.position = transformMiddle.position;
        ScaleMax(MoveToRight);
    }

    private void ScaleToMaxFromRight()
    {
        currentSwipe.transform.position = transformMiddle.position;
        ScaleMax(MoveToLeft);
    }

    private void ScaleMin(Action actionToEnd = null)
    {
        currentSwipe.ScaleTo(Vector2.zero, 0.1f, actionToEnd);
    }

    private void ScaleMax(Action actionToEnd = null)
    {
        currentSwipe.ScaleTo(Vector2.one, 0.1f, actionToEnd);
    }

    public override void DeactivateAnimation()
    {
        currentSwipe?.KillAllTweens();
        currentSwipe?.DestroyScale();
    }
}
