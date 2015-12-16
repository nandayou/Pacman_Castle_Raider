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
        if (col.gameObject.tag == "Point")
        {
            Destroy(col.gameObject);
            points++;
            _points++;

            if (_points == 10)
            {
                lives++;
                _points = 0;
            }
        }
        else if (col.gameObject.tag == "Ghost")
        {
            transform.position = startPosition;
            lives--;
        }
        else if (col.gameObject.tag == "PowerUp")
        {
            Destroy(col.gameObject);
            Debug.Log("PowerUp");
        }
    }
}
