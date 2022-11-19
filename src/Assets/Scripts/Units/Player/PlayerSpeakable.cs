using UnityEngine;
using KasherOriginal.Services.Input;

public class PlayerSpeakable : MonoBehaviour, ISpeakable
{
    [SerializeField] private string _phrase;
    
    private StandaloneInputService _inputService;
        
    private void Update()
    {
        if (_inputService.IsSpaceButtonDown())
        {
            
        }
    }

    public void SetUp(StandaloneInputService standaloneInputService)
    {
        _inputService = standaloneInputService;
    }

    private void TriggerListenersAround()
    {
        var colliders = Physics.OverlapSphere(transform.position, 5f);

        if (colliders.Length > 0)
        {
            FindListenersObjects(colliders);
        }
    }

    private void FindListenersObjects(Collider[] colliders)
    {
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IListenable listenable))
            {
                listenable.SetPhrase(_phrase);
            }
        }
    }
}