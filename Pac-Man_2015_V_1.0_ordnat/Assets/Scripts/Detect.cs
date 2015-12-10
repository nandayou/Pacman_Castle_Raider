using UnityEngine;
using System.Collections.Generic;

public class Detect : MonoBehaviour {

	//Detects if there's anything that matches target tags in trigger

	[Tooltip("Checks for all objects with listed tags")]
	public string[] targetTags = {"Untagged"}; //<- Add to and/or change this list in the inspector as we need

	 public bool wayClear = true;

	public bool WayClear(){
		return(wayClear);
	}

	void FixedUpdate(){

		wayClear = true;
	}

	void OnTriggerStay(Collider other){
		//Debug.Log ("Funkar");
		 
		for(int i = 0; i < targetTags.Length; i++){
			if(other.tag == targetTags[i]){
				wayClear = false;
			}
		}
	}


}
