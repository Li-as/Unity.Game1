using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField] private ObjectPool _obstaclesPool;
    [SerializeField] private Obstacle _template;
    [SerializeField] private float _minSecondsBetweenSpawn;
    [SerializeField] private float _maxSecondsBetweenSpawn;

    private float _elapsedTime;
    private float _secondsToNextSpawn;

    public event UnityAction<GameObject> ObstacleSpawned;

    private void Start()
    {
        _obstaclesPool.Initialize(_template.gameObject);
        _secondsToNextSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsToNextSpawn)
        {
            if (_obstaclesPool.TryGetObject(out GameObject obstacle))
            {
                obstacle.SetActive(true);
                obstacle.transform.position = transform.position;
                ObstacleSpawned?.Invoke(obstacle);

                _elapsedTime = 0;
                _secondsToNextSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);
            }
        }
    }
}
