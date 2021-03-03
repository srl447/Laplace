using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    public Image fade;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeInStart()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < 4; i++)
        {
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, Mathf.Lerp(fade.color.a, 0, .25f));
            yield return new WaitForEndOfFrame();
        }
        fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, 0);
        fade.gameObject.SetActive(false);
    }
}
