using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

    public float rotationSpeed = 100;
    bool magnet;
    public AudioClip pickUpSound;
    public float pointVolume = 0.5f;
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
            if(Vector3.Distance(transform.position, col.gameObject.transform.position) < 0.1)
            {
                PlaySound();
                Destroy(gameObject);
                int points = GameObject.FindGameObjectsWithTag("Point").Length;

                if(points == 1)
                {
                    GameObject _key = Instantiate(key, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity) as GameObject;
                    _key.transform.parent = col.gameObject.transform;
                    col.gameObject.GetComponent<Inventory>().key = _key;
                }
            }
        }
    }

    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(pickUpSound, transform.position, pointVolume);
    }
}
