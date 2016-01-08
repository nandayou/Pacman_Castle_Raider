using UnityEngine;
using System.Collections;

public class DestroyParticles : MonoBehaviour
{

    void Update()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().startLifetime);
    }
}
