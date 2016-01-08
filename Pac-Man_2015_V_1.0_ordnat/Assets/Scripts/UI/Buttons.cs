using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour
{
    GameStateManager manager;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameStateManager>();
    }

    public void StartGame()
    {
        manager.SwitchState(new PlayingState(manager));
    }

    public void ResumeGame()
    {
        manager.SwitchState(new PlayingState(manager));
    }

    public void RestartGame()
    {
        manager.SwitchState(new StartState(manager));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
