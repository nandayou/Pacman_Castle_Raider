using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseState : IGameManager
{
    CanvasGroup pauseMenu;

    private readonly GameStateManager manager;

    public PauseState(GameStateManager gameManager)
    {
        manager = gameManager;
        Time.timeScale = 0;
        manager.CameraPos(GameObject.Find("PauseCam"));

        pauseMenu = GameObject.Find("PauseMenu").GetComponent<CanvasGroup>();
        manager.pauseMenu.alpha = 1;

        Debug.Log("Pause State");
    }

    public void StateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            manager.SwitchState(new PlayingState(manager));
            pauseMenu.alpha = 0;
        }
    }

    public void StateOnGUI()
    {

    }
}
