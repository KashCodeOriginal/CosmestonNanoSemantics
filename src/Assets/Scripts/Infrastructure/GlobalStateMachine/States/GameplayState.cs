using KasherOriginal.Factories.UIFactory;

namespace KasherOriginal.GlobalStateMachine
{
    public class GameplayState : State<GameInstance>
    {
        public GameplayState(GameInstance context, IUIFactory uiFactory) : base(context)
        {
            _uiFactory = uiFactory;
        }

        private readonly IUIFactory _uiFactory;

        public override void Enter()
        {
            _uiFactory.DestroyGameLoadingScreen();

            ShowUI();
        }

        public override void Exit()
        {
            HideUI();
        }

        private void ShowUI()
        {
            _uiFactory.CreateGameplayScreen();
        }

        private void HideUI()
        {
            _uiFactory.DestroyGameplayScreen();
        }
    }
}