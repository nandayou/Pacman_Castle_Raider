using UnityEngine;
using System.Collections;

public class Test_portal : MonoBehaviour {

    public GameObject otherPortal;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3(otherPortal.transform.position.x, col.gameObject.transform.position.y, otherPortal.transform.position.z);
        }
    }
}
