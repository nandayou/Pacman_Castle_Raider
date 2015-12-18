using UnityEngine;
using System.Collections;

public class LockedGate : MonoBehaviour {


    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<Inventory>().key != null)
        {
            Destroy(gameObject);
            Destroy(col.gameObject.GetComponent<Inventory>().key);
            col.gameObject.GetComponent<Inventory>().key = null;
        }
    }
}
