using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test_SpawnEnemies : MonoBehaviour
{

    float timer;

    public float spawnTimer;
    public GameObject spawnPosition;

    public List<GameObject> enemiesQueue;

    //int _alive;

    void Start()
    {
        timer = 5;
        enemiesQueue.ForEach(enemy => Instantiate(enemy, spawnPosition.transform.position, Quaternion.identity));
    }

    void Update()
    {
        //_alive = GameObject.FindGameObjectsWithTag("Enemy").Length;   //Skapar en array varje frame

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (enemiesQueue.Count != 0 && timer <= 0)
        {
            /*if (enemiesQueue[0].activeSelf == false)
            {
                enemiesQueue[0].SetActive(true);
                Destroy(enemiesQueue[0]);
            } */

            //GameObject enemy = Instantiate(enemiesQueue[0], spawnPosition.transform.position, Quaternion.identity) as GameObject;
            //enemy.transform.parent = transform;

            enemiesQueue[0].transform.position = spawnPosition.transform.position;
            enemiesQueue[0].SetActive(true);
            enemiesQueue.RemoveAt(0);

            timer = spawnTimer;

        }
    }

    public void Killed(GameObject deadEnemy)
    {
        timer = spawnTimer;
        enemiesQueue.Add(deadEnemy);
    }
}
