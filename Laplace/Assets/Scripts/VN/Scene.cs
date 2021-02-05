using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    public string[] textBody;
    public Sprite background, left, right, center, mini;
    public Scene nextScene;

    public Scene(string[] textBodyI = null, Sprite backgroundI = null, Scene nextSceneI = null, Sprite leftI = null,
        Sprite rightI = null, Sprite centerI = null, Sprite miniI = null)
    {
        textBody = textBodyI;
        background = backgroundI;
        left = leftI;
        right = rightI;
        center = centerI;
        mini = miniI;
        nextScene = nextSceneI;

    }

    public void Set(string[] textBodyI = null, Sprite backgroundI = null, Scene nextSceneI = null, Sprite leftI = null,
        Sprite rightI = null, Sprite centerI = null, Sprite miniI = null)
    {
        textBody = textBodyI;
        background = backgroundI;
        left = leftI;
        right = rightI;
        center = centerI;
        mini = miniI;
        nextScene = nextSceneI;

    }

    //transfers all data besides text and the next Scene from one scene to anothers
    //useful if you want to keep the same elements bar the text and maybe one element changed after
    public void Transfer(Scene other)
    {
        background = other.background;
        left = other.left;
        right = other.right;
        center = other.center;
        mini = other.mini;
    }
}
