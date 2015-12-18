using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    bool pickedUp = false;
    public float rotationSpeed = 100;

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (!pickedUp)
            {
                transform.parent = col.gameObject.transform;
                transform.position = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y + 1, col.gameObject.transform.position.z);
                col.gameObject.GetComponent<Inventory>().key = gameObject;
                pickedUp = true;
            }
        }
    }
}
