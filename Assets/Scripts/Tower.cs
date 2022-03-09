using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] [Range(0f, 10f)] float buildDelay = 1f;

    void Start() {
        StartCoroutine(Build());
    }

    private IEnumerator Build()
    {
        foreach(Transform child in transform) {
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in child) {
                grandchild.gameObject.SetActive(false);
            }
        }
        foreach(Transform child in transform) {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach(Transform grandchild in child) {
                grandchild.gameObject.SetActive(true);
            }
        }
    }

    internal bool InstantiateTower(Tower towerPrefab, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        
        if (bank == null) { return false; }

        if(bank.CurrentBalance >= cost) {
            Instantiate(towerPrefab.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }
        return false;
    }
}
