using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour 
{ 
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private Camera _camera;
    private readonly List<GameObject> _pool = new List<GameObject>();

    protected void DisableObjectAbdroadScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (var pool in _pool)
        {
            if (pool.activeSelf == true)
            {
                if (pool.transform.position.x < disablePoint.x)
                    pool.SetActive(false);
            }
        }
    }

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(pool => pool.activeSelf == false);

        return result != null;
    }

    public void ResetPool()
    {
        foreach (var pool in _pool)
        {
            pool.SetActive(false);
        }
    }
}
