using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapTransition : MonoBehaviour {

    public Image fadeColor;
    public Image storyImage;
    public Text pressSpace;

    bool mapEnd;
    public Object nextLevel;

    void Start()
    {
        pressSpace.CrossFadeAlpha(0f, 0f, true);
        storyImage.CrossFadeAlpha(0f, 0f, true);
    }

    void Update()
    {
        if (mapEnd && Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(nextLevel.name);
            mapEnd = false;
            Time.timeScale = 1;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            mapEnd = true;
            Time.timeScale = 0;
        }
    }

    void OnGUI()
    {
        
        GUI.depth = -1000;

        if (!mapEnd)
        {
            fadeColor.CrossFadeAlpha(0f, 2f, true);
        }
        else if (mapEnd)
        {
            fadeColor.CrossFadeAlpha(2f, 2f, true);
            storyImage.CrossFadeAlpha(2f, 2f, true);
            pressSpace.CrossFadeAlpha(2f, 2f, true);
            

        }
    }
}
