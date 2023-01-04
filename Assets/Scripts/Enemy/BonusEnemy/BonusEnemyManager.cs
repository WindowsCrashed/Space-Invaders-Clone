using System.Collections;
using UnityEngine;

public class BonusEnemyManager : MonoBehaviour
{
    [SerializeField] BonusEnemySpawner[] spawners;
    [SerializeField] float spawnInterval;

    int currentSpawner;
    Coroutine spawningCoroutine;

    void Start()
    {
        spawningCoroutine = StartCoroutine(SpawningCoroutine());    
    }

    IEnumerator SpawningCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            spawners[currentSpawner].Spawn();
            UpdateSpawner();
        }    
    }

    void UpdateSpawner()
    {
        if (currentSpawner < spawners.Length - 1)
        {
            currentSpawner++;
        }
        else
        {
            StopSpawning();
            currentSpawner = 0;
        }
    }

    void StopSpawning()
    {
        StopCoroutine(spawningCoroutine);
        spawningCoroutine = null;
    }
}
