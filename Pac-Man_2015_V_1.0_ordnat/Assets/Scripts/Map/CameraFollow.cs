using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public float smooth;
    public float zoomAmount;
    Transform cameraPos;
    Transform centerPos;
    Movement hero;

    void Start()
    {
        cameraPos = GameObject.Find("CameraPos").transform;
        centerPos = GameObject.Find("CenterPos").transform;
        transform.position = cameraPos.transform.position;
        transform.rotation = cameraPos.rotation;
        hero = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Movement>();
    }

    void FixedUpdate()
    {
        //If moveDir from the movementscript and hero isnt moving and the player press E the camera will zoom out.
        if (hero.moveDir == Vector3.zero && Input.GetKey(KeyCode.E))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(centerPos.transform.position.x, centerPos.transform.position.y + zoomAmount, centerPos.transform.position.z - cameraPos.transform.position.y - 2), Time.deltaTime * (smooth / 5));
        }
        //Else the camera will follow hero depending on where hero is moving
        else if (hero.moveDir == Vector3.back)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(cameraPos.transform.position.x, cameraPos.transform.position.y, cameraPos.transform.position.z - 1), Time.deltaTime * smooth / 2);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, cameraPos.position, Time.deltaTime * smooth);
        }
    }
}
