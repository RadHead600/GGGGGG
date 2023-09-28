using System;
using UnityEngine;

[Serializable]
public class SpawnerObjectParameters
{
    private float _minChanceValue = 0f;
    private float _maxChanceValue = 100f;
    
    [SerializeField] private Unit _spawnPrefab;
    [SerializeField][Range(_minChanceValue, _maxChanceValue)] private float _chance;
    
    public float MinChanceValueForFields => _minChanceValue;
    public float MaxChanceValueForFields => _maxChanceValue;
    public Unit SpawnPrefab => _spawnPrefab;
    public float Chance => _chance;
}
