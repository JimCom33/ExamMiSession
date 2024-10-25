using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePrefab : MonoBehaviour
{
    public GameObject spikePrefab;
    public float spawnFreq = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnFreq);
    }

    void Spawn ()
    {
        Vector3 spawnPos = transform.position;
        Instantiate(spikePrefab, spawnPos, Quaternion.identity);
    }
}
