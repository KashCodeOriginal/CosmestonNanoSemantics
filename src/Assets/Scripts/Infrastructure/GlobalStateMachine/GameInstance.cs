using KasherOriginal.Services.Input;
using KasherOriginal.AssetsAddressable;
using KasherOriginal.GlobalStateMachine;
using KasherOriginal.Factories.UIFactory;
using KasherOriginal.Factories.EnvironmentFactory;

public class GameInstance
{
    public GameInstance(IUIFactory uiFactory, IEnvironmentFactory environmentFactory, IAssetsAddressableService assetsAddressableService, StandaloneInputService standaloneInputService)
    {
        StateMachine = new StateMachine<GameInstance>(this, 
            new BootstrapState(this),
            new MenuLoadingState(this, uiFactory),
            new MainMenuState(this, uiFactory),
            new GameLoadingState(this, uiFactory),
            new GameSetUpState(this, environmentFactory, assetsAddressableService, standaloneInputService),
            new GameplayState(this, uiFactory));
        StateMachine.SwitchState<BootstrapState>();
    }

    public readonly StateMachine<GameInstance> StateMachine;
}
