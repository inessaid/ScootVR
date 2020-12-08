using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRaycast : MonoBehaviour
{
    public float length = 50f;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * length, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit, length))
        {
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                Cue cue = hit.collider.gameObject.GetComponent<Cue>();
                if (cue != null)
                {
                    cue.LookEvent();
                }
            }
        }
        
    }
}
