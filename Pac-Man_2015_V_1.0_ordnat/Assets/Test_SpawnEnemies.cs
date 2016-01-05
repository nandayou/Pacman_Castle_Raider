using UnityEngine;
using System.Collections;

public class Test_SpawnEnemies : MonoBehaviour
{

    float timer;
    int nextEnemy = 0;

    int aliveEnemies;

    public GameObject[] enemies;
    public float spawnTimer;
    public GameObject spawnPosition;

    //int _alive;

    void Start()
    {
        timer = 5;
    }

    void Update()
    {
        //_alive = GameObject.FindGameObjectsWithTag("Enemy").Length;   //Skapar en array varje frame

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0 && aliveEnemies != enemies.Length)
        {
            Instantiate(enemies[nextEnemy], spawnPosition.transform.position, Quaternion.identity);
            aliveEnemies++;
            timer = 5;

            if (nextEnemy == enemies.Length - 1)
            {
                nextEnemy = 0;
            }
            else
            {
                nextEnemy++;
            }
        }
    }

    public void Killed()
    {
        timer = spawnTimer;
        aliveEnemies--;
    }
}
