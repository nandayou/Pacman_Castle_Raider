using UnityEngine;
using System.Collections;

public class NewScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameStateManager manager = GameObject.Find("Game Manager").GetComponent<GameStateManager>();
        manager.SwitchState(new PlayingState(manager));
    }
}
