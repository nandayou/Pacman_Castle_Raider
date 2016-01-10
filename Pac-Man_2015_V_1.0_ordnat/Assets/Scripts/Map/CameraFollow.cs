using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public float smooth = 5;
    public float zoomAmount = 6;

    [HideInInspector]
    public Transform cameraPos;

    private Transform centerPos;
    private Movement hero;

    void Start()
    {
        if (cameraPos == null)
        {
            cameraPos = GameObject.Find("PlayerCam").transform;
        }

        Debug.Log("Camera");
        centerPos = GameObject.Find("CenterPos").transform;
        hero = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Movement>();
    }

    void Update()
    {
        //If moveDir from the movementscript and hero isn't moving and the player press E the camera will zoom out.
        if (Input.GetKey(KeyCode.E))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(centerPos.transform.position.x, centerPos.transform.position.y + zoomAmount, centerPos.transform.position.z - cameraPos.transform.position.y - 2), Time.deltaTime * (smooth / 5));
        }
        //Else the camera will follow hero depending on where hero is moving
        /*
        else if (hero.moveDir == Vector3.back)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(cameraPos.transform.position.x, cameraPos.transform.position.y, cameraPos.transform.position.z - 1), Time.unscaledDeltaTime * smooth / 2);
        } */
        else
        {
            transform.position = Vector3.Lerp(transform.position, cameraPos.position, Time.unscaledDeltaTime * smooth);
            transform.rotation = Quaternion.Lerp(transform.rotation, cameraPos.rotation, Time.unscaledDeltaTime * smooth);
        }
    }
}
