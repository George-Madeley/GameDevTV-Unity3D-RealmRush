using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Tooltip("Seconds between each enemy spanwns")]
    [SerializeField] float timeBetweenInstantiations = 1f;
    [Tooltip("Enemy prefab to instantiate")]
    [SerializeField] GameObject EnemyPrefab;
    [Tooltip("Instantiate Enemies?")]
    [SerializeField] bool isEnemyInstantiating = true;

    void Start()
    {
        StartCoroutine(InstantiateEnemies());    
    }

    private IEnumerator InstantiateEnemies() {
        while(isEnemyInstantiating) {
            Instantiate(EnemyPrefab, transform);
            yield return new WaitForSecondsRealtime(timeBetweenInstantiations);
        }
    }
}
