using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwipeAnimation : MonoBehaviour, IIdentify
{
    public abstract void SetSwipe(Swipe swipe);
    public abstract void ActivateAnimation();
    public abstract void DeactivateAnimation();


    public abstract string GetID();
}
