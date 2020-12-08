using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawner : MonoBehaviour
{
    public GameObject car;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > i)
        {
            i += 5;
            Instantiate(car);
            
        }
       
    }
}
