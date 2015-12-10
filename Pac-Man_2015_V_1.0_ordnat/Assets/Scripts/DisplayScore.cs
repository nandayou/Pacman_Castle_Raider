using UnityEngine;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	// Use this for initialization
	public StatsManager SM;
	public GUIText scoreText;

	void Start () {
	
		SM = GameObject.Find ("_statsManager").GetComponent<StatsManager> ();
		scoreText.text = "Score: " + SM.playerScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
