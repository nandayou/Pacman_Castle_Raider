using UnityEngine;
using System.Collections;

public class Lancer : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HeroStabbingGhosts();
        }
    }

    public void HeroStabbingGhosts()
    {
        StartCoroutine(LanceStab());
    }

    IEnumerator LanceStab()
    {
        if (true)
        {
            GetComponent<Animation>().Play();
            yield return new WaitForSeconds(0f);
        }
    }
}
