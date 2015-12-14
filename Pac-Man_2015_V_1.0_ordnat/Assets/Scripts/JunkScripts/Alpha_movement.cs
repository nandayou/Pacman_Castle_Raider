using UnityEngine;
using System.Collections;

public class Alpha_movement : MonoBehaviour {

	void Update ()
    {
        float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float v = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + h, transform.position.y, transform.position.z + v);
	}
}
