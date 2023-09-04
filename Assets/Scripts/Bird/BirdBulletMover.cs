using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBulletMover : Mover
{
    private Bird _bird;

    protected override void Move()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
}
