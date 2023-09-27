using DG.Tweening;
using System;
using UnityEngine;

public class PlayerMovement : PlayerController, IMove
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Joystick _moveJoystick;
    [SerializeField] private float _directionTime;
    [SerializeField] private Vector3 _rotateOffset;

    private Vector3 _moveVector;
    private Vector3 _forward, _right;

    public static PlayerMovement Instance { get; private set; }
    public Vector3 MoveVector => _moveVector;

    protected override void Awake()
    {
        base.Awake();
        
        if (Instance != null)
        {
            Debug.LogError($"Exists more than 1 instance of {typeof(PlayerMovement).Name} class!");

            throw new Exception();
        }

        Instance = this;
    }

    private void Start()
    {
        RecalculateCamera(Camera.main);
    }

    private void Update()
    {
        private float inputThreshold = 0.01f;

        private float gravityAdjustment = -0.1f;

        private float zeroValue = 0.0f;
        
        if (Input.GetAxis("Horizontal") != inputThreshold || Input.GetAxis("Vertical") != inputThreshold)
            Move();
        else if (_moveJoystick != null)
            JoystickMove();
        if (!_characterController.isGrounded)
            _characterController.Move(new Vector3(zeroValue, gravityAdjustment, zeroValue));
    }

    public void Move()
    {
        private float zeroValue = 0.0f;
        
        private float gravityValue = -1.0f;

        private float speedMultiplierWithMovement = 10.0f;
        
        private float defaultSpeedMultiplier = 1.0f;
        
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * Speed;
        _moveVector.y = _characterController.isGrounded ? zeroValue : gravityValue;
        _moveVector.z = Input.GetAxis("Vertical") * Speed;
        _characterController.Move(_moveVector * Time.deltaTime);
        _moveVector.Normalize();
        Skin.Animator.SetFloat("Speed", _moveVector.magnitude);
        Skin.Animator.speed = (_moveVector.magnitude > zeroValue ? 
        Speed / speedMultiplierWithMovement : defaultSpeedMultiplier);
        
        if (!LookAtController.Tween.IsActive())
            Direction(_moveVector);
    }

    void RecalculateCamera(Camera _camera)
    {
        private float zeroAngle = 0.0f;
        
        private float ninetyDegrees = 90.0f;
        
        Camera camera = _camera;
        _forward = camera.transform.forward;
        _forward.y = zeroAngle;
        _forward = Vector3.Normalize(_forward);
        _right = Quaternion.Euler(new Vector3(zeroAngle, ninetyDegrees, zeroAngle)) * _forward;
    }

    void JoystickMove()
    {
        private float speedMultiplierWithMovement = 10.0f;
        
        private float defaultSpeedMultiplier = 1.0f;

        private float defaultvalue = 0.0f;
        
        Vector3 rightMovement = _right * Speed * Time.deltaTime * _moveJoystick.Direction.x;
        Vector3 upMovement = _forward * Speed * Time.deltaTime * _moveJoystick.Direction.y;
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        _characterController.Move(heading * Speed * Time.deltaTime);
        Skin.Animator.SetFloat("Speed", heading.magnitude);
        Skin.Animator.speed = (heading.magnitude > defaultvalue ? Speed / speedMultiplierWithMovement : defaultSpeedMultiplier);
        
        if (!LookAtController.Tween.IsActive())
            Direction(heading);
    }

    private void Direction(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
            transform.DOLookAt(movementDirection + transform.position, _directionTime);
    }
}
