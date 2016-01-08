using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryState : IGameManager
{
    Image background;
    Image storyImage;
    Text storyText;

    private readonly GameStateManager manager;

    public StoryState(GameStateManager gameManager)
    {
        manager = gameManager;
        Time.timeScale = 0;
        Debug.Log("Story state");
    }

    public void StateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
            manager.SwitchState(new PlayingState(manager));
        }
    }

    public void StateOnGUI()
    {
        manager.background.CrossFadeAlpha(1f, 2f, true);
        manager.storyImage.CrossFadeAlpha(1f, 2f, true);
        manager.storyText.CrossFadeAlpha(1f, 2f, true);
        manager.pauseMenu.alpha = 0;
    }
}
