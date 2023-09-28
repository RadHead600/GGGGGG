using UnityEngine;

public class DestroyObjectsInCollision : MonoBehaviour
{
    [SerializeField] private LayerMask _layers;

    private void OnTriggerEnter(Collider other)
    {
        private int _layerMaskZero = 0;
        private int _layerMaskOne = 1;
        
        if ((other.gameObject.layer & (_layerMaskOne << _layers)) != _layerMaskZero)
        {
            Destroy(other.gameObject);
        }
    }
}
