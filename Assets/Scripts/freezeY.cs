using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeY : MonoBehaviour
{
    float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.localEulerAngles.x;
        y = transform.localEulerAngles.y;
        z = transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,y, transform.localEulerAngles.z);
    }
}
