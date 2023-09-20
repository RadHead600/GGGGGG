using System;
using UnityEngine;

[Serializable]
public class SerializeSpawnerParameters
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private SpawnerParameters _spawnerParameters;

    public Spawner Spawner => _spawner;
    public SpawnerParameters SpawnerParameters => _spawnerParameters;
}
