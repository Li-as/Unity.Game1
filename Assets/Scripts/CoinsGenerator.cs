using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : ObjectPool
{
    [SerializeField] private Coin _template;
    [SerializeField] private ObstaclesGenerator _obstaclesGenerator;
    [SerializeField] private int _spawnChance;

    private void OnEnable()
    {
        _obstaclesGenerator.ObstacleSpawned += OnObstacleSpawned;
    }

    private void OnDisable()
    {
        _obstaclesGenerator.ObstacleSpawned -= OnObstacleSpawned;
    }

    private void Start()
    {
        Initialize(_template.gameObject);
    }

    private void OnObstacleSpawned(GameObject obstacle)
    {
        if (Random.Range(1, 101) <= _spawnChance)
        {
            CoinsSpawnLine[] spawnLines = obstacle.GetComponentsInChildren<CoinsSpawnLine>();
            if (spawnLines != null)
            {
                int spawnLineNumber = Random.Range(0, spawnLines.Length);
                int spawnPointsCount = spawnLines[spawnLineNumber].transform.childCount;

                if (spawnPointsCount > 0)
                {
                    for (int i = 0; i < spawnPointsCount; i++)
                    {
                        if (TryGetObject(out GameObject coin))
                        {
                            coin.SetActive(true);
                            Transform spawnPoint = spawnLines[spawnLineNumber].transform.GetChild(i);
                            coin.transform.position = spawnPoint.position;
                        }
                    }
                }
            }
        }

        DisableObjectsOutsideScreen();
    }
}
