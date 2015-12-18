using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

    public float rotationSpeed = 100;
    bool magnet;
    public AudioClip pickUpSound;
    public GameObject key;

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
                int points = GameObject.FindGameObjectsWithTag("Point").Length;
                if(points == 1)
                {
                    GameObject _key = Instantiate(key, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity) as GameObject;
                    _key.transform.parent = col.gameObject.transform;
                }
            }
        }
    }

    void PlaySound()
    {
        GetComponent<AudioSource>().clip = pickUpSound;
        GetComponent<AudioSource>().Play();
    }
}
