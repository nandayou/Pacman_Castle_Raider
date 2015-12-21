using UnityEngine;
using System.Collections;

public class EnvironmentSlow : MonoBehaviour {

    public float slowAmount;
    float originalSpeed;

    GameObject hero;

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
        originalSpeed = hero.GetComponent<Movement>().speed;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == hero)
        {
            hero.GetComponent<Movement>().speed *= slowAmount;
        }
    }

    void OnTriggerExit()
    {
        hero.GetComponent<Movement>().speed = originalSpeed;
    }
}
