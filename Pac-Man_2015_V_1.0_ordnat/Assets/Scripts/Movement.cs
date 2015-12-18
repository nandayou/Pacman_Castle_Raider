using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    bool move = false;
    bool turn;
    public GameObject heroModel;

    // Floats.orward-wall detection. I found .505f to be more precise than .5f.
    float rayLengthZ = 0.35f; // This ray is for f

    float speed = 1.5f;
    float rayLengthX = 0.6f; // The ray is cast from pacmans center, with 0.5f to closest SIDE-wall, so I wen

    Vector3 moveDir;

    Ray rayForward;
    Ray rayBackward;
    Ray rayRight;
    Ray rayLeft;
    
    void Start()
    {
        rayLengthZ = GetComponent<Renderer>().bounds.size.x;

    }

    void Update()
    {
        /*
        RaycastHit hitinfo;

        rayForward = new Ray(transform.position, Vector3.forward);
        rayBackward = new Ray(transform.position, Vector3.back); 
        rayRight = new Ray(transform.position, Vector3.right);
        rayLeft = new Ray(transform.position, Vector3.left); */

        transform.Translate(moveDir * Time.deltaTime * speed);

        if(moveDir != Vector3.zero)
        {
            heroModel.transform.rotation = Quaternion.Lerp(heroModel.transform.rotation, Quaternion.LookRotation(moveDir), 0.4f);
        }
        Debug.DrawRay(transform.position, moveDir, Color.red);

        if (Physics.Raycast(transform.position, moveDir, rayLengthZ))
        {
            moveDir = Vector3.zero;
        }

        //Testcode---------------------------

        if (Input.GetKeyDown(KeyCode.W))
        {
            Ray checkDir = new Ray(transform.position, Vector3.forward);
            if(!Physics.Raycast(checkDir, rayLengthZ))
            {
                moveDir = Vector3.forward;
                Debug.DrawRay(checkDir.origin, checkDir.direction, Color.red);

            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Ray checkDir = new Ray(transform.position, Vector3.down);
            if (!Physics.Raycast(checkDir, rayLengthZ))
            {
                moveDir = Vector3.back;
                Debug.DrawRay(checkDir.origin, checkDir.direction, Color.red);

            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Ray checkDir = new Ray(transform.position, Vector3.left);
            if (!Physics.Raycast(checkDir, rayLengthZ))
            {
                moveDir = Vector3.left;
                Debug.DrawRay(checkDir.origin, checkDir.direction, Color.red);

            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Ray checkDir = new Ray(transform.position, Vector3.right);
            if (!Physics.Raycast(checkDir, rayLengthZ))
            {
                moveDir = Vector3.right;
                Debug.DrawRay(checkDir.origin, checkDir.direction, Color.red);

            }
        }

        //-----------------------------------

        /*
        if (!Physics.Raycast(rayForward, out hitinfo, rayLengthZ))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                moveDir = Vector3.forward;
                move = true;
            }
        }

        
        if (!Physics.Raycast(rayBackward, out hitinfo, rayLengthZ))
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                moveDir = Vector3.back;
            }
        }

        if (!Physics.Raycast(rayLeft, rayLengthX))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                moveDir = Vector3.left;

            }
        }

        if (!Physics.Raycast(rayRight, rayLengthX))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                moveDir = Vector3.right;
            }
        } */
    }
}