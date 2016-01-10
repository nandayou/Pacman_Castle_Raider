using UnityEngine;
using System.Collections;

public class PointsWinBoss : MonoBehaviour {

    public int requiredPoints;
    int currentPoints;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Point")
        {
            currentPoints++;
            if(currentPoints == requiredPoints)
            {

            }
        }
    }
}
