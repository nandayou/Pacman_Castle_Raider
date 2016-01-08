using UnityEngine;
using System.Collections;

public class PickUpWeapon : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameObject.transform.parent = col.gameObject.GetComponentInChildren<Transform>().FindChild("Model");
            gameObject.transform.position = new Vector3(transform.position.x + gameObject.GetComponent<Renderer>().bounds.size.y / 2, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.identity;
            GetComponent<PickUpWeapon>().enabled = false;
            Debug.Log("Pick up");
        }
    }
}
