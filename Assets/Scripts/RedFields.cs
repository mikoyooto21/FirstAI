using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFields : MonoBehaviour
{
    [SerializeField] private GameObject redField;

    void Start()
    {
        InvokeRepeating("SpawnRedField", 2f, 3f);
    }

    private void SpawnRedField()
    {
        Vector3 spawnPosition = CalculateSpawn();
        Instantiate(redField, spawnPosition, Quaternion.identity, transform);
    }

    private Vector3 CalculateSpawn(){
        int x = Random.Range(1, 20);
        int z = Random.Range(1, 20);
        return new Vector3(x, 0.3001f, z);
    }
}
