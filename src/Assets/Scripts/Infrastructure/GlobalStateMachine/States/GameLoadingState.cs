using UnityEngine.AddressableAssets;
using KasherOriginal.Factories.UIFactory;

namespace KasherOriginal.GlobalStateMachine
{
    public class GameLoadingState : State<GameInstance>
    {
        public GameLoadingState(GameInstance context, IUIFactory uiFactory) : base(context)
        {
            _uiFactory = uiFactory;
        }

        private readonly IUIFactory _uiFactory;

        public override async void Enter()
        {
            ShowUI();

            var asyncOperationHandle = Addressables.LoadSceneAsync(AssetsAddressablesConstants.GAMEPLAY_LEVEL_NAME);
            await asyncOperationHandle.Task;
        
            OnLoadComplete();
        }

        private void ShowUI()
        {
            _uiFactory.CreateGameLoadingScreen();
        }

        private void OnLoadComplete()
        {
            Context.StateMachine.SwitchState<GameSetUpState>();
        }
    }
}