using System;
using UnityEngine;
using UnityEngine.UI;

public class FailPanel_MiniGameScene : MovePanel
{
    [SerializeField] private Button buttonExit;
    [SerializeField] private Button buttonRestart;

    public override void Initialize()
    {
        base.Initialize();

        buttonExit.onClick.AddListener(HandleClickToExitButton);
        buttonRestart.onClick.AddListener(HandleClickToRestartButton);
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonExit.onClick.RemoveListener(HandleClickToExitButton);
        buttonRestart.onClick.RemoveListener(HandleClickToRestartButton);
    }

    #region Input

    public event Action OnClickToButtonExit;
    public event Action OnClickToButtonRestart;

    private void HandleClickToExitButton()
    {
        OnClickToButtonExit?.Invoke();
    }

    private void HandleClickToRestartButton()
    {
        OnClickToButtonRestart?.Invoke();
    }

    #endregion
}
