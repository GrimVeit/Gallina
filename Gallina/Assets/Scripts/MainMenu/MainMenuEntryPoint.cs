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

    private ShopItemSelectPresenter shopItemSelectPresenter;
    private ShopPackPresenter shopPackPresenter;

    private UnpackerPackPresenter unpackerPackPresenter;
    private UnpackerCardsPresenter unpackerCardsPresenter;
    private AddCardCollectionPresenter addCardCollectionPresenter;

    private CardCollectionPresenter cardCollectionPresenter;

    private BookPagesPresenter bookPagesPresenter;

    private SwipeAnimationPresenter swipeAnimationPresenter;
    private SwipePresenter swipePresenter;

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

        shopItemSelectPresenter = new ShopItemSelectPresenter(new ShopItemSelectModel(), viewContainer.GetView<ShopItemSelectView>());

        cardCollectionPresenter = new CardCollectionPresenter(new CardCollectionModel(cards), viewContainer.GetView<CardCollectionView>());

        unpackerPackPresenter = new UnpackerPackPresenter(new UnpackerPackModel(), viewContainer.GetView<UnpackerPackView>());

        unpackerCardsPresenter = new UnpackerCardsPresenter(new UnpackerCardsModel(cards, cardCollectionPresenter), viewContainer.GetView<UnpackerCardsView>());

        addCardCollectionPresenter = new AddCardCollectionPresenter(new AddCardCollectionModel(), viewContainer.GetView<AddCardCollectionView>());

        shopPackPresenter = new ShopPackPresenter(new ShopPackModel(bankPresenter), viewContainer.GetView<ShopPackView>());

        swipeAnimationPresenter = new SwipeAnimationPresenter(new SwipeAnimationModel(), viewContainer.GetView<SwipeAnimationView>());

        swipePresenter = new SwipePresenter(new SwipeModel(), viewContainer.GetView<SwipeView>());

        menuGlobalStateMachine = new MenuGlobalStateMachine(
            sceneRoot, 
            shopItemSelectPresenter, 
            shopPackPresenter, 
            unpackerPackPresenter, 
            unpackerCardsPresenter,
            bookPagesPresenter,
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

        cardCollectionPresenter.Initialize();
        bookPagesPresenter.Initialize();
        shopItemSelectPresenter.Initialize();
        unpackerPackPresenter.Initialize();
        unpackerCardsPresenter.Initialize();
        shopPackPresenter.Initialize();
        addCardCollectionPresenter.Initialize();
        swipeAnimationPresenter.Initialize();
        swipePresenter.Initialize();

        menuGlobalStateMachine.Initialize();
    }

    private void ActivateEvents()
    {
        ActivateTransitionsSceneEvents();

        //shopItemSelectPresenter.OnSelectPack_Data += shopPackPresenter.SetData;
        //shopItemSelectPresenter.OnSelect += shopPackPresenter.ShowBuy;
        //shopItemSelectPresenter.OnUnselect += shopPackPresenter.HideBuy;

        //shopPackPresenter.OnBuyItemPack += sceneRoot.OpenPackPanel;
        //shopPackPresenter.OnBuyItemPack_Value += unpackerPackPresenter.SpawnPack;
        //shopPackPresenter.OnBuyItemPack_Value += unpackerCardsPresenter.SpawnCards;

        //unpackerPackPresenter.OnClosePack += unpackerCardsPresenter.ActivateCards;
    }

    private void DeactivateEvents()
    {
        DeactivateTransitionsSceneEvents();

        //shopItemSelectPresenter.OnSelectPack_Data -= shopPackPresenter.SetData;
        //shopItemSelectPresenter.OnSelect -= shopPackPresenter.ShowBuy;
        //shopItemSelectPresenter.OnUnselect -= shopPackPresenter.HideBuy;

        //shopPackPresenter.OnBuyItemPack -= sceneRoot.OpenPackPanel;
        //shopPackPresenter.OnBuyItemPack_Value -= unpackerPackPresenter.SpawnPack;
        //shopPackPresenter.OnBuyItemPack_Value -= unpackerCardsPresenter.SpawnCards;

        //unpackerPackPresenter.OnClosePack -= unpackerCardsPresenter.ActivateCards;
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
        cardCollectionPresenter?.Dispose();
        unpackerPackPresenter?.Dispose();
        swipeAnimationPresenter?.Dispose();
        swipePresenter?.Dispose();
        menuGlobalStateMachine?.Dispose();
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
