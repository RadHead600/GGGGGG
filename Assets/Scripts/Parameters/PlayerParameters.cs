using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameters", menuName = "CustomParameters/PlayerParameters")]
public class PlayerParameters : UnitParameters
{
    [Header("waiting time before restarting the death scene")]
    [SerializeField] private float _timeBeforRestartScene;

    public float TimeBeforRestartScene => _timeBeforRestartScene;
}
