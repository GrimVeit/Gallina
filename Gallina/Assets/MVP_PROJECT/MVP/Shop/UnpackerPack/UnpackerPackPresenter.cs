using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackerPackPresenter
{
    private UnpackerPackModel model;
    private UnpackerPackView view;

    public UnpackerPackPresenter(UnpackerPackModel model, UnpackerPackView view)
    {
        this.model = model;
        this.view = view;
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

    public void SetPack(Pack pack)
    {

    }
}
