using UnityEngine;
using System.Collections;

public class Alpha_movement : MonoBehaviour {

    public float speed;

	void Update ()
    {
        float h = speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float v = speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;

        //transform.position = new Vector3(transform.position.x + h, transform.position.y, transform.position.z + v);
        GetComponent<Rigidbody>().velocity = new Vector3(h, 0, v);
        //if(Input.GetKey(KeyCode.W))
        //GetComponent<Rigidbody>().AddForce(new Vector3(h, 0, v));
    }
}
