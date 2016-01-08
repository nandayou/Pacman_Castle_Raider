using UnityEngine;
using System.Collections;

public class PointsOnCol : MonoBehaviour
{

    public GameObject point;
    public int amountDropped;
    int dropped = 0;
    bool drop;


    void Update()
    {
        if (amountDropped == dropped)
        {
            drop = false;
            dropped = 0;
        }
        else if (drop)
        {
            GameObject _point = Instantiate(point, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y + ((360 / amountDropped) * dropped), transform.rotation.z))) as GameObject;
            _point.GetComponent<Rigidbody>().AddForce(_point.transform.forward * 100);
            dropped++;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Weapon")
        {
            drop = true;
        }
    }
}
