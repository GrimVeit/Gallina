using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel_MainMenuScene : MovePanel
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button collections_Button;

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        backButton.onClick.AddListener(HandlerClickToBackButton);
        collections_Button.onClick.AddListener(HandleClickToCollectionButton);
        playButton.onClick.AddListener(HandleClickToPlayButton);
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        backButton.onClick.RemoveListener(HandlerClickToBackButton);
        collections_Button.onClick.RemoveListener(HandleClickToCollectionButton);
        playButton.onClick.RemoveListener(HandleClickToPlayButton);
    }

    #region Input

    public event Action OnClickBackButton;
    public event Action OnClickCollectionsButton;
    public event Action OnClickPlayButton;


    private void HandlerClickToBackButton()
    {
        OnClickBackButton?.Invoke();
    }

    private void HandleClickToCollectionButton()
    {
        OnClickCollectionsButton?.Invoke();
    }

    private void HandleClickToPlayButton()
    {
        OnClickPlayButton?.Invoke();
    }

    #endregion
}
