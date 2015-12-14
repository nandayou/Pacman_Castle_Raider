using UnityEngine;
using System.Collections;

public class hunterAI : MonoBehaviour {
    private NavMeshAgent ghost; // NavMeshAgent for the ghost in question
    public Transform Hero;
/*    public Transform fleeDestination; // Destination during flee command
    public Transform graveyard; // Destination after death
    public killerScript killer; //Temporary name for what will initiate the killer bool for the powerup
    bool fleeing = false; //Bool for fleeing
    bool dead = false; // Bool for death
*/
	// Use this for initialization
	void Start ()
    {
        ghost = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (ghost.remainingDistance < 0.5 /* && killerScript.killBool == false && dead == false */)
        {
            ghost.SetDestination(Hero.transform.position);
            //-= insert calling of material change here =-
        }
/*        if (killerScript.killBool == true && dead == false)
        {
            ghost.SetDestination(fleeDestination.transform.position); // Moves ghost to the set destination during the killer bool activation
            //-= insert calling of material change here =-
        }
        if (dead)
        {
            ghost.SetDestination(graveyard.transform.position);
            //-= insert calling of material change here =-
        } */
    }
/*
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Hero" && killer.killBool)
        {
            dead = true;
        }
        if(other.gameObject.tag == "GhostHouse")
        {
            dead = false;
        }
    } */
}
