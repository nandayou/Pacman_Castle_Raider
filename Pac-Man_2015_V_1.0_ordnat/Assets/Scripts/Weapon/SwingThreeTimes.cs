using UnityEngine;
using System.Collections;

public class SwingThreeTimes : MonoBehaviour {

	public int swingpower = 0;
	public GameObject redParticle;

	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			StartCoroutine (StartSwing ());
		}

		if (swingpower == 0) {
			redParticle.GetComponent<ParticleSystem>().enableEmission = false;
		}

		if (swingpower >= 1) {
			redParticle.GetComponent<ParticleSystem>().enableEmission = true;
		}
	}

	//call this funktion when pacman gains power
	public void ICanSwingThreeTimes(){
		swingpower = 3;
	}

	IEnumerator StartSwing()
	{
		if(swingpower >= 1) 
		{
				GetComponent<Animation> ().Play();
				swingpower -= 1;
				yield return new WaitForSeconds(2f);
		}
	}
}