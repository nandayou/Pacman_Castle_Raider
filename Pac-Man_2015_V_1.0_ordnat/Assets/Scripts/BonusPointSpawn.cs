using UnityEngine;
using System.Collections.Generic;

public class BonusPointSpawn : MonoBehaviour {
	
	//Här skapar man variabler som vi lägger till i inspectorn sen, dessa består av bonus poäng frukterna, BP1 = Bonus Poäng följt av numer.
	//Det finns även en variable som sätter tiden för hur lång tid det ska ta innan nästa bonusfrukt spawnar. 
	int spawnPoint;
	public float timer;
	public float stayTime;
	public bool canSpawn = true;
	public GameObject BP1;
	public GameObject BP2;
	public GameObject BP3;
	public GameObject BP4;
	public GameObject BP5;
	public StatsManager SM;
	
	
	//Vid start så stänger man av bonus frukterna, för att sedan activera dem senare.
	public void Start()
	{
		SM = GameObject.Find ("_statsManager").GetComponent<StatsManager> ();

		stayTime -= SM.curLvl * 2;
		if (stayTime < 5) {
			stayTime = 5;
		}

		BP1.SetActive(false);
		BP2.SetActive(false);
		BP3.SetActive(false);
		BP4.SetActive(false);
		BP5.SetActive(false);
		timePassed ();
	}
	
	// När en bonus frukt har spawnat så kallas denna metod efter en viss tid, det är här som man stänger av dessa bonusfrukter, sen så kallar man på timepassed så bonusarna spawnar igen.
	public void offSet()
	{
		BP1.SetActive (false);
		BP2.SetActive (false);
		BP3.SetActive (false);
		BP4.SetActive (false);
		BP5.SetActive (false);
		timePassed ();
	}
	
	// När denna metod blir kallad så kommer bonusSpawn metoden att köras efter en viss tid.
	public void timePassed ()
		
	{
		
		Invoke ("bonusSpawn", timer);
	}
	
	
	//Här så kommer bonusarna att spawna beroende på vilket nummer som random.range väljer och beroende på vilken siffra som blir så kommer bonusarna att spawna
	//Samt att metoden offSet körs efter ett antal secunder.
	public void bonusSpawn ()
		
	{
		
		spawnPoint = Random.Range (1,5);
		
		if (spawnPoint == 1)
		{
			BP1.SetActive(true);
			canSpawn=false;
			Invoke("offSet",stayTime);
			//Debug.Log("Funkar 1");
		} 
		
		//		
		else if (spawnPoint == 2)
		{
			BP2.SetActive(true);
			canSpawn=false;
			Invoke("offSet",stayTime);
			//Debug.Log("Funkar 2");
		} 
		
		else if (spawnPoint == 3)
		{
			BP3.SetActive(true);
			canSpawn=false;
			Invoke("offSet",5);
			//Debug.Log("Funkar 3");
		}
		
		else if (spawnPoint == 4)
		{
			BP4.SetActive(true);
			canSpawn=false;
			Invoke("offSet",stayTime);
			//Debug.Log("Funkar 3");
		}
		
		else if (spawnPoint == 5)
		{
			BP5.SetActive(true);
			canSpawn=false;
			Invoke("offSet",stayTime);
			//Debug.Log("Funkar 3");
		}
		
		
		
		
	}
	
}