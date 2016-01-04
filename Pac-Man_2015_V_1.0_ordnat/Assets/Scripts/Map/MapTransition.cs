using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapTransition : MonoBehaviour
{

    Image background;
    Image storyImage;
    Text storyText;

    bool mapEnd;
    public int nextLevelIndex;

    //Starts by hiding the pressSpace text and storyimage
    void Start()
    {
        background = GameObject.Find("Background").GetComponent<Image>();
        storyImage = GameObject.Find("StoryImage").GetComponent<Image>();
        storyText = GameObject.Find("StoryText").GetComponent<Text>();

        storyText.CrossFadeAlpha(0f, 0f, true);
        storyImage.CrossFadeAlpha(0f, 0f, true);
        nextLevelIndex = Application.loadedLevel + 1;
    }

    //Checks exit is reached and waits for player to press space. When pressed, load next scene
    void Update()
    {
        if (mapEnd && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            Application.LoadLevel(nextLevelIndex);

            mapEnd = false;
        }
    }

    //If player collides with trigger, the map is over and time is paused
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            mapEnd = true;
            Time.timeScale = 0;
        }
    }

    void OnGUI()
    {

        GUI.depth = -1000;

        //Handles the fade of everything, including fade in and fade out
        if (!mapEnd)
        {
            background.CrossFadeAlpha(0f, 2f, true);
        }
        else if (mapEnd)
        {
            background.CrossFadeAlpha(2f, 2f, true);
            storyImage.CrossFadeAlpha(2f, 2f, true);
            storyText.CrossFadeAlpha(2f, 2f, true);
        }
    }
}
