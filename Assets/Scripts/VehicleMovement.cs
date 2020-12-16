using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float speed, checkDistance, cautionDistance;
    Vector3 velocity = Vector3.zero;
    Vector3 targetPos;
    float localDist, oldDist;
    bool closing;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * checkDistance, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit, checkDistance))
        {
            if (hit.collider != null)
            {



                if (hit.collider.CompareTag("Vehicle") || hit.collider.CompareTag("Obstacle"))
                {
                    Debug.Log("About to hit something at " + hit.point + "!");
                    localDist = hit.distance;
                    if (localDist > oldDist) closing = false;
                    oldDist = localDist;
                    Debug.Log("Distance to object: " + localDist);
                    // Slow down if object is getting nearer
                    if (localDist <= cautionDistance)
                    {
                        if (!closing)
                        {
                            targetPos = transform.position + ((hit.point - transform.position) / 2);
                            closing = true;
                            oldDist = 10000;
                        }
                        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1f);
                    }
                    else transform.Translate(0, 0, speed);
                }
                else transform.Translate(0, 0, speed);
            }
        }
        else transform.Translate(0, 0, speed);
    }
}
