using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePresenter
{
    private SwipeModel swipeModel;
    private SwipeView swipeView;

    public SwipePresenter(SwipeModel swipeModel, SwipeView swipeView)
    {
        this.swipeModel = swipeModel;
        this.swipeView = swipeView;
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

    }

    private void DeactivateEvents()
    {

    }
}
