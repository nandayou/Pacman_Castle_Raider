using UnityEngine;
using System.Collections;

public class GoToScene : MonoBehaviour
{

    public int sceneIndex;

    void Start()
    {
        if (sceneIndex == 0)
        {
            sceneIndex = Application.loadedLevel + 1;
        }
    }

    public void SwitchScene()
    {
        Application.LoadLevel(sceneIndex);
    }
}
