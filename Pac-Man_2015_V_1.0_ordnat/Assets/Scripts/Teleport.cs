using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {


	public float rotation;
	public GameObject pacman;

	public float x;
	public float y;
	public float z;

	void Start () {

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject == pacman) {
			pacman.transform.position = new Vector3(x,y,z);
			pacman.transform.Rotate(0f, rotation, 0f);
		}
	}
}