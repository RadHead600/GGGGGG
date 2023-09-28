using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "UpgradePointsParameters", menuName = "CustomParameters/UpgradesParameters/UpgradePointsParameters")]
public class UpgradePointsParameters : ScriptableObject
{
    private float _minTimeToPointsValue = 0f;
    private float _maxTimeToPointsValue = 1f;
    private int _minNumOfPointsValue = 0;
    
    [SerializeField][Range(_minTimeToPointsValue,_maxTimeToPointsValue)]
    private List<float> _timesToPoints;
    [SerializeField][Min(_minNumOfPointsValue)] private int _numOfPoints;

    public float MinTimeToPointsValue => _minTimeToPointsValue;
    public float MaxTimeToPointsValue => _maxTimeToPointsValue;
    public int MinNumOfPointsValue => _minNumOfPointsValue;
    public List<float> TimesToPoints => _timesToPoints;
    public int NumOfPoints => _numOfPoints;
}
