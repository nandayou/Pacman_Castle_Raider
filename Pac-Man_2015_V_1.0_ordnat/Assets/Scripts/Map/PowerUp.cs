using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public SwingThreeTimes swordPowerScript;
	public Lie_Script liePowerScript;
	public Lancer lancerPowerScript;
	public GameObject thePowerUp;

	void Start () {
		swordPowerScript = GameObject.Find("mod_pacman_Hero_40x40x40_02").GetComponent<SwingThreeTimes>();
		liePowerScript = GameObject.Find("mod_pacman_Hero_40x40x40_02").GetComponent<Lie_Script>();
		lancerPowerScript = GameObject.Find("mod_pacman_Hero_40x40x40_02").GetComponent<Lancer>();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			swordPowerScript.ICanSwingThreeTimes();
			liePowerScript.ICanSwingOneTime();
			lancerPowerScript.HeroStabbingGhosts();
			Destroy(thePowerUp);
		}
	}
}
