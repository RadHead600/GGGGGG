using DG.Tweening;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;
    public abstract void Active();

    public Tweener Tween { get; set; }

    private void OnDestroy()
    {
        Tween.Kill();
    }
}
