using UnityEngine;
using System.Collections;

public class SwingThreeTimes : MonoBehaviour {
	public int swingpower;
	// Use this for initialization
	void Start () {
		ICanSwingThreeTimes ();
	}

	public void ICanSwingThreeTimes(){
		swingpower = 3;
		StartCoroutine (StartSwing ());
	}

	IEnumerator StartSwing()
	{
		while (swingpower > 0) {
			if (Input.GetKeyDown (KeyCode.F)) {
				GetComponent<Animation> ().Play ();
				swingpower -= 1;
			}
		}
		yield return new WaitForSeconds(1f);
	}
}
