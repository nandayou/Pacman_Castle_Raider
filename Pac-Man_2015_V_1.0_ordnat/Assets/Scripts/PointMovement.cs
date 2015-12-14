using UnityEngine;
using System.Collections;

public class PointMovement : MonoBehaviour {

    public float rotationSpeed = 100;
	
	void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
