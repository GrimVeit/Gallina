using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionPanel_MainMenuScene : MovePanel
{
    [SerializeField] private Button buttonBack;

    public override void Initialize()
    {
        base.Initialize();

        buttonBack.onClick.AddListener(HandleClickToBackButton);
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonBack.onClick.RemoveListener(HandleClickToBackButton);
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();
    }

    #region Input

    public event Action OnClickToBackButton;

    private void HandleClickToBackButton()
    {
        OnClickToBackButton?.Invoke();
    }
    #endregion
}
