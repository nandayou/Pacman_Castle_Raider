using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    bool move;  //Helt onödig!!

    // Floats.orward-wall detection. I found .505f to be more precise than .5f.
    float rayLengthZ = 0.505f; // This ray is for f

    float speed;
    float rayLengthX = 0.6f; // The ray is cast from pacmans center, with 0.5f to closest SIDE-wall, so I wen


    void OnEnable()
    {
        //transform.position = new Vector3(0.0f, 0.1f, -3.0f);
        move = false; // To start out without movement.
        speed = 1.5f; // Initial speed for pacman.
    }

    void Update()
    {


        //First, I initialise three Rays going forward and sideways to check wall-collisions.
        Ray rayForward = new Ray(transform.position, transform.TransformDirection(0.0f, 0.5f, 0.5f));
        Ray rayBackward = new Ray(transform.position, transform.TransformDirection(0.0f, 0.5f, -0.5f)); // Vector for direction is set manually since I want it to reach a bit behind pacmans center,
        Ray rayRight = new Ray(transform.position, transform.TransformDirection(0.6f, 0.0f, -0.1f));    // to only allow turning when he is more centered = more realistic.
        Ray rayLeft = new Ray(transform.position, transform.TransformDirection(-0.6f, 0.0f, -0.1f));
        RaycastHit hitinfo;

        // Then, I move the player forward, unless the ray detects a collision near the front of pacman, and only if 'move' is set to 'true'.
        if (!Physics.Raycast(rayForward, out hitinfo, rayLengthZ))
        {
            if (move)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                move = true;
            }
        }
        
            else if (hitinfo.collider.gameObject.tag == "navpoint")
            {
                if (move)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                }
            }
        

        // Pacman also needs a function to turn around.
        if (!Physics.Raycast(rayBackward, out hitinfo, rayLengthZ))
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                transform.Rotate(Vector3.down * 180.0f);
                transform.position = new Vector3(Mathf.Round(transform.position.x),
                                                 transform.position.y,
                                                 Mathf.Round(transform.position.z));
            }
        }

        // This checks for any walls to the left, which disallows a left-turn.
        if (!Physics.Raycast(rayLeft, rayLengthX))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                transform.Rotate(Vector3.down * 90.0f);
                transform.position = new Vector3(Mathf.Round(transform.position.x),
                                                 transform.position.y,
                                                 Mathf.Round(transform.position.z));
            }
        }
        // This checks for any walls to the right, which disallows a right-turn.
        if (!Physics.Raycast(rayRight, rayLengthX))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                transform.Rotate(Vector3.up * 90.0f);
                transform.position = new Vector3(Mathf.Round(transform.position.x),
                                                 transform.position.y,
                                                 Mathf.Round(transform.position.z));
            }
        }
    }
}
