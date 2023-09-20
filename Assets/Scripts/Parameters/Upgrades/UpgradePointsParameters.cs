using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "UpgradePointsParameters", menuName = "CustomParameters/UpgradesParameters/UpgradePointsParameters")]
public class UpgradePointsParameters : ScriptableObject
{
    [Header("How long does it take to complete a level to get a gem?")]
    [SerializeField][Range(0, 1)] private List<float> _timesToPoints;
    [Header("how many _gems per time?")]
    [SerializeField][Min(0)] private int _numOfPoints;

    public List<float> TimesToPoints => _timesToPoints;
    public int NumOfPoints => _numOfPoints;
}
