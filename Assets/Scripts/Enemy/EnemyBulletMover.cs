using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMover : Mover
{
    protected override void Move()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }
}
