using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMiniGameSceneRoot : MonoBehaviour
{
    [SerializeField] private MiniGamePanel_MiniGameScene mainPanel;
    [SerializeField] private HeaderPanel_MiniGameScene headerPanel;
    [SerializeField] private FooterPanel_MiniGameScene footerPanel;

    private Panel currentPanel;

    public void Initialize()
    {
        mainPanel.Initialize();
    }

    public void Dispose()
    {
        mainPanel.Dispose();
    }

    public void Activate()
    {
        OpenMainPanel();
        OpenFooterPanel();
        OpenHeaderPanel();
    }

    public void Deactivate()
    {
        CloseOtherPanel(currentPanel);
    }


    public void OpenMainPanel()
    {
        OpenPanel(mainPanel);
    }

    public void OpenFooterPanel()
    {
        OpenOtherPanel(footerPanel);
    }

    public void CloseFooterPanel()
    {
        CloseOtherPanel(footerPanel);
    }

    public void OpenHeaderPanel()
    {
        OpenOtherPanel(headerPanel);
    }

    public void CloseHeaderPanel()
    {
        CloseOtherPanel(headerPanel);
    }



    private void OpenPanel(Panel panel)
    {
        if (currentPanel != null)
            currentPanel.DeactivatePanel();

        currentPanel = panel;
        currentPanel.ActivatePanel();

    }

    private void OpenOtherPanel(Panel panel)
    {
        panel.ActivatePanel();
    }

    private void CloseOtherPanel(Panel panel)
    {
        panel.DeactivatePanel();
    }



    #region Input

    public event Action OnGoToMainMenu
    {
        add { headerPanel.OnGoToMainMenu += value; }
        remove { headerPanel.OnGoToMainMenu -= value; }
    }

    #endregion
}
