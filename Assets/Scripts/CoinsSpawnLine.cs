using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawnLine : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

    public Transform[] SpawnPoints => _spawnPoints;
}
