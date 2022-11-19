using UnityEngine;
using KasherOriginal.Services.Input;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _sensitivity;

    private Vector2 _currentRotation;
    
    private StandaloneInputService _inputService;

    public void SetUp(StandaloneInputService standaloneInputService)
    {
        _inputService = standaloneInputService;
    }

    private void Update()
    {
        Vector2 targetRotation = _inputService.MouseAxis * _sensitivity;

        _currentRotation += targetRotation;

        transform.localEulerAngles = new Vector3(0, _currentRotation.x, 0);
    }
}
