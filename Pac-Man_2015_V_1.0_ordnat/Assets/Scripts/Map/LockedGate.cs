using UnityEngine;
using System.Collections;

public class LockedGate : MonoBehaviour {

    //If the inventory script has a gameobject in the key variable, destroy gate, key gameobject and set key variable to null
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
