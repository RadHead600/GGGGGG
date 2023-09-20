using UnityEngine;

public class DestroyObjectsInCollision : MonoBehaviour
{
    [SerializeField] private LayerMask _layers;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer & (1 << _layers)) != 0)
        {
            Destroy(other.gameObject);
        }
    }
}
