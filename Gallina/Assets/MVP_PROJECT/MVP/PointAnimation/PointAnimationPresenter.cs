using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAnimationPresenter
{
    private PointAnimationModel pointAnimationModel;
    private IPointAnimationView pointAnimationView;

    public PointAnimationPresenter(PointAnimationModel pointAnimationModel, IPointAnimationView pointAnimationView)
    {
        this.pointAnimationModel = pointAnimationModel;
        this.pointAnimationView = pointAnimationView;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        pointAnimationModel.OnPlayAnimation += pointAnimationView.PlayAnimation;
        pointAnimationModel.OnPlayAnimation_Position += pointAnimationView.PlayAnimation;
    }

    private void DeactivateEvents()
    {
        pointAnimationModel.OnPlayAnimation -= pointAnimationView.PlayAnimation;
        pointAnimationModel.OnPlayAnimation_Position -= pointAnimationView.PlayAnimation;
    }

    #region Input

    public void PlayAnimation()
    {
        pointAnimationModel.PlayAnimation();
    }

    public void PlayAnimation(Vector3 vector)
    {
        pointAnimationModel.PlayAnimation(vector);
    }

    #endregion
}

public interface IPointAnimationView
{
    void PlayAnimation();
    void PlayAnimation(Vector3 vector);
}
