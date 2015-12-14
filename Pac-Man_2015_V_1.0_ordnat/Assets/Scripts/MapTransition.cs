using UnityEngine;
using System.Collections;

public class MapTransition : MonoBehaviour {

    public Texture2D fadeColor;
    public Texture2D storyImage;
    public Texture2D border;

    public float fadeSpeed;
    bool sceneStart;

    float alpha;
    int fadeDir = -1;

    bool mapEnd;
    public bool testbool;
    public Object nextLevel;

    GUIStyle storyStyle;

    void Awake()
    {
        storyStyle.font.material.color = Color.red;

    }

    void Update()
    {
        if (mapEnd && Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(nextLevel.name);
            mapEnd = false;
            BeginFade(-1);
        }

        if (testbool)
        {
            BeginFade(1);
            mapEnd = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            BeginFade(1);
            mapEnd = true;
        }
    }

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        Rect screenRect = (new Rect(0f, 0f, Screen.width, Screen.height));

        Color color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = -1000;
       // GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), fadeColor);



        GUI.DrawTexture(screenRect, fadeColor);

        GUI.Label(new Rect(screenRect.center.x - 150, screenRect.height / 8 * 7, 300, 30), "Press Space to continue");



        //GUI.DrawTexture(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), storyImage);
        //GUI.DrawTexture(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), border);
        //GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 8 * 6, 300, 100), "Press Space to continue");


    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }
}
