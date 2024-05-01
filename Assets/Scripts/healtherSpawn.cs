using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healtherSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject healther;
    public GameObject ship;
    public float healthOlasilik = 0.8f;
    // Update is called once per frame
    void Update()
    {
        float atmaOlasiligi = Time.deltaTime * healthOlasilik;
        if (Random.value < atmaOlasiligi)
        {
            Spawner();
        }
    }
    void Spawner()
    {
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(healther, spawnPoints[randSpawnPoint].position, transform.rotation);
    }
}
