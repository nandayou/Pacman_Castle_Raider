using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    bool move = false;
    bool turn;
    public GameObject heroModel;

    // Floats.orward-wall detection. I found .505f to be more precise than .5f.
    float rayLengthZ = 0.35f; // This ray is for f

    public float speed = 1.5f;
    float rayLengthX = 0.6f; // The ray is cast from pacmans center, with 0.5f to closest SIDE-wall, so I wen

    [HideInInspector] public Vector3 moveDir;

    Ray rayForward;
    Ray rayBackward;
    Ray rayRight;
    Ray rayLeft;
    
    void Start()
    {
        rayLengthZ = GetComponent<Renderer>().bounds.size.x * 1.2f;
    }

    void Update()
    {
        //The movement
        GetComponent<Rigidbody>().velocity = moveDir * Time.deltaTime * speed;

        //if Hero is moving, move towards movedir
        if(moveDir != Vector3.zero)
        {
            heroModel.transform.rotation = Quaternion.Lerp(heroModel.transform.rotation, Quaternion.LookRotation(moveDir), 0.4f);
        }
        
        //If there is a wall right ahead of Hero, stop movement
        if (Physics.Raycast(transform.position, moveDir, rayLengthZ))
        {
            moveDir = Vector3.zero;
        }


        //When player uses inputs, check if there is a wall in the way and change moveDir if it isnt
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
            Ray checkDir = new Ray(transform.position, Vector3.back);
            if (!Physics.Raycast(checkDir, rayLengthZ))
            {
                moveDir = Vector3.back;
                Debug.DrawRay(checkDir.origin, checkDir.direction, Color.red);

            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Ray checkDir = new Ray(transform.position, Vector3.left);
            if (!Physics.Raycast(checkDir, rayLengthX))
            {
                moveDir = Vector3.left;
                Debug.DrawRay(checkDir.origin, checkDir.direction, Color.red);

            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Ray checkDir = new Ray(transform.position, Vector3.right);
            if (!Physics.Raycast(checkDir, rayLengthX))
            {
                moveDir = Vector3.right;
                Debug.DrawRay(checkDir.origin, checkDir.direction, Color.red);

            }
        }
    }
}