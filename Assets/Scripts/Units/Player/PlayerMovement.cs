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
    private Vector3 _fwd, _right;

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
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            Move();
        else if (_moveJoystick != null)
            JoystickMove();
        if (!_characterController.isGrounded)
            _characterController.Move(new Vector3(0, -0.1f, 0));
    }

    public void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * Speed;
        _moveVector.y = _characterController.isGrounded ? 0 : -1;
        _moveVector.z = Input.GetAxis("Vertical") * Speed;
        _characterController.Move(_moveVector * Time.deltaTime);
        _moveVector.Normalize();
        Skin.Animator.SetFloat("Speed", _moveVector.magnitude);
        Skin.Animator.speed = (_moveVector.magnitude > 0 ? Speed / 10 : 1);
        
        if (!LookAtController.Tween.IsActive())
            Direction(_moveVector);
    }

    void RecalculateCamera(Camera _cam)
    {
        Camera cam = _cam;
        _fwd = cam.transform.forward;
        _fwd.y = 0;
        _fwd = Vector3.Normalize(_fwd);
        _right = Quaternion.Euler(new Vector3(0, 90, 0)) * _fwd;
    }

    void JoystickMove()
    {
        Vector3 rightMovement = _right * Speed * Time.deltaTime * _moveJoystick.Direction.x;
        Vector3 upMovement = _fwd * Speed * Time.deltaTime * _moveJoystick.Direction.y;
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        _characterController.Move(heading * Speed * Time.deltaTime);
        Skin.Animator.SetFloat("Speed", heading.magnitude);
        Skin.Animator.speed = (heading.magnitude > 0 ? Speed / 10 : 1);
        
        if (!LookAtController.Tween.IsActive())
            Direction(heading);
    }

    private void Direction(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
            transform.DOLookAt(movementDirection + transform.position, _directionTime);
    }
}
