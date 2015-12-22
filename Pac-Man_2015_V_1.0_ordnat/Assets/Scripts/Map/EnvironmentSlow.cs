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

    //When hero moves inside the trigger, he will be slowed
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == hero)
        {
            hero.GetComponent<Movement>().speed *= slowAmount;
        }
    }

    //When hero exits the trigger, heros speed will be set to the default speed
    void OnTriggerExit()
    {
        hero.GetComponent<Movement>().speed = originalSpeed;
    }
}
