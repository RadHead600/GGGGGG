using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerEnemiesParameters", menuName = "CustomParameters/SpawnerParameters/SpawnerEnemiesParameters")]
public class SpawnerEnemiesParameters : SpawnerParameters
{
    [Header("The starting _value of the waves at the level of.")]
    [SerializeField][Min(0)] private int _minWaves;
    [Header("The number of completed levels to add a wave.")]
    [SerializeField][Min(0)] private int _numLevelForAddWaves;
    [Header("How many percent increases the number of enemies in the wave at the next level.")]
    [SerializeField][Min(0)] private int _increaseEnemies;
    [Header("Time to sweep the wave In seconds.")]
    [SerializeField] private int _timeToKillInSeconds;
    [Header("Coefficient of additional time for cleaning.")]
    [SerializeField] private float _additionalTime;

    public int MinWaves => _minWaves;
    public int NumLevelForAddWaves => _numLevelForAddWaves;
    public int IncreaseEnemies => _increaseEnemies;
    public int TimeToKillInSeconds => _timeToKillInSeconds;
    public float AdditionalTime => _additionalTime;
}
