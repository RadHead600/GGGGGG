using UnityEngine;

public class UpgradesParameters : ScriptableObject
{
    [SerializeField] private float _value;
    [SerializeField] private int _minCost;

    public float Value => _value;
    public int MinCost => _minCost;
}
