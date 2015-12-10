using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CollisionEventsWithPoints : MonoBehaviour {
    
	Vector3 startPos;
	public int scorenumber = 0;
	public int toExtraLife;
	public Text scoretext;
	public GameObject BPS;
	public int toVictory = 0;

	public int pacmanlives;
	public LifeCounter lifeDisplay;

	public GameObject[] Ghosts; 

	public StatsManager SM;
	
	// Use this for initialization
	void Start () {

		SM = GameObject.Find ("_statsManager").GetComponent<StatsManager> ();

		startPos = transform.position;
		pacmanlives = SM.playerLives;
		lifeDisplay.LifeChange(pacmanlives);
		scorenumber = SM.playerScore;
		toExtraLife = SM.toExtralife;
		scoretext.text = scorenumber.ToString();

	}

	void OnCollisionEnter(Collision other){

		if(other.gameObject.tag == "Ghost" && other.gameObject.GetComponent<GhostAI>().ghostEatable == true){

			scorenumber = scorenumber + 200;
			toExtraLife += 200;
			scoretext.text = scorenumber.ToString();

		}else if(other.gameObject.tag == "Ghost" && other.gameObject.GetComponent<GhostAI>().ghostEatable == false 
		         									&& other.gameObject.GetComponent<GhostAI>().ghostAlive == true){
			for(int i = 0; i < Ghosts.Length; i++){
				Ghosts[i].GetComponent<GhostAI>().RestartGhost();
			}
			transform.position = startPos;
			pacmanlives--;
			lifeDisplay.LifeChange(pacmanlives);
			if(pacmanlives<=0)
			{
				SM.setScore(scorenumber);
				SM.ToHighscore(scorenumber);
				Application.LoadLevel(3);
			}

			// lose a life here //
 		}
	}

	void OnTriggerEnter(Collider other){

		if (toExtraLife >= 3500) {

			Debug.Log("You gained an extra life");

			pacmanlives++;
			if(pacmanlives > 6){
				pacmanlives = 6;
			}
			toExtraLife = 0;
			lifeDisplay.LifeChange(pacmanlives);
		}


		if(other.tag == "GenericToken"){
            scorenumber = scorenumber + 10;
			toExtraLife += 10;
            Destroy(other.gameObject);
			scoretext.text = scorenumber.ToString();
			toVictory++;
        }

		else if(other.tag == "PowerUp"){
            
			for(int i = 0; i < Ghosts.Length; i++){
				Ghosts[i].GetComponent<GhostAI>().ScareGhost();
			}
            Destroy(other.gameObject);
			toVictory++;
        }
        
		else if(other.tag == "BonusPoint"){ 
			scorenumber = scorenumber + 100;
			toExtraLife += 100;
			gameObject.GetComponent<BonusPointSpawn>().offSet();
          	scoretext.text = scorenumber.ToString();
       }

		if (toVictory >= 291) {

			SM.curLvl += 1;
			SM.playerLives = pacmanlives;
			SM.setScore(scorenumber);
			SM.toExtralife = toExtraLife;
			Application.LoadLevel(4);
		}

	}
}