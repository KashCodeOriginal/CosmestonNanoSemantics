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
            var mainCameraPrefab =
                await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.MAIN_CAMERA);
            var basePlayerPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.BASE_PLAYER);

            var mapInstance = _environmentFactory.CreateInstance(baseMapPrefab, Vector3.zero);
            var cameraInstance = _environmentFactory.CreateInstance(mainCameraPrefab, Vector3.zero);
            var playerInstance = _environmentFactory.CreateInstance(basePlayerPrefab, new Vector3(0, 1.5f,0));

            SetUp(cameraInstance, playerInstance);

            Context.StateMachine.SwitchState<GameplayState>();
        }

        private void SetUp(GameObject cameraInstance, GameObject playerInstance)
        {
            if (cameraInstance.TryGetComponent(out CameraFollowing cameraFollowing))
            {
                cameraFollowing.SetTarget(playerInstance.transform);
            }

            if (playerInstance.TryGetComponent(out PlayerMovement playerMovement))
            {
                playerMovement.SetUp(_standaloneInputService, cameraInstance.GetComponent<Camera>());
            }
        }
    }
}