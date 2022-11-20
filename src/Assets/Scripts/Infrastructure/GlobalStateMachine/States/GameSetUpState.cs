using UnityEngine;
using ai.nanosemantics;
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
            var dialogSystemPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.DIALOG_SYSTEM);
            var TTSPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.TTS);
            var ASRPrefab = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressablesConstants.ASR);

            var mapInstance = _environmentFactory.CreateInstance(baseMapPrefab, Vector3.zero);
            var playerInstance = _environmentFactory.CreateInstance(basePlayerPrefab, new Vector3(0, 1.5f,0));
            var dialogSystemInstance = _environmentFactory.CreateInstance(dialogSystemPrefab, new Vector3(0, 1.5f,0));
            var TTSInstance = _environmentFactory.CreateInstance(TTSPrefab,  Vector3.zero);
            var ASRInstance = _environmentFactory.CreateInstance(ASRPrefab,  Vector3.zero);

            SetUp(playerInstance, dialogSystemInstance, ASRInstance, TTSInstance);

            Context.StateMachine.SwitchState<GameplayState>();
        }

        private void SetUp(GameObject playerInstance, GameObject dialogSystemInstance, GameObject asrInstance, GameObject ttsInstance)
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
                playerSpeakable.SetUp(_standaloneInputService, dialogSystemInstance.GetComponent<DialogSystem>(), asrInstance.GetComponent<ASR>());
            }

            if (dialogSystemInstance.TryGetComponent(out DialogSystem dialogSystem))
            {
                dialogSystem.SetUp(ttsInstance.GetComponent<TTS>());
            }
        }
    }
}