using UnityEngine;
using System.Collections;

public class Lie_Script : MonoBehaviour {
	
	public int swingLiePower = 0;
	public GameObject redParticle;
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			StartCoroutine (StartSwing ());
		}
		
		if (swingLiePower == 0) {
			redParticle.GetComponent<ParticleSystem>().enableEmission = false;
		}
		
		if (swingLiePower >= 1) {
			redParticle.GetComponent<ParticleSystem>().enableEmission = true;
		}
	}
	
	//calling this funktion when pacman gains power
	public void ICanSwingOneTime(){
		swingLiePower = 1;
	}
	
	IEnumerator StartSwing()
	{
		if(swingLiePower >= 1) 
		{
			GetComponent<Animation> ().Play();
			swingLiePower -= 1;
			yield return new WaitForSeconds(2f);
		}
	}
}