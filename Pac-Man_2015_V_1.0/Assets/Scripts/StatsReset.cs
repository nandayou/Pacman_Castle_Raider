using UnityEngine;
using System.Collections;

public class StatsReset : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject.Find ("_statsManager").GetComponent<StatsManager> ().Reset ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
