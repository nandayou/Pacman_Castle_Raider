using UnityEngine;
using System.Collections;

public class SwingThreeTimes : MonoBehaviour {
	public int swingpower = 0;
	// Use this for initialization

//	void Start(){
//		ICanSwingThreeTimes();  //This is for testing, call ICanSwingThreeTimes when pacman gains power
//	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			StartCoroutine (StartSwing ());
		}
	}

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