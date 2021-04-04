using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    public float speed;
    public string animType;

    float oSpeed;
    int count = 0;
    Vector3 nextPos;
    
    void Awake()
    {
        oSpeed = speed;
        if (animType == "Pulse")
        {
            speed = speed * 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //moving forward
        transform.position += Vector3.right * speed * Time.deltaTime;
        count++;

        //trying to animate it
        if (animType == "Pulse")
        {
            if (count == 0)
            {
                speed = 2 * oSpeed;
            }
            else if (count == 1)
            {
                speed = 1.5f * oSpeed;
            }
            else if (count == 2)
            {
                speed = 1.3f * oSpeed;
            }
            else if (count == 3)
            {
                speed = 1.1f * oSpeed;
            }
            else if (count == 4)
            {
                speed = oSpeed;
            }
            else if (count < 40)
            {
                speed -= speed / 20;
            }
            else if (count == 41)
            {
                speed = speed / 30;
            }
            else if (count == 60)
            {
                count = 0;
            }
        }

        if(animType == "Random Pulse")
        {
            if(Random.Range(0,100) < 1 && count < 300)
            {
                count = 0;
            }
            if (count == 0)
            {
                speed = 2 * oSpeed;
            }
            else if (count == 1)
            {
                speed = 1.5f * oSpeed;
            }
            else if (count == 2)
            {
                speed = 1.3f * oSpeed;
            }
            else if (count == 3)
            {
                speed = 1.1f * oSpeed;
            }
            else if (count == 4)
            {
                speed = oSpeed;
            }
            else if (count < 40)
            {
                speed -= speed / 20;
            }
            else if (count == 41)
            {
                speed = speed / 30;
            }
            else if (count == 42)
            {
                speed = 2 * oSpeed;
            }
            else if (count == 43)
            {
                speed = 1.5f * oSpeed;
            }
            else if (count == 44)
            {
                speed = 1.3f * oSpeed;
            }
            else if (count == 45)
            {
                speed = 1.1f * oSpeed;
            }
            else if (count == 46)
            {
                speed = oSpeed;
            }
            else if (count < 60)
            {
                speed -= speed / 20;
            }
            else if (count == 61)
            {
                speed = speed / 30;
            }
            else if (count == 62)
            {
                speed = 2 * oSpeed;
            }
            else if (count == 63)
            {
                speed = 1.5f * oSpeed;
            }
            else if (count == 64)
            {
                speed = 1.3f * oSpeed;
            }
            else if (count == 65)
            {
                speed = 1.1f * oSpeed;
            }
            else if (count == 66)
            {
                speed = oSpeed;
            }
            else if (count < 80)
            {
                speed -= speed / 20;
            }
        }

        if(transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
