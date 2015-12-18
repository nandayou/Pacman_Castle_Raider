using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    bool move = false;
    bool turn;
    public GameObject heroModel;

    // Floats.orward-wall detection. I found .505f to be more precise than .5f.
    float rayLengthZ = 0.6f; // This ray is for f

    float speed = 1.5f;
    float rayLengthX = 0.6f; // The ray is cast from pacmans center, with 0.5f to closest SIDE-wall, so I wen

    Vector3 moveDir;

    Ray rayForward;
    Ray rayBackward;
    Ray rayRight;
    Ray rayLeft;

    void Update()
    {
        RaycastHit hitinfo;

        rayForward = new Ray(transform.position, Vector3.forward);
        rayBackward = new Ray(transform.position, Vector3.back); 
        rayRight = new Ray(transform.position, Vector3.right);
        rayLeft = new Ray(transform.position, Vector3.left);

        transform.Translate(moveDir * Time.deltaTime * speed);

        if(moveDir != Vector3.zero)
            heroModel.transform.rotation = Quaternion.Lerp(heroModel.transform.rotation, Quaternion.LookRotation(moveDir), 0.4f);

        if (!Physics.Raycast(rayForward, out hitinfo, rayLengthZ))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                moveDir = Vector3.forward;
                move = true;
            }
        }

        
        // Pacman also needs a function to turn around. 
        if (!Physics.Raycast(rayBackward, out hitinfo, rayLengthZ))
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                moveDir = Vector3.back;
            }
        }

        // This checks for any walls to the left, which disallows a left-turn.
        if (!Physics.Raycast(rayLeft, rayLengthX))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                moveDir = Vector3.left;

            }
        }
        // This checks for any walls to the right, which disallows a right-turn.
        if (!Physics.Raycast(rayRight, rayLengthX))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                moveDir = Vector3.right;

            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "navpoint")
        {
            turn = true;
        }
        else
        {
            turn = false;
        }
    }
}
