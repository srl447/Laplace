using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put this on your camera!
[RequireComponent(typeof(Camera))] // enforce that this script goes on an object with a camera

public class ScreenShake : MonoBehaviour
{

    //have other scripts access this and change the value to shake the screen
    public static float shakeStrength = 0f;

    Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // this actually does the shaking
        transform.position = Vector3.Lerp(
            transform.position,
            startPosition + Random.insideUnitSphere * shakeStrength,
            Time.deltaTime * 5f
        );

        shakeStrength = Mathf.Lerp(shakeStrength, 0f, Time.deltaTime * 5f); // bring it back down to 0

    }
}