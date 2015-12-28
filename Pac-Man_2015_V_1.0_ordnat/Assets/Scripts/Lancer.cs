using UnityEngine;
using System.Collections;

public class Lancer : MonoBehaviour {


	public void HeroStabbingGhosts(){
		StartCoroutine (LanceStab());
	}
	
	IEnumerator LanceStab()
	{
		if (true) 
		{
			GetComponent<Animation>().Play ();
			yield return new WaitForSeconds(0f);
		}
	}
}
