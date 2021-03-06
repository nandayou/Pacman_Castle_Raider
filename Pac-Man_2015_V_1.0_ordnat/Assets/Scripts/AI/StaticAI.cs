﻿using UnityEngine;
using System.Collections;

public class StaticAI : MonoBehaviour {
    private NavMeshAgent ghost;
    Transform hero;
    float rayLength = 6.0f;


	// Use this for initialization
	void Start ()
    {
        hero = GameObject.FindWithTag("Player").transform;
        ghost = gameObject.GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Ray rayForward = new Ray(new Vector3(transform.position.x, 0.45f, transform.position.z), Vector3.forward * 5);
        Ray rayRight = new Ray(new Vector3(transform.position.x, 0.45f, transform.position.z), Vector3.right * 5);
        Ray rayLeft = new Ray(new Vector3(transform.position.x, 0.45f, transform.position.z), Vector3.left * 5);
        Ray rayBackwards = new Ray(new Vector3(transform.position.x, 0.45f, transform.position.z), Vector3.back * 5);
        RaycastHit hitinfo;

        //Vector3.RotateTowards(transform.position, ghost.transform.position, 1f, 1f);
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.position, ghost.transform.position, 50f * Time.deltaTime, 0f));


        if (Physics.Raycast(rayForward, out hitinfo, rayLength))
        {
            if (hitinfo.collider.gameObject.tag == "Player")
            {
                ghost.destination = hero.position;
            }
        }
        if (Physics.Raycast(rayRight, out hitinfo, rayLength))
        {
            if (hitinfo.collider.gameObject.tag == "Player")
            {
                ghost.destination = hero.position;
            }
        }
        if (Physics.Raycast(rayLeft, out hitinfo, rayLength))
        {
            if (hitinfo.collider.gameObject.tag == "Player")
            {
                ghost.destination = hero.position;
            }
        }
        if (Physics.Raycast(rayBackwards, out hitinfo, rayLength))
        {
            if (hitinfo.collider.gameObject.tag == "Player")
            {
                ghost.destination = hero.position;
            }
        }
    }
}
