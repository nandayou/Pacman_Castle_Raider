using UnityEngine;
using System.Collections;

public class Enemy_patrol : MonoBehaviour {

    GameObject[] navpoints;
    NavMeshAgent agent;

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        navpoints = GameObject.FindGameObjectsWithTag("navpoint");
	}
	
	void Update ()
    {
        if(agent.remainingDistance < agent.stoppingDistance)
        {
            agent.destination = navpoints[Random.Range(0, navpoints.Length)].transform.position;
        }
	}
}
