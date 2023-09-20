using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask _blocks;
    [SerializeField] private LayerMask _enemies;

    public float Speed { get; set; }
    public int Damage { get; set; }
    public LayerMask enemyMask { get; set; }

    private void Start()
    {
        Destroy(gameObject, 7);
    }

    private void Update()
    {
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        bool isEnemy = Physics.OverlapSphere(transform.position, 0.2f, _enemies).Length > 0.8F;
        if (other.GetComponent<Unit>() != null && isEnemy)
        {
            other.GetComponent<Unit>().TakeDamage(Damage);
            Destroy(gameObject);
        }

        bool isBlock = Physics.OverlapSphere(transform.position, 0.2f, _blocks).Length > 0.8F;
        if (isBlock)
            Destroy(gameObject);
    }
}