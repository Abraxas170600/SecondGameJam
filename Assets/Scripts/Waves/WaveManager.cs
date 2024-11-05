using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private int difficultyLimitWave = 10;
    [SerializeField] private List<Enemy> enemyTypes;

    private EnemySpawner spawner;
    private int waveNumber = 0;
    private EnemyTracker enemyTracker;

    private void Start()
    {
        spawner = GetComponent<EnemySpawner>();
        spawner.Initialize(enemyTypes);
        enemyTracker = new(this);

        StartNextWave();
    }

    private void StartNextWave()
    {
        waveNumber++;

        int enemyCount = waveNumber <= difficultyLimitWave ? waveNumber * 10 : difficultyLimitWave * 10;
        float spawnRate = waveNumber <= difficultyLimitWave ? Mathf.Max(0.2f, 1f - (waveNumber * 0.1f)) : Mathf.Max(0.2f, 1f - (difficultyLimitWave * 0.1f));

        WaveConfig waveConfig = new WaveConfigBuilder()
            .SetEnemyCount(enemyCount)
            .SetSpawnRate(spawnRate)
            .SetDifficultyLimitWave(difficultyLimitWave)
            .AddEnemyType(enemyTypes)
            .Build();

        if (enemyTypes != null && waveNumber > 1)
        {
            foreach (var enemyType in enemyTypes)
            {
                waveConfig.EnemyTypes.Add(enemyType);
            }
        }

        enemyTracker.SetEnemyCount(waveConfig.EnemyCount);
        spawner.SpawnWave(waveConfig, NotifyEnemyDestroyed);
    }

    public void OnWaveCleared()
    {
        StartNextWave();
    }

    public void NotifyEnemyDestroyed()
    {
        enemyTracker.DecreaseEnemyCount();
    }
}
