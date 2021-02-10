using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    [SerializeField] private ObjectPool _coinsPool;
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
        _coinsPool.Initialize(_template.gameObject);
    }

    private void OnObstacleSpawned(GameObject obstacle)
    {
        if (Random.Range(1, 101) <= _spawnChance)
        {
            CoinsSpawnLine[] spawnLines = obstacle.GetComponentsInChildren<CoinsSpawnLine>();
            if (spawnLines != null)
            {
                int spawnLineNumber = Random.Range(0, spawnLines.Length);
                Transform[] spawnPoints = spawnLines[spawnLineNumber].GetComponentsInChildren<Transform>();

                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    if (spawnPoints[i] != spawnLines[spawnLineNumber].transform)
                    {
                        if (_coinsPool.TryGetObject(out GameObject coin))
                        {
                            coin.SetActive(true);
                            coin.transform.position = spawnPoints[i].position;
                        }
                    }
                }
            }
        }
    }
}
