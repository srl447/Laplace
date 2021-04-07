using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoArrow : MonoBehaviour
{
    RectTransform rT;
    // Start is called before the first frame update
    void Start()
    {
        rT = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rT.localEulerAngles += Vector3.forward;
    }
}
