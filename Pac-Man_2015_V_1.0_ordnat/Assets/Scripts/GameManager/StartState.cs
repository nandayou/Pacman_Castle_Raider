using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartState : IGameManager
{

    private readonly GameStateManager manager;

    Image background;
    Image storyImage;
    Text storyText;

    public StartState(GameStateManager gameManager)
    {
        manager = gameManager;

        Time.timeScale = 0;
        if (Application.loadedLevel != 0)
            Application.LoadLevel(0);


        Time.timeScale = 1;
        if (manager.pauseMenu != null)
            manager.pauseMenu.GetComponent<CanvasGroup>().alpha = 0;

        Debug.Log("Start state");
    }

    public void StateUpdate()
    {
        manager.CameraPos(GameObject.Find("PauseCam"));
    }

    public void StateOnGUI()
    {
        manager.background.CrossFadeAlpha(0f, 2f, true);
        manager.storyImage.CrossFadeAlpha(0f, 0f, true);
        manager.storyText.CrossFadeAlpha(0f, 0f, true);
    }
}
