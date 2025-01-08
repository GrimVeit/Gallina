using System;
using UnityEngine;

public class MiniGameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private UIMiniGameSceneRoot sceneRootPrefab;

    private UIMiniGameSceneRoot sceneRoot;
    private ViewContainer viewContainer;

    private SoundPresenter soundPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private BankPresenter bankPresenter;

    private BasketPresenter basketPresenter;
    private EggCatcherPresenter eggCatcherPresenter;
    private ScorePresenter scorePresenter;

    private MiniGameGlobalStateMachine globalStateMachine;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = Instantiate(sceneRootPrefab);
        sceneRoot.Activate();
        sceneRoot.Initialize();
        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter(new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS), viewContainer.GetView<SoundView>());
        soundPresenter.Initialize();

        particleEffectPresenter = new ParticleEffectPresenter(new ParticleEffectModel(), viewContainer.GetView<ParticleEffectView>());
        particleEffectPresenter.Initialize();

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());
        bankPresenter.Initialize();

        basketPresenter = new BasketPresenter(new BasketModel(2, 1, soundPresenter), viewContainer.GetView<BasketView_LeftRightControl>());
        basketPresenter.Initialize();

        eggCatcherPresenter = new EggCatcherPresenter(new EggCatcherModel(2f, 0.5f, 0.01f, soundPresenter, particleEffectPresenter), viewContainer.GetView<EggCatcherView>());
        eggCatcherPresenter.Initialize();

        scorePresenter = new ScorePresenter(new ScoreModel(bankPresenter, soundPresenter), viewContainer.GetView<ScoreView>());
        scorePresenter.Initialize();

        globalStateMachine = new MiniGameGlobalStateMachine(sceneRoot, basketPresenter, eggCatcherPresenter, scorePresenter);
        globalStateMachine.Initialize();

        ActivateEvents();

        eggCatcherPresenter.StartSpawner();
        eggCatcherPresenter.SetTimerSpawnerData(2, 0.5f, 0.01f, 1);
    }

    private void ActivateEvents()
    {
        eggCatcherPresenter.OnEggDown += scorePresenter.RemoveHealth;
        eggCatcherPresenter.OnEggWin_EggValue += scorePresenter.AddScore;
    }

    private void DeactivateEvents()
    {
        eggCatcherPresenter.OnEggDown -= scorePresenter.RemoveHealth;
        eggCatcherPresenter.OnEggWin_EggValue -= scorePresenter.AddScore;
    }

    public void Dispose()
    {
        DeactivateEvents();
        sceneRoot.Deactivate();

        sceneRoot?.Dispose();
        soundPresenter?.Dispose();
        bankPresenter?.Dispose();
        basketPresenter?.Dispose();
        particleEffectPresenter?.Dispose();
        eggCatcherPresenter?.Dispose();
        scorePresenter?.Dispose();
    }

    #region Input

    public event Action OnGoToMainMenu
    {
        add { sceneRoot.OnGoToMainMenu += value; }
        remove { sceneRoot.OnGoToMainMenu -= value; }
    }

    #endregion
}
