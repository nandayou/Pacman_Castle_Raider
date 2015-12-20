using UnityEngine;
using System.Collections;

public class patrollerAI : MonoBehaviour {
    public GameObject[] navpoints;
    private int currentNavPoint;
    private NavMeshAgent ghost;
    private GameObject hero;
    float rayLength = 6.0f;
//    public Transform fleeDestination;
//    public Transform graveyard;
    // public killerScript killer; // Temporary name for script that calls the killer bool powerup
    bool fleeing = false;
    bool dead = false;


	// Use this for initialization
	void Start ()
    {
        hero = GameObject.Find("Hero");
        currentNavPoint = 0;
        ghost = gameObject.GetComponent<NavMeshAgent>();
        ghost.SetDestination(navpoints[currentNavPoint].transform.position);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray rayForward = new Ray(new Vector3(transform.position.x, 0.45f, transform.position.z), Vector3.forward * 5);
        Ray rayRight = new Ray(new Vector3(transform.position.x, 0.45f, transform.position.z), Vector3.right * 5);
        Ray rayLeft = new Ray(new Vector3(transform.position.x, 0.45f, transform.position.z), Vector3.left * 5);
        Ray rayBackwards = new Ray(new Vector3(transform.position.x, 0.45f, transform.position.z), Vector3.back * 5);
        RaycastHit hitinfo;

        if (Physics.Raycast(rayForward, out hitinfo, rayLength))
        {
            if (hitinfo.collider.gameObject.tag == "Hero")
            {
                ghost.SetDestination(hero.transform.position);
            }
        }
        if (Physics.Raycast(rayRight, out hitinfo, rayLength))
        {
            if (hitinfo.collider.gameObject.tag == "Hero")
            {
                ghost.SetDestination(hero.transform.position);
            }
        }
        if (Physics.Raycast(rayLeft, out hitinfo, rayLength))
        {
            if (hitinfo.collider.gameObject.tag == "Hero") 
            {
                ghost.SetDestination(hero.transform.position);
            }
        }
        if (Physics.Raycast(rayBackwards, out hitinfo, rayLength))
        {
            if (hitinfo.collider.gameObject.tag == "Hero")
            {
                ghost.SetDestination(hero.transform.position);
            }
        }

/*        if (ghost.remainingDistance < 0.5f && killerScript.killBool == false && dead == false)
        {
            currentNavPoint = (currentNavPoint + 1) % navpoints.Length;
            ghost.SetDestination(navpoints[currentNavPoint].transform.position);
            // //-= insert calling of material change here =-
        }
        if (killerScript.killBool == true && dead == false)
        {
            ghost.SetDestination(fleeDestination.transform.position);
            //-= insert calling of material change here =-
        }
        if (dead)
        {
            ghost.SetDestination(graveyard.transform.position);
            //-= insert calling of material change here =-
        } */
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hero" /* && killerScript.killBool*/)
        {
            dead = true;
        }
        if (other.gameObject.tag == "GhostHouse")
        {
            dead = false;
        }
    }
}
