using UnityEngine;
using System.Collections;

public class TestBoss : MonoBehaviour
{
    Vector3 startPosition;
    public float rotationSpeed;
    public float chargeSpeed;
    GameObject hero;
    bool charge = false;
    public GameObject point;

    void Start()
    {
        startPosition = transform.position;
        hero = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            charge = false;
        }
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3(0, 0, 0);
        }
        if (col.gameObject.tag == "Enemy")
        {
            for (int i = 0; i < 6; i++)
            {
                GameObject _point = Instantiate(point, new Vector3(transform.position.x, transform.position.y * 1.5f, transform.position.z), Quaternion.Euler(new Vector3(0, 360 / 6 * i, 0))) as GameObject;
                _point.GetComponent<Rigidbody>().AddForce(-transform.forward);
            }
            charge = false;
        }
    }

    void Update()
    {
        RaycastHit hitInfo;
        Ray eyes = new Ray(new Vector3(transform.position.x, hero.GetComponent<Collider>().bounds.size.y / 2, transform.position.z), transform.forward);
        Debug.DrawRay(eyes.origin, eyes.direction * 100f, Color.red);

        if (charge)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * Time.deltaTime * chargeSpeed;
        }
        else if (transform.position != startPosition)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = Vector3.MoveTowards(transform.position, startPosition, Time.deltaTime * 2);
        }
        else if (Physics.Raycast(eyes, out hitInfo, Mathf.Infinity) && hitInfo.transform == hero.transform)
        {
            charge = true;
        }
        else
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
    }
}
