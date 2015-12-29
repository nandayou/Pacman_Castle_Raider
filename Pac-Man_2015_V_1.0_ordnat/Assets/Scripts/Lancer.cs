using UnityEngine;
using System.Collections;

public class Lancer : MonoBehaviour {

	//Call this funktion to start stabbing ghosts with the lancer, i don't know if you can start a 
	//IEnumerator function from another script.

	//Alex, gör en variabel av lancer och skriv lancer =  GameObject.Find("Mod_Lance_lv_1-5").GetComponent<Lancer>(); 
	//i Start funktionen och starta HeroStabbingGhosts() funktionen när pacman collidar med power up.

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
