using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeCounter : MonoBehaviour {
   
    public Text textLives;
   

   	public void LifeChange(int lifenumber)
    { 
            textLives.text = "x " + lifenumber.ToString();
        
    }

    
}
