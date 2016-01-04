using UnityEngine;
using System.Collections;

public class Movement1 : MonoBehaviour
{
    public GameObject heroModel;            //The model that will rotate with the movement
    public float speed = 1.5f;              //The speed of Hero

    [HideInInspector]
    public Vector3 moveDir;                 //The direction hero is moving

    private float _rayLength = 0.6f;        //Ray length
    private float _pacSize;                 //The size of the attached to Hero

    void Start()
    {
        _pacSize = GetComponent<SphereCollider>().bounds.size.x;
    }

    void Update()
    {
        //The movement
        GetComponent<Rigidbody>().velocity = moveDir * Time.deltaTime * speed;

        //if Hero is moving, move towards moveDir
        if (moveDir != Vector3.zero)
        {
            heroModel.transform.rotation = Quaternion.Lerp(heroModel.transform.rotation, Quaternion.LookRotation(moveDir), 0.4f);
        }

        //If there is a wall right ahead of Hero, stop movement
        if (Physics.Raycast(transform.position, moveDir, _rayLength / 2))
        {
            moveDir = Vector3.zero;
        }


        //When player uses inputs, check if there is a wall in the way and change moveDir if it isn't
        if (Input.GetKey(KeyCode.W) && CheckIfOpen(Vector3.forward))
        {
            moveDir = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S) && CheckIfOpen(Vector3.back))
        {
            moveDir = Vector3.back;
        }
        else if (Input.GetKey(KeyCode.A) && CheckIfOpen(Vector3.left))
        {
            moveDir = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D) && CheckIfOpen(Vector3.right))
        {
            moveDir = Vector3.right;
        }
    }

    bool CheckIfOpen(Vector3 direction)
    {
        Ray checkDirFront = new Ray(new Vector3(transform.position.x + _pacSize / 2 * direction.z, transform.position.y, transform.position.z + _pacSize / 2 * direction.x), direction);
        Ray checkDirBack = new Ray(new Vector3(transform.position.x - _pacSize / 2 * direction.z, transform.position.y, transform.position.z - _pacSize / 2 * direction.x), direction);
        Ray checkDirMiddle = new Ray(transform.position, direction);


        if (!Physics.Raycast(checkDirFront, _rayLength) && !Physics.Raycast(checkDirBack, _rayLength) && !Physics.Raycast(checkDirMiddle, _rayLength))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}