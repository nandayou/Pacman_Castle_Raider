using UnityEngine;
using System.Collections;

public class Kill_Hero : MonoBehaviour {

    GameObject hero;
    Vector3 startPosition;

	void Start ()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
        startPosition = hero.transform.position;
	}
	
	void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if(col.gameObject == hero)
        {
            Debug.Log("hallå");
            hero.transform.position = startPosition;
        }
    }
}
