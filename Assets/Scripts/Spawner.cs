using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : ObjectPool
{
    [SerializeField] private GameObject _template;

    [SerializeField] protected float SecondsBetweenSpawn;

    private void OnEnable()
    {
        Initialize(_template);
        StartCoroutine(DelaySpawn());
    }

    protected virtual IEnumerator DelaySpawn()
    {
        var waitForSeconds = new WaitForSeconds(SecondsBetweenSpawn);

        while (enabled == true)
        {
            if (TryGetObject(out GameObject gameObject))
            {
                yield return waitForSeconds;
                SetObject(gameObject, GetSpawnPoint());
                DisableObjectAbdroadScreen();
            }

            yield return null;
        }
    }
    
    protected abstract Vector3 GetSpawnPoint();

    protected virtual void SetObject(GameObject gameObject, Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = spawnPoint;
    }
}
