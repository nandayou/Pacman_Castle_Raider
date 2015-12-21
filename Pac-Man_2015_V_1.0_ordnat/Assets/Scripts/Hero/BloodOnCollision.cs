using UnityEngine;
using System.Collections;

public class BloodOnCollision : MonoBehaviour {

    public GameObject enemyHitParticles;

    //On collision it spawns the gameobject stored in "particles" on each contact point and then destroys the spawned gameobjects after 0.2 seconds
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject)
        {
            foreach(ContactPoint contact in col.contacts)
            {
                GameObject _particleSystem = Instantiate(enemyHitParticles, contact.point, Quaternion.identity) as GameObject;
                Destroy(_particleSystem, 0.3f);
            }

        }
    }
    //When collidion with an enemy trigger, instantiate particlesystem and destroy it after 1 second
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            GameObject _particleSystem = Instantiate(enemyHitParticles, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(_particleSystem, 1f);
        }
    }
}
