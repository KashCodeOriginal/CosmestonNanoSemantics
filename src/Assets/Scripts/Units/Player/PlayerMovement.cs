using UnityEngine;
using KasherOriginal.Services.Input;

public class PlayerMovement : MonoBehaviour
{
    public void SetUp(StandaloneInputService inputService)
    {
        _inputService = inputService;
    }

    [SerializeField] private float _speed;
    
    private StandaloneInputService _inputService;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var movementVector = GetMovementVector();
        Move(movementVector);
    }
    
    private Vector3 GetMovementVector()
    {
        if (!(_inputService.Axis.sqrMagnitude > Mathf.Epsilon))
        {
            return Vector3.zero;
        }
        
        var vector = new Vector3(_inputService.Axis.x, 0, _inputService.Axis.y);
        
        vector.Normalize();

        return vector;
    }
    

    private void Move(Vector3 movementVector)
    {
        _rigidbody.AddRelativeForce(movementVector.x * _speed, _rigidbody.velocity.y, movementVector.z * _speed);
    }
}
