using UnityEngine;
using System.Collections;

public class SpawnPoints : MonoBehaviour
{

    public GameObject pointVisual;

    void Start()
    {
        Spawn();
    }

    //Method that finds and creates an array for every gameobject with the tag navpoint in the scene, then instatiates the pointVisual game object on the same position
    void Spawn()
    {
        GameObject[] points;
        points = GameObject.FindGameObjectsWithTag("navpoint");
        int numbering = 1;

        foreach (GameObject point in points)
        {
            GameObject _point = Instantiate(pointVisual, new Vector3(point.transform.position.x, point.transform.position.y + 0.2f, point.transform.position.z), Quaternion.identity) as GameObject;
            _point.transform.parent = transform;
            _point.name = "Point" + numbering;
            numbering++;
        }
    }
}
