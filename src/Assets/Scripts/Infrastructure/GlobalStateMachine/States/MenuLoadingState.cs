using UnityEngine.AddressableAssets;
using KasherOriginal.Factories.UIFactory;

namespace KasherOriginal.GlobalStateMachine
{
    public class MenuLoadingState : State<GameInstance>
    {
        public MenuLoadingState(GameInstance context, IUIFactory uiFactory) : base(context)
        {
            _uiFactory = uiFactory;
        }

        private readonly IUIFactory _uiFactory;

        public override async void Enter()
        {
            ShowUI();
            
            var asyncOperationHandle = Addressables.LoadSceneAsync(AssetsAddressablesConstants.MAIN_MENU_LEVEL_NAME);
            await asyncOperationHandle.Task;
        
            OnLoadComplete();
        }

        public override void Exit()
        {
            HideUI();
        }

        private void ShowUI()
        {
            _uiFactory.CreateMenuLoadingScreen();
        }

        private void HideUI()
        {
            _uiFactory.DestroyMenuLoadingScreen();
        }

        private void OnLoadComplete()
        {
            Context.StateMachine.SwitchState<MainMenuState>();
        }
    }
}