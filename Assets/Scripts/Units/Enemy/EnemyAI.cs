using UnityEngine;
using UnityEngine.AI;
using static Cinemachine.CinemachineOrbitalTransposer;

public class EnemyAI : Enemy
{
    [SerializeField] private AIMoveTo _aIMoveTo;

    public NavMeshAgent NavMeshAgent => _aIMoveTo.NavMeshAgent;
    private bool isJumping;
    private bool isAttacking;

    protected override void Awake()
    {
        base.Awake();
        OnDeath += _aIMoveTo.StopScript;
    }

    private void Start()
    {
        Skin.Animator.SetFloat("Speed", NavMeshAgent.speed);
    }

    private void FixedUpdate()
    {
        if (_aIMoveTo.IsJump() != isJumping)
        {
            Skin.Animator.speed = 1;
            Skin.Animator.SetBool("Jump", _aIMoveTo.IsJump());
            isJumping = _aIMoveTo.IsJump();
            return;
        }
        if (Attack.IsAttack)
        {
            Skin.Animator.speed = 1;
            _aIMoveTo.StopMove();
            Skin.Animator.SetFloat("Speed", 0);
            isAttacking = true;
            return;
        }
        if (isAttacking)
        {
            _aIMoveTo.Move();
            isAttacking = false;
            return;
        }
        if (Skin.Animator.speed != NavMeshAgent.speed)
        {
            Skin.Animator.speed = NavMeshAgent.speed;
            Skin.Animator.SetFloat("Speed", NavMeshAgent.speed);
        }
    }


    protected override void OnDestroy()
    {
        OnDeath -= _aIMoveTo.StopScript;
        base.OnDestroy();
    }
}
