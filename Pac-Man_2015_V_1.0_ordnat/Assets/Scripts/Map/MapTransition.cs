using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapTransition : MonoBehaviour
{
    //If player collides with trigger, the map is over and time is paused
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //mapEnd = true;
            GameStateManager manager = GameObject.Find("GameManager").GetComponent<GameStateManager>();
            manager.SwitchState(new StoryState(manager));
        }
    }
}
