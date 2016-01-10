using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour {
	

	void Start () {
		StartCoroutine (StartSpike ());
	}

	IEnumerator StartSpike()
	{
		while (true) 
		{
			GetComponent<Animation>().Play ();
			yield return new WaitForSeconds(3f);
		}
	}
}
