using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwipeAnimationView : View
{
    [SerializeField] private List<SwipeAnimation> swipeAnimations = new List<SwipeAnimation>();

    [SerializeField] private Swipe swipePrefab;

    public void Initialize()
    {
        swipeAnimations.ForEach(data => data.SetSwipe(swipePrefab));
    }

    public void Dispose()
    {
        swipeAnimations.ForEach(data => data.DeactivateAnimation());
    }

    public void ActivateAnimation(string id)
    {
        swipeAnimations.FirstOrDefault(data => data.GetID() == id).ActivateAnimation();
    }

    public void DeactivateAnimation(string id)
    {
        swipeAnimations.FirstOrDefault(data => data.GetID() == id).DeactivateAnimation();
    }
}
