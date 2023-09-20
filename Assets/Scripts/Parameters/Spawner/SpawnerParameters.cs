using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerParameters", menuName = "CustomParameters/SpawnerParameters/StandartSpawnerParameters")]
public class SpawnerParameters : ScriptableObject
{
    [Header("Generation objects.")]
    [SerializeField] private List<SpawnerObjectParameters> _spawnPrefabs;
    [Header("The maximum _value of the objects on the wave.")]
    [SerializeField][Min(0)] private int _maxCountObjects;
    [Header("The minimum _value of the objects on the wave.")]
    [SerializeField][Min(0)] private int _minCountObjects;
    [Header("Reduction of time between waves as a percentage for each level.")]
    [SerializeField][Min(0)] private float _reduceReloadingTime;
    [Header("The starting _value of the time between waves of objects.")]
    [SerializeField][Min(0)] private float _maxReloadingTime;
    [Header("Minimum _value of the time between waves of objects.")]
    [SerializeField][Min(0)] private float _minReloadingTime;

    public List<SpawnerObjectParameters> SpawnPrefabs => _spawnPrefabs;
    public int MaxCountObjects => _maxCountObjects;
    public int MinCountObjects => _minCountObjects;
    public float ReduceReloadingTime => _reduceReloadingTime;
    public float MaxReloadingTime => _maxReloadingTime;
    public float MinReloadingTime => _minReloadingTime;
}
