using UnityEngine;
using System.Collections;

public class Kill_Hero : MonoBehaviour {

    GameObject hero;
    Vector3 startPosition;

	void Start ()
    {
        //Find hero
        hero = GameObject.FindGameObjectWithTag("Player");
        startPosition = hero.transform.position;
	}
	
    //If colliding with hero trigger, put Hero at his start position
	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == hero)
        {
            hero.transform.position = startPosition;
        }
    }
}
