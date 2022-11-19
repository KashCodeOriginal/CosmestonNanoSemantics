using UnityEngine;
using KasherOriginal.Factories.UIFactory;

namespace KasherOriginal.GlobalStateMachine
{
    public class MainMenuState : State<GameInstance>
    {
        public MainMenuState(GameInstance context, IUIFactory uiFactory) : base(context)
        {
            _uiFactory = uiFactory;
        }

        private readonly IUIFactory _uiFactory;

        private GameObject _mainMenuScreenInstance;
        private MainMenuScreen _mainMenuScreen;

        public override void Enter()
        {
            ShowUI();
        }

        public override void Exit()
        {
            HideUI();
        }

        private async void ShowUI()
        {
            _mainMenuScreenInstance = await _uiFactory.CreateMainMenuScreen();
            
            _mainMenuScreen = _mainMenuScreenInstance.GetComponent<MainMenuScreen>();

            _mainMenuScreen.OnPlayButtonClicked += SwitchStateToGameplay;
        }

        private void HideUI()
        {
            _mainMenuScreen.OnPlayButtonClicked -= SwitchStateToGameplay;
            
            _uiFactory.DestroyMainMenuScreen();
        }

        private void SwitchStateToGameplay()
        {
            Context.StateMachine.SwitchState<GameLoadingState>();
        }
    }
}