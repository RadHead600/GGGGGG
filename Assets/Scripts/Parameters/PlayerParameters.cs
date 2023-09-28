using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameters", menuName = "CustomParameters/PlayerParameters")]
public class PlayerParameters : UnitParameters
{
    [SerializeField] private float _timeBeforRestartScene;

    public float TimeBeforRestartScene => _timeBeforRestartScene;
}
