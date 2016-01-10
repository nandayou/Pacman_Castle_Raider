using UnityEngine;
using System.Collections;

public class ProjectileCollider : MonoBehaviour {
	public GameObject projectile;

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Wall_Turn (12)") {
			Destroy(projectile);
		}
		if (col.gameObject.name == "Alpha_Player") {
			Destroy (projectile);
		}
	}
}
