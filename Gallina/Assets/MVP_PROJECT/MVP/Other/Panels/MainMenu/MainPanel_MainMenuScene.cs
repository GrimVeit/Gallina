using System;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_MainMenuScene : MovePanel
{
    [SerializeField] private Button play_Button;

    public event Action OnGoToShop;

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        play_Button.onClick.AddListener(HandleGoToChooseGamePanel);
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        play_Button.onClick.RemoveListener(HandleGoToChooseGamePanel);
    }

    private void HandleGoToChooseGamePanel()
    {
        OnGoToShop?.Invoke();
    }
}
