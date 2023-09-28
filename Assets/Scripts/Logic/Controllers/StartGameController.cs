using System;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : Singleton<StartGameController>
{
    private const int InitialLevel = 0;
    private const int DefaultPassedLevel = 1;
    private const int DefaultSkin = 0;
    private const int DefaultWeapon = 0;
    private const float DefaultTime = 0f;
    
    [SerializeField] private List<Shop> _shops;
    [SerializeField] private List<EnemySpawner> _enemySpawners;
    [SerializeField] private List<Spawner> _spawners;
    [SerializeField] private PointsTimer _pointsTimer;
    [SerializeField] private MoveTo _startTerrain;
    [SerializeField] private UpgradeCanvas _upgradeCanvas;

    public event Action OnStartGame;

    private void Start()
    {
        _startTerrain.DisableScript();
        OnStartGame += _startTerrain.EnableScript;
    }

    public void SetGameParams()
    {
        ChangeLanguageController.Instance.SetLanguage();
        
        if (GameInformation.Instance.Information.PassedLevel == InitialLevel)
            GameInformation.Instance.Information.PassedLevel = DefaultPassedLevel;

        if (GameInformation.Instance.Information.SkinsBought == null)
        {
            GameInformation.Instance.Information.SkinsBought = new List<int>
            {
                 DefaultSkin
            };
        }

        _shops[1].UnlockItems(GameInformation.Instance.Information.SkinsBought);
        _shops[1].Equip(GameInformation.Instance.Information.SkinEquip);

        if (GameInformation.Instance.Information.WeaponsBought == null)
        {
            GameInformation.Instance.Information.WeaponsBought = new List<int>
            {
                DefaultWeapon
            };
        }
        _shops[0].UnlockItems(GameInformation.Instance.Information.WeaponsBought);
        _shops[0].Equip(GameInformation.Instance.Information.WeaponEquip);
        LevelProgressUI.Instance.UpdateLevelNumText(GameInformation.Instance.Information.PassedLevel);
        _upgradeCanvas.gameObject.SetActive(true);
    }

    public void StartLevel()
    {
        int countKillsOnLevel = 0;
        float time = 0;
        
        foreach (var spawner in _spawners)
            spawner.StartSpawner();

        foreach (var enemySpawner in _enemySpawners)
            enemySpawner.StartSpawner();

        foreach (var enemySpawner in _enemySpawners)
        {
            SpawnerEnemiesParameters spawnerParameters = (SpawnerEnemiesParameters)enemySpawner.SpawnerParameters;
            countKillsOnLevel = enemySpawner.ObjectsCount * enemySpawner.WavesToPassed;
            time = (spawnerParameters.TimeToKillInSeconds * countKillsOnLevel + (enemySpawner.WavesToPassed * enemySpawner.EnemiesReloadingTime + 1)) * spawnerParameters.AdditionalTime;
        }
        LevelProgress.Instance.RequiredNumberOfKills = countKillsOnLevel;
        
        if (_pointsTimer != null)
            _pointsTimer.StartTimer(time);

        OnStartGame?.Invoke();
    }

    private void OnDestroy()
    {
        OnStartGame -= _startTerrain.EnableScript;
    }
}
