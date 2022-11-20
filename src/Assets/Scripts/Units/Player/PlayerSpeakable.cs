using System;
using UnityEngine;
using ai.nanosemantics;
using KasherOriginal.Services.Input;

public class PlayerSpeakable : MonoBehaviour, ISpeakable
{
    [SerializeField] private string _currentPhrase;
    [SerializeField] private float _speakRadius;
    [SerializeField] private LayerMask _layerMask;
    
    private StandaloneInputService _inputService;
    private DialogSystem _dialogSystem;

    private bool _wasDialogStarted;
    private ASR _asr;

    public DialogSystem DialogSystem => _dialogSystem;

    private void Start()
    {
        _dialogSystem.IsDialogEnded += ResetDialog;
        _asr.OnAsrMessage += SetCurrentPhrase;
    }

    private void Update()
    {
        if (_inputService.IsSpaceButtonDown())
        {
            Speak();
        }
    }

    public void SetUp(StandaloneInputService standaloneInputService, DialogSystem dialogSystem, ASR asr)
    {
        _inputService = standaloneInputService;
        _dialogSystem = dialogSystem;
        _asr = asr;
    }

    public void Speak()
    {
        _asr.StartRecoring();
    }

    private void SetCurrentPhrase(string message)
    {
        _currentPhrase = message;

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
                    Debug.Log("df");
                    
                    if (_dialogSystem.CanStartNewDialog(dialog, _currentPhrase))
                    {
                        Debug.Log("34");
                        
                        _wasDialogStarted = true;
                        _dialogSystem.ProcessDialog(null);
                        return;
                    }
                }
            }
            else
            {
                _dialogSystem.ProcessDialog(_currentPhrase);
            }
        }
    }

    private void ResetDialog()
    {
        _wasDialogStarted = false;
    }

    private void OnDisable()
    {
        _asr.OnAsrMessage -= SetCurrentPhrase;
        _dialogSystem.IsDialogEnded -= ResetDialog;
    }
}