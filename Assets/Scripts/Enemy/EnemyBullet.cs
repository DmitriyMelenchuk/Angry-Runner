using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
        {
            bird.Die();
            Enabled();
        }
    }

    private void Enabled()
    {
        gameObject.SetActive(false);
    }
}
