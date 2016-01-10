using UnityEngine;
using System.Collections;

public class ProjectileShooter : MonoBehaviour {
	
	public Rigidbody projectile;
	public Transform shotPos;
	public float shotForce = 100f;
	public float moveSpeed = 10f;
	
	void Start(){
		InvokeRepeating ("ShootingProjectile", 5, 5);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
		{
			Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
			shot.AddForce(shotPos.forward * shotForce);
			
		}
	}
	void ShootingProjectile(){
		Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
		shot.AddForce(shotPos.forward * shotForce);
	}
}