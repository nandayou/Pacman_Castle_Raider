using UnityEngine;
using System.Collections;

public class DisplayHighscore : MonoBehaviour {

	// Use this for initialization
	public StatsManager SM;
	public GUIText[] highscore;
	void Start () {

		SM = GameObject.Find ("_statsManager").GetComponent<StatsManager> ();

		for (int i = 0; i < highscore.Length; i++) {

			highscore[i].text = i + ": " + SM.highscoreList[i].ToString();
		} 

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
