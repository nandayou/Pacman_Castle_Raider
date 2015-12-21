using UnityEngine;
using System.Collections;

public class Hero_trigger : MonoBehaviour {

    public int points = 0;
    public int _points;
    public int lives = 1;

    Vector3 startPosition;

	void Start ()
    {
        startPosition = transform.position;
	}

    void OnTriggerEnter(Collider col)
    {
        /*if (col.gameObject.tag == "Point")
        {
            Destroy(col.gameObject);
            points++;
            _points++;

            if (_points == 10)
            {
                lives++;
                _points = 0;
            }
        }*/
        if (col.gameObject.tag == "Ghost")
        {
            transform.position = startPosition;
            lives--;
        }
        else if (col.gameObject.tag == "PowerUp")
        {
            Destroy(col.gameObject);
            Debug.Log("PowerUp");
        }
       /* else if(col.gameObject.tag == "Key")
        {
            Debug.Log("Picked up key");
            col.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            col.gameObject.transform.parent = transform;
        }*/
    }
}