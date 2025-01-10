using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private UIMainMenuRoot menuRootPrefab;

    private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private ShopItemSelectPresenter shopItemSelectPresenter;
    private ShopPackPresenter shopPackPresenter;

    private BookPagesPresenter bookPagesPresenter;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = Instantiate(menuRootPrefab);
 
        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter
            (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
            viewContainer.GetView<SoundView>());

        particleEffectPresenter = new ParticleEffectPresenter
            (new ParticleEffectModel(),
            viewContainer.GetView<ParticleEffectView>());

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());

        bookPagesPresenter = new BookPagesPresenter(new BookPagesModel(), viewContainer.GetView<BookPagesView>());

        shopItemSelectPresenter = new ShopItemSelectPresenter(new ShopItemSelectModel(), viewContainer.GetView<ShopItemSelectView>());

        shopPackPresenter = new ShopPackPresenter(new ShopPackModel(bankPresenter), viewContainer.GetView<ShopPackView>());

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();


        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();
        bookPagesPresenter.Initialize();
        shopItemSelectPresenter.Initialize();
        shopPackPresenter.Initialize();
    }

    private void ActivateEvents()
    {
        ActivateTransitionsSceneEvents();

        shopItemSelectPresenter.OnSelectPack_Data += shopPackPresenter.SetData;
        shopItemSelectPresenter.OnSelect += shopPackPresenter.ShowBuy;
        shopItemSelectPresenter.OnUnselect += shopPackPresenter.HideBuy;
    }

    private void DeactivateEvents()
    {
        DeactivateTransitionsSceneEvents();

        shopItemSelectPresenter.OnSelectPack_Data -= shopPackPresenter.SetData;
        shopItemSelectPresenter.OnSelect -= shopPackPresenter.ShowBuy;
        shopItemSelectPresenter.OnUnselect -= shopPackPresenter.HideBuy;
    }

    private void ActivateTransitionsSceneEvents()
    {

    }

    private void DeactivateTransitionsSceneEvents()
    {

    }

    private void Deactivate()
    {
        sceneRoot.Deactivate();
        soundPresenter?.Dispose();
    }

    private void Dispose()
    {
        DeactivateEvents();

        soundPresenter?.Dispose();
        sceneRoot?.Dispose();
        particleEffectPresenter?.Dispose();
        bankPresenter?.Dispose();
        bookPagesPresenter?.Dispose();
        shopItemSelectPresenter?.Dispose();
        shopPackPresenter?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Input actions

    public event Action OnGoToGame
    {
        add { sceneRoot.OnGoToGame += value; }
        remove { sceneRoot.OnGoToGame -= value; }
    }

    #endregion
}
