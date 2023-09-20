using System;
using UnityEngine;

[Serializable]
public class SpawnerObjectParameters
{
    [SerializeField] private Unit _spawnPrefab;
    [SerializeField][Range(0, 100)] private float _chance;

    public Unit SpawnPrefab => _spawnPrefab;
    public float Chance => _chance;
}
