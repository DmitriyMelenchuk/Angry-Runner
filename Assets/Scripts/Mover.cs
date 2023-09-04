using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float Speed;

    private void Update()
    {
        Move();       
    }

    protected abstract void Move();
}
