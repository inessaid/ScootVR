using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStopSign : MonoBehaviour
{
    public Rigidbody jeepRB;
    bool moving = false;
    private void Update()
    {
        if (moving)
        {
            jeepRB.AddForce(new Vector3(0, 0, 1));
        }    
    }

    IEnumerator MoveForward()
    {
        yield return new WaitForSeconds(1);
        moving = true;
        yield return new WaitForSeconds(2);
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
