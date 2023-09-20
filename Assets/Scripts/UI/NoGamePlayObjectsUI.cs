using System.Collections.Generic;
using UnityEngine;

public class NoGamePlayObjectsUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;

    private void Start()
    {
        StartGameController.Instance.OnStartGame += ClosePanels;
        LevelProgress.Instance.OnCompletedLevel += OpenPanels;
    }

    public void ClosePanels()
    {
        foreach (var obj in _objects)
        {
            obj.SetActive(false);
        }
    }

    public void OpenPanels()
    {
        foreach (var obj in _objects)
        {
            obj.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        StartGameController.Instance.OnStartGame -= ClosePanels;
        LevelProgress.Instance.OnCompletedLevel -= OpenPanels;
    }
}
