using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fish, badFish, bigFish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 600) < 1)
        {
            GameObject newFish = Instantiate(fish) as GameObject;
            newFish.transform.position = new Vector3(fish.transform.position.x, Random.Range(-5, 5), 0);
        }
        else if (Random.Range(0, 1800) < 1)
        {
            GameObject newFish = Instantiate(badFish) as GameObject;
            newFish.transform.position = new Vector3(fish.transform.position.x, Random.Range(-5, 5), 0);
        }
        else if (Random.Range(0, 6000) < 1)
        {
            GameObject newFish = Instantiate(bigFish) as GameObject;
            newFish.transform.position = new Vector3(fish.transform.position.x, Random.Range(-5, 5), 0);
        }
    }
}
