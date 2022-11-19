using UnityEngine;
using KasherOriginal.Services.Input;

public class PlayerMovement : MonoBehaviour
{
    public void SetUp(StandaloneInputService inputService, Camera cam)
    {
        _inputService = inputService;
        _mainCamera = cam;
    }

    [SerializeField] private float _speed;
    
    private StandaloneInputService _inputService;
    private Camera _mainCamera;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        Vector3 movementVector = Vector3.zero;

        if (_inputService.Axis.sqrMagnitude > Mathf.Epsilon)
        {
            movementVector = new Vector3(_inputService.Axis.x, 0, _inputService.Axis.y);
            movementVector.Normalize();
        }

        Move(movementVector);

        LookToMovingDirection(movementVector);
    }
    

    private void Move(Vector3 movementVector)
    {
        _rigidbody.velocity = new Vector3(movementVector.x * _speed, _rigidbody.velocity.y, movementVector.z * _speed);
    }

    private void LookToMovingDirection(Vector3 movementVector)
    {
        if (movementVector.x != 0 || movementVector.z != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }
}
