using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CollisionEvents : MonoBehaviour {
	
	public int scorenumber = 0;
	public Text scoretext;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frameS
	void Update () {
		
		
	} 
	void OnTriggerEnter(Collider other){
		if(other.tag == "GenericToken"){
			scorenumber = scorenumber + 10;
			Destroy(other.gameObject);
			scoretext.text = scorenumber.ToString();
			//poäng prickar här
		}
		
		else if(other.gameObject.tag == "Ghost"){
			scorenumber = scorenumber + 200;
			scoretext.text = scorenumber.ToString();
			//fiender här
		}
		
		else if(other.gameObject.tag == "PowerUp"){
			
			Destroy(other.gameObject);
			//kraftpiller här
		}
		
		else if(other.gameObject.tag == "BonusPoint")
		{ scorenumber = scorenumber + 100;
			Destroy(other.gameObject);
			scoretext.text = scorenumber.ToString();
			//bonus fruker här
		}
	}
}