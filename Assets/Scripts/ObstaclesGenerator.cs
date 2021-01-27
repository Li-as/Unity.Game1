using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _minSecondsBetweenSpawn;
    [SerializeField] private float _maxSecondsBetweenSpawn;

    private float _elapsedTime;
    private float _secondsToNextSpawn;

    private void Start()
    {
        Initialize(_template);
        _secondsToNextSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsToNextSpawn)
        {
            if (TryGetObject(out GameObject obstacle))
            {
                obstacle.SetActive(true);
                obstacle.transform.position = transform.position;

                
                _elapsedTime = 0;
                _secondsToNextSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);
            }

            DisableObjectsOutsideScreen();
        }
    }
}
