using UnityEngine;
using KasherOriginal.Services.Input;

public class PlayerSpeakable : MonoBehaviour, ISpeakable
{
    [SerializeField] private string _currentPhrase;
    [SerializeField] private float _speakRadius;
    [SerializeField] private LayerMask _layerMask;
    
    private StandaloneInputService _inputService;
    private DialogSystem _dialogSystem;

    private bool _wasDialogStarted;
    private Citizen _currentDialogCompanion;

    public DialogSystem DialogSystem => _dialogSystem;

    private void Update()
    {
        if (_inputService.IsSpaceButtonDown())
        {
            Speak();
        }
    }

    public void SetUp(StandaloneInputService standaloneInputService, DialogSystem dialogSystem)
    {
        _inputService = standaloneInputService;
        _dialogSystem = dialogSystem;
    }

    public void Speak()
    {
        TriggerListenersAround();
    }

    private void TriggerListenersAround()
    {
        var colliders = Physics.OverlapSphere(transform.position, _speakRadius, _layerMask);
        
        if (colliders.Length > 0)
        {
            FindListenersObjects(colliders);
        }
    }

    private void FindListenersObjects(Collider[] colliders)
    {
        foreach (var collider in colliders)
        {
            if (!collider.TryGetComponent(out Dialog dialog)) 
                continue;
            
            if (!_wasDialogStarted)
            {
                if (collider.TryGetComponent(out Citizen citizen))
                {
                    if (_dialogSystem.CanStartNewDialog(dialog, _currentPhrase))
                    {
                        _currentDialogCompanion = citizen;
                        _wasDialogStarted = true;
                        
                        _dialogSystem.ProcessDialog(null);
                    }
                }
            }
            else
            {
                _dialogSystem.ProcessDialog(_currentPhrase);
            }
        }
    }
}