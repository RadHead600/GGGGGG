using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Skin : MonoBehaviour
{
    [SerializeField] private RagdollController _ragdollController;
    [SerializeField] private List<SkinnedMeshRenderer> _clothes;

    public Animator Animator { get; private set; }
    public RagdollController RagdollController => _ragdollController;
    public List<SkinnedMeshRenderer> Clothes => _clothes;

    private void Awake()
    {
        if (Animator == null)
            Animator = GetComponent<Animator>();
    }
}
