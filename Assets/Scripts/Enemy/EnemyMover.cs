using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : Mover
{
    protected override void Move()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }
}
