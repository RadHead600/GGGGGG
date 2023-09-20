using UnityEngine;

[CreateAssetMenu(fileName = "UnitParameters", menuName = "CustomParameters/UnitParameters")]
public class UnitParameters : ScriptableObject
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private int _minHealth;

    public float MinSpeed => _minSpeed;
    public int MinHealth => _minHealth;
}
