using UnityEngine;
using System.Collections;

public class Alpha_Weapon : MonoBehaviour {


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x + 90, transform.rotation.y, transform.rotation.z), 0.5f);
            Debug.Log("Rotate weapon");
        }
    }
}