using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Tooltip("Seconds between each enemy spanwns")]
    [SerializeField] [Range(0.1f, 30f)] float timeBetweenInstantiations = 1f;
    [Tooltip("Enemy prefab to instantiate")]
    [SerializeField] GameObject EnemyPrefab;
    [Tooltip("Instantiate Enemies?")]
    [SerializeField] bool isEnemyInstantiating = true;
    [SerializeField] [Range(0, 50)] int poolSize = 5;

    private GameObject[] pool;

    private void Awake() {
        PopulatePool();
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for(int i = 0; i < poolSize; i++) {
            pool[i] = Instantiate(EnemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(InstantiateEnemies());    
    }

    private IEnumerator InstantiateEnemies() {
        while(isEnemyInstantiating) {
            EnableObjectInPool();
            yield return new WaitForSeconds(timeBetweenInstantiations);
        }
    }

    private void EnableObjectInPool()
    {
        foreach(GameObject enemyObject in pool) {
            if (!enemyObject.activeInHierarchy) {
                enemyObject.SetActive(true);
                return;
            }
        }
    }
}
