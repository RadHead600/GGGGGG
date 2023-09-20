using UnityEngine;

public class MoveTo : MonoBehaviour, IMove
{
    [SerializeField] private Vector3 _direction;

    private void Start()
    {
        LevelProgress.Instance.OnCompletedLevel += DisableScript;
        StartGameController.Instance.OnStartGame += EnableScript;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += _direction;
    }

    public void EnableScript()
    {
        this.enabled = true;
    }

    public void DisableScript()
    {
        this.enabled = false;
    }

    private void OnDestroy()
    {
        LevelProgress.Instance.OnCompletedLevel -= DisableScript;
        StartGameController.Instance.OnStartGame -= EnableScript;
    }
}
