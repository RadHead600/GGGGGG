using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerEnemiesParameters", menuName = "CustomParameters/SpawnerParameters/SpawnerEnemiesParameters")]
public class SpawnerEnemiesParameters : SpawnerParameters
{
     private int _minValue = 0;
     
    [SerializeField][Min(_minValue)] private int _minWaves;
    [SerializeField][Min(_minValue)] private int _numLevelForAddWaves;
    [SerializeField][Min(_minValue)] private int _increaseEnemies;
    [SerializeField] private int _timeToKillInSeconds;
    [SerializeField] private float _additionalTime;

    public int MinValue => _minValue;
    public int MinWaves => _minWaves;
    public int NumLevelForAddWaves => _numLevelForAddWaves;
    public int IncreaseEnemies => _increaseEnemies;
    public int TimeToKillInSeconds => _timeToKillInSeconds;
    public float AdditionalTime => _additionalTime;
}
