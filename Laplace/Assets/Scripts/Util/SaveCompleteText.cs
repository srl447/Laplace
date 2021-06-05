using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveCompleteText : MonoBehaviour
{
    int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * .2f;
        ///GetComponent<Text>().color = new Color(1,1,1, Mathf.Lerp(GetComponent<Text>().color.a, 0, .5f));
        count++;
        if(count == 60)
        {
            Destroy(gameObject);
        }
    }
}
