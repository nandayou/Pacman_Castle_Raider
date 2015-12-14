using UnityEngine;
using System.Collections;

public class TimeDisplay : MonoBehaviour {

	public GUIText gameTime;

	public StatsManager SM;

	// Use this for initialization
	void Start () {

		SM = GameObject.Find ("_statsManager").GetComponent<StatsManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		gameTime.text = SM.timePlayed.ToString ("F1");
	
	}
}
