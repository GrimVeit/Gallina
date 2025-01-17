using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private Cards cards;
    [SerializeField] private UIMainMenuRoot menuRootPrefab;

    private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private ShopPackPresenter shopPackPresenter;
    private ShopItemSelectPresenter shopItemSelectPresenter;

    private UnpackerPackPresenter unpackerPackPresenter;
    private UnpackerCardsPresenter unpackerCardsPresenter;
    private AddCardCollectionPresenter addCardCollectionPresenter;

    private CardCollectionPresenter cardCollectionPresenter;

    private BookPagesPresenter bookPagesPresenter;

    private SwipeAnimationPresenter swipeAnimationPresenter;
    private SwipePresenter swipePresenter;

    private CardTypeCollectionPresenter cardTypeCollectionPresenter;

    private PackSpinPresenter packSpinPresenter;

    private MenuGlobalStateMachine menuGlobalStateMachine;

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

        cardCollectionPresenter = new CardCollectionPresenter(new CardCollectionModel(cards), viewContainer.GetView<CardCollectionView>());

        unpackerPackPresenter = new UnpackerPackPresenter(new UnpackerPackModel(), viewContainer.GetView<UnpackerPackView>());

        unpackerCardsPresenter = new UnpackerCardsPresenter(new UnpackerCardsModel(cards, cardCollectionPresenter), viewContainer.GetView<UnpackerCardsView>());

        addCardCollectionPresenter = new AddCardCollectionPresenter(new AddCardCollectionModel(), viewContainer.GetView<AddCardCollectionView>());

        shopPackPresenter = new ShopPackPresenter(new ShopPackModel(bankPresenter, 20), viewContainer.GetView<ShopPackView>());

        shopItemSelectPresenter = new ShopItemSelectPresenter(new ShopItemSelectModel(), viewContainer.GetView<ShopItemSelectView>());

        packSpinPresenter = new PackSpinPresenter(new PackSpinModel(soundPresenter, particleEffectPresenter), viewContainer.GetView<PackSpinView>());

        swipeAnimationPresenter = new SwipeAnimationPresenter(new SwipeAnimationModel(), viewContainer.GetView<SwipeAnimationView>());

        cardTypeCollectionPresenter = new CardTypeCollectionPresenter(new CardTypeCollectionModel(), viewContainer.GetView<CardTypeCollectionView>());

        swipePresenter = new SwipePresenter(new SwipeModel(), viewContainer.GetView<SwipeView>());

        menuGlobalStateMachine = new MenuGlobalStateMachine(
            sceneRoot, 
            shopPackPresenter, 
            shopItemSelectPresenter,
            unpackerPackPresenter, 
            unpackerCardsPresenter,
            bookPagesPresenter,
            packSpinPresenter,
            addCardCollectionPresenter,
            cardCollectionPresenter,
            swipeAnimationPresenter,
            swipePresenter);

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();


        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();

        cardTypeCollectionPresenter.Initialize();
        cardCollectionPresenter.Initialize();
        bookPagesPresenter.Initialize();
        unpackerPackPresenter.Initialize();
        unpackerCardsPresenter.Initialize();
        packSpinPresenter.Initialize();
        shopPackPresenter.Initialize();
        shopItemSelectPresenter.Initialize();
        addCardCollectionPresenter.Initialize();
        swipeAnimationPresenter.Initialize();
        swipePresenter.Initialize();

        menuGlobalStateMachine.Initialize();
    }

    private void ActivateEvents()
    {
        ActivateTransitionsSceneEvents();

        cardCollectionPresenter.OnOpenCard += cardTypeCollectionPresenter.AddCardType;
        bookPagesPresenter.OnChoosePage_Second += cardTypeCollectionPresenter.OpenDisplay;
    }

    private void DeactivateEvents()
    {
        DeactivateTransitionsSceneEvents();

        cardCollectionPresenter.OnOpenCard -= cardTypeCollectionPresenter.AddCardType;
        bookPagesPresenter.OnChoosePage_Second -= cardTypeCollectionPresenter.OpenDisplay;
    }

    private void ActivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToGame += HandleGoToGame;
    }

    private void DeactivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToGame -= HandleGoToGame;
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
        cardCollectionPresenter?.Dispose();
        packSpinPresenter?.Dispose();
        unpackerPackPresenter?.Dispose();
        swipeAnimationPresenter?.Dispose();
        swipePresenter?.Dispose();
        cardTypeCollectionPresenter?.Dispose();
        menuGlobalStateMachine?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Input actions

    public event Action OnGoToGame;

    private void HandleGoToGame()
    {
        Deactivate();
        OnGoToGame?.Invoke();
    }

    #endregion
}
