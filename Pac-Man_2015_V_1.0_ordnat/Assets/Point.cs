using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

    public float rotationSpeed = 100;
    bool magnet;
    public AudioClip pickUpSound;

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, col.gameObject.transform.position, Time.deltaTime * 1.5f);
            if(transform.position == col.gameObject.transform.position)
            {
                PlaySound();
                Destroy(gameObject);
            }
        }
    }

    void PlaySound()
    {
        GetComponent<AudioSource>().clip = pickUpSound;
        GetComponent<AudioSource>().Play();
    }
}
