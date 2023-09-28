using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerParameters", menuName = "CustomParameters/SpawnerParameters/StandartSpawnerParameters")]
public class SpawnerParameters : ScriptableObject
{
    private int _minValue = 0;
    
    [SerializeField] private List<SpawnerObjectParameters> _spawnPrefabs;
    [SerializeField][Min(_minValue)] private int _maxCountObjects;
    [SerializeField][Min(_minValue)] private int _minCountObjects;
    [SerializeField][Min(_minValue)] private float _reduceReloadingTime;
    [SerializeField][Min(_minValue)] private float _maxReloadingTime;
    [SerializeField][Min(_minValue)] private float _minReloadingTime;

    public int MinValue => _minValue;
    public List<SpawnerObjectParameters> SpawnPrefabs => _spawnPrefabs;
    public int MaxCountObjects => _maxCountObjects;
    public int MinCountObjects => _minCountObjects;
    public float ReduceReloadingTime => _reduceReloadingTime;
    public float MaxReloadingTime => _maxReloadingTime;
    public float MinReloadingTime => _minReloadingTime;
}
