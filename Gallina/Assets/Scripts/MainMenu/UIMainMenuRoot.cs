using System;
using UnityEngine;

public class UIMainMenuRoot : MonoBehaviour
{
    [SerializeField] private MainPanel_MainMenuScene mainPanel;
    [SerializeField] private ShopPanel_MainMenuScene shopPanel;
    [SerializeField] private OpenPackPanel_MainMenuScene openPackPanel;
    [SerializeField] private CollectionPanel_MainMenuScene collectionPanel;

    private ISoundProvider soundProvider;

    private Panel currentPanel;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void Initialize()
    {
        mainPanel.Initialize();
        openPackPanel.Initialize();
        shopPanel.Initialize();
        collectionPanel.Initialize();
    }

    public void Activate()
    {
        mainPanel.OnGoToShop += OpenShopPanel;

        shopPanel.OnClickCollectionsButton += OpenCollectionPanel;
        shopPanel.OnClickBackButton += OpenMainPanel;

        collectionPanel.OnClickToBackButton += OpenShopPanel;
    }

    public void Deactivate()
    {
        mainPanel.OnGoToShop -= OpenShopPanel;

        shopPanel.OnClickCollectionsButton -= OpenCollectionPanel;
        shopPanel.OnClickBackButton -= OpenMainPanel;

        collectionPanel.OnClickToBackButton -= OpenShopPanel;

        currentPanel.DeactivatePanel();
    }

    public void Dispose()
    {
        mainPanel.Dispose();
        shopPanel?.Dispose();
        openPackPanel?.Dispose();
        collectionPanel.Dispose();
    }

    public void OpenMainPanel()
    {
        OpenPanel(mainPanel);
    }

    public void OpenShopPanel()
    {
        OpenPanel(shopPanel);
    }

    public void OpenCollectionPanel()
    {
        OpenPanel(collectionPanel);
    }

    public void OpenPackPanel()
    {
        OpenPanel(openPackPanel);
    }
    

    private void OpenPanel(Panel panel)
    {
        if(currentPanel == panel) return;

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


    #region Input Actions

    public event Action OnGoToGame
    {
        add { shopPanel.OnClickPlayButton += value; }
        remove { shopPanel.OnClickPlayButton -= value; }
    }

    #endregion
}
