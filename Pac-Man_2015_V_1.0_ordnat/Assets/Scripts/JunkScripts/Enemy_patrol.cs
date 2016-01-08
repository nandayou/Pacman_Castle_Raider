using UnityEngine;
using System.Collections;

public class Enemy_patrol : MonoBehaviour
{

    GameObject[] navpoints;
    NavMeshAgent agent;
    public bool kill = false;
    public GameObject blood;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //Creates an array of all the gameobjects with the tag navpoint in the scene
        navpoints = GameObject.FindGameObjectsWithTag("navpoint");
    }

    void Update()
    {
        //If agent is close to destination, go to a random element in the navpoints array
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            agent.destination = navpoints[Random.Range(0, navpoints.Length)].transform.position;
        }
        if (kill)
        {
            gameObject.SetActive(false);
            kill = false;
        }
    }

    void OnDisable()
    {
        GameObject.Find("Ghost_House(Place_Holder)").GetComponent<Test_SpawnEnemies>().Killed(gameObject);
        Instantiate(blood, transform.position, Quaternion.identity);
    }
}
