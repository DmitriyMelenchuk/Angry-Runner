using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private Transform[] _point;
    protected override Vector3 GetSpawnPoint()
    {
        int spawnPointNumber = Random.Range(0, _point.Length);
        return _point[spawnPointNumber].position;
    }
}
