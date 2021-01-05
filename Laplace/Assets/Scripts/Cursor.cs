using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); //get the x and y value
        pos = Camera.main.ScreenToWorldPoint(pos); //convert them to unity space
        pos = new Vector3(pos.x, pos.y, -9.5f); //push the cursor up infront of the camera
        transform.position = pos; //actually move the cursor

    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
    }*/
}
