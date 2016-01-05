using UnityEngine;
using System.Collections;

public class LifeSpawner : MonoBehaviour {

    GameObject[] navpoints;
    float spawnTimer;

    public GameObject visual;
    public float spawnTime;

    void Start()
    {
        navpoints = GameObject.FindGameObjectsWithTag("navpoint");
    }

    void PowerUpSpawn()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            Instantiate(visual, navpoints[Random.Range(0, navpoints.Length)].transform.position, Quaternion.identity);
            spawnTimer = spawnTime;
        }
    }
}
