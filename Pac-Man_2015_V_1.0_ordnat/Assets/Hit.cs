using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {


	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // GetComponent<Animator>().SetTrigger("LanceHit");
            GetComponent<Animation>().Play();
        }

    }
}
