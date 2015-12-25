using UnityEngine;
using System.Collections;

public class Enemy_patrol : MonoBehaviour {

    GameObject[] navpoints;
    NavMeshAgent agent;

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

        //Creates an array of all the gameobjects with the tag navpoint in the scene
        navpoints = GameObject.FindGameObjectsWithTag("navpoint");
	}
	
	void Update ()
    {
        //If agent is close to destination, go to a random element in the navpoints array
        if(agent.remainingDistance < agent.stoppingDistance)
        {
            agent.destination = navpoints[Random.Range(0, navpoints.Length)].transform.position;
        }
	}
}
