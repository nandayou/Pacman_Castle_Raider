using UnityEngine;
using System.Collections;

public class SwingThreeTimes : MonoBehaviour {

	public int swingpower = 0;

	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			StartCoroutine (StartSwing ());
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
				GetComponent<Animation> ().Play ();
				swingpower -= 1;
				yield return new WaitForSeconds(2f);
		}
	}
}