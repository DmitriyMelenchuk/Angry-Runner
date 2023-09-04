using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdCollisionHandler : MonoBehaviour
{
    private Bird _bird;
     
    public void Init(Bird bird)
    {
        _bird = bird;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BirdBullet birdBullet))
            return;
        else
            _bird.Die();
    }
}
