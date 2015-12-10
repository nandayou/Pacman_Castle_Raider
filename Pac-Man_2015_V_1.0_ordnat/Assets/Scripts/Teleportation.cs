using UnityEngine;
using System.Collections.Generic;

public class Teleportation : MonoBehaviour {

	public string[] targetTags;

	public GameObject target; // Sätter denna som PacMan i Inspectorn.
	public Transform teleWall;//Sätter vilken vägg som den ska tela till detta sätter man även i inspectorn.

	//Denna kollar om det som kolliderat med objektet detta script är satt på har tagen "Player" och sedan teleporterar "Player" till det nya positionen
	//Samt att dem ser till att spelaren sen är roterad i rätt riktning, detta fixar man sedan på objectet som detta script är satt på.
	void OnTriggerEnter(Collider col){

		for(int i = 0; i < targetTags.Length; i++){

			if (col.tag == targetTags[i]){
				target = col.gameObject;
				target.transform.position = teleWall.transform.position;
				target.transform.rotation = teleWall.transform.rotation;
			}
		}

//		if (col.tag == "Player") {
//
//			player = col.gameObject;
//			player.transform.position = teleWall.transform.position;
//			player.transform.rotation = teleWall.transform.rotation;
//		}
	}	
}