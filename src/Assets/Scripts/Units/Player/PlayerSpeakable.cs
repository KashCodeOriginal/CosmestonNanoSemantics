using UnityEngine;
using KasherOriginal.Services.Input;

public class PlayerSpeakable : MonoBehaviour, ISpeakable
{
    [SerializeField] private string _phrase;
    [SerializeField] private LayerMask _layerMask;
    
    private StandaloneInputService _inputService;
        
    private void Update()
    {
        if (_inputService.IsSpaceButtonDown())
        {
            Speak();
        }
    }

    public void SetUp(StandaloneInputService standaloneInputService)
    {
        _inputService = standaloneInputService;
    }

    public void Speak()
    {
        TriggerListenersAround();
    }

    private void TriggerListenersAround()
    {
        var colliders = Physics.OverlapSphere(transform.position, 5f, _layerMask);
        
        if (colliders.Length > 0)
        {
            FindListenersObjects(colliders);
        }
    }

    private void FindListenersObjects(Collider[] colliders)
    {
        foreach (var collider in colliders)
        {
            Debug.Log(collider.name);
            
            if (collider.TryGetComponent(out Citizen citizen))
            {
                Debug.Log(citizen);
                
               citizen.CitizenListen(_phrase);
            }
        }
    }
}