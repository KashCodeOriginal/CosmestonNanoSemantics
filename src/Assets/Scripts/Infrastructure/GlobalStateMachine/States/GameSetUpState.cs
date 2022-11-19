using UnityEngine;
using KasherOriginal.Services.Input;
using KasherOriginal.AssetsAddressable;
using KasherOriginal.Factories.EnvironmentFactory;

namespace KasherOriginal.GlobalStateMachine
{
    public class GameSetUpState : State<GameInstance>
    {
        public GameSetUpState(GameInstance context, IEnvironmentFactory environmentFactory, IAssetsAddressableService assetsAddressableService, StandaloneInputService standaloneInputService) : base(context)
        {
            _environmentFactory = environmentFactory;
            _assetsAddressableService = assetsAddressableService;
            _standaloneInputService = standaloneInputService;
        }

        private readonly IEnvironmentFactory _environmentFactory;
        private readonly IAssetsAddressableService _assetsAddressableService;
        private readonly StandaloneInputService _standaloneInputService;

        public override async void Enter()
        {
            var baseMapPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.BASE_MAP);
            var basePlayerPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.BASE_PLAYER);

            var mapInstance = _environmentFactory.CreateInstance(baseMapPrefab, Vector3.zero);
            var playerInstance = _environmentFactory.CreateInstance(basePlayerPrefab, new Vector3(0, 1.5f,0));

            SetUp(playerInstance);

            Context.StateMachine.SwitchState<GameplayState>();
        }

        private void SetUp(GameObject playerInstance)
        {
            if (playerInstance.TryGetComponent(out PlayerMovement playerMovement))
            {
                playerMovement.SetUp(_standaloneInputService);
            }
            
            if (playerInstance.TryGetComponent(out PlayerRotation mouseCameraRotation))
            {
                mouseCameraRotation.SetUp(_standaloneInputService);
            }
            
            if (playerInstance.TryGetComponent(out PlayerSpeakable playerSpeakable))
            {
                playerSpeakable.SetUp(_standaloneInputService);
            }
        }
    }
}