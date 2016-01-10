using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    private IGameManager activeState;
    private static GameStateManager instanceRef;
    private Transform mainCam;

    public Image background;
    public Image storyImage;
    public Text storyText;
    public CanvasGroup pauseMenu;

    void Awake()
    {
        if (instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().cameraPos;
        FindUIComponents();

    }

    void Start()
    {
        activeState = new StartState(this);
    }

    void Update()
    {
        FindUIComponents();

        if (activeState != null)
        {
            activeState.StateUpdate();
        }
    }

    void OnGUI()
    {
        if (activeState != null)
        {
            activeState.StateOnGUI();
        }
    }

    public void SwitchState(IGameManager newState)
    {
        activeState = newState;
    }

    public void CameraPos(GameObject activeCam)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().cameraPos = activeCam.transform;
    }

    public void FindUIComponents()
    {
        if (background == null)
        {
            background = GameObject.Find("Background").GetComponent<Image>();
        }
        if (storyImage == null)
        {
            storyImage = GameObject.Find("StoryImage").GetComponent<Image>();
        }
        if (storyText == null)
        {
            storyText = GameObject.Find("StoryText").GetComponent<Text>();
        }
        if (pauseMenu == null)
        {
            pauseMenu = GameObject.Find("PauseMenu").GetComponent<CanvasGroup>();
        }
    }
}