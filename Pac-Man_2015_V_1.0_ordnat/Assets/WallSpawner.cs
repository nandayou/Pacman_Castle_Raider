using UnityEngine;
using System.Collections;

public class WallSpawner : MonoBehaviour
{

    float timer;
    public float respawnTimer;
    public GameObject particleDestroy;
    public GameObject particleSpawn;

    bool visible;

    void Update()
    {

        GetComponent<BoxCollider>().enabled = visible;
        GetComponent<MeshRenderer>().enabled = visible;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (!visible)
        {
            visible = true;
            GameObject particles = Instantiate(particleSpawn, transform.position, Quaternion.identity) as GameObject;
            Destroy(particles, particleSpawn.GetComponent<ParticleSystem>().startLifetime);
        }


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Weapon")
        {
            visible = false;
            timer = respawnTimer;

            GameObject particles = Instantiate(particleDestroy, transform.position, Quaternion.identity) as GameObject;
            Destroy(particles, particleDestroy.GetComponent<ParticleSystem>().startLifetime);
        }
    }
}