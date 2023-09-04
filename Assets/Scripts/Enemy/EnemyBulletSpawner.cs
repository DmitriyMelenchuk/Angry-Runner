using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class EnemyBulletSpawner : Spawner
{
    protected override Vector3 GetSpawnPoint()
    {
        return transform.position;
    }
}
