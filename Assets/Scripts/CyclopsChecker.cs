using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopsChecker : MonoBehaviour
{
    public GameObject cyclops;

    void Start()
    {
        InvokeRepeating("SpawnCyclops", 0.0f, 2.0f);
    }
    void SpawnCyclops()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-11f, 19f), 8f, 0f);

        Instantiate(cyclops, spawnPosition, Quaternion.identity);
    }
}
