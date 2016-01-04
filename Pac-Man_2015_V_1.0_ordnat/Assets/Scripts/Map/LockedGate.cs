using UnityEngine;
using System.Collections;

public class LockedGate : MonoBehaviour
{

    public GameObject[] doors;

    //If the inventory script has a game object in the key variable, destroy gate, key game object and set key variable to null
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<Inventory>().key != null)
        {
            foreach (GameObject door in doors)
            {
                Destroy(door);
            }
            Destroy(col.gameObject.GetComponent<Inventory>().key);
            col.gameObject.GetComponent<Inventory>().key = null;
        }
    }
}
