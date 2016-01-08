using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayingState : IGameManager
{
    private readonly GameStateManager manager;

    public PlayingState(GameStateManager gameManager)
    {
        manager = gameManager;
        manager.CameraPos(GameObject.Find("PlayerCam"));
        Time.timeScale = 1;

        HidePlayButton();

        Debug.Log("Playingstate");
    }

    //Need to optimize
    public void StateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            manager.SwitchState(new PauseState(manager));
        }
    }

    public void StateOnGUI()
    {
        manager.background.CrossFadeAlpha(0f, 2f, true);
        manager.storyImage.CrossFadeAlpha(0f, 0f, true);
        manager.storyText.CrossFadeAlpha(0f, 0f, true);
        manager.pauseMenu.alpha = 0;
    }

    void HidePlayButton()
    {
        GameObject playButton = GameObject.Find("PlayButton");

        if (playButton != null)
        {
            playButton.GetComponent<CanvasGroup>().alpha = 0;
            playButton.SetActive(false);
        }
    }
}