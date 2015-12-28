using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour
{

    public float rotationSpeed = 100;
    public AudioClip pickUpSound;
    public float pointVolume = 0.5f;
    public GameObject key;
    public bool mapRequiresKey;

    private bool _visible = false;
    private string _originalName;

    void Start()
    {
        _originalName = gameObject.name;
    }

    void OnBecameVisible()
    {
        _visible = true;
        gameObject.name = _originalName;
    }

    void OnBecameInvisible()
    {
        _visible = false;
        gameObject.name = _originalName + "(invisible)";
    }

    void Update()
    {
        //Rotates the game object
        if (_visible)
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        //In case gameObject falls through the world, destroy it
        if (transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
    }

    //if player collides with the trigger, move towards the player and then destroy when close enough.
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, col.gameObject.transform.position, Time.deltaTime * 1.5f);
            if (Vector3.Distance(transform.position, col.gameObject.transform.position) < 0.1)
            {
                //Play sound, destroy game object and check how many points are remaining
                PlaySound();
                Destroy(gameObject);
                int points = GameObject.FindGameObjectsWithTag("Point").Length;

                //If this is the last point on the map and hero picks it up, give Hero the key
                if (points == 1)
                {
                    GameObject _key = Instantiate(key, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity) as GameObject;
                    _key.transform.parent = col.gameObject.transform;
                    col.gameObject.GetComponent<Inventory>().key = _key;
                }
            }
        }
    }

    //Creates an object at the game objects location, play sound and then destroy
    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(pickUpSound, transform.position, pointVolume);
    }
}
