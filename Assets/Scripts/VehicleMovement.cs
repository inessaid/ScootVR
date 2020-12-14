using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float speed = 1f;
    public float checkDistance = 50f;
    public float cautionDistance = 30f;
    public float zOffset = -10f;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * checkDistance, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit, checkDistance))
        {
            if (hit.collider != null && (hit.collider.CompareTag("Vehicle") || hit.collider.CompareTag("Obstacle")))
            {
                //Debug.Log("About to hit something at " + hit.point + "!");
                float localDist = hit.distance;
                //Debug.Log("Distance to object: " + localDist);
                // Slow down if object is getting nearer
                if (localDist <= cautionDistance)
                {
                    Vector3 targetPos = new Vector3(hit.point.x, hit.point.y, hit.point.z + zOffset);
                    transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1f);
                }
                else
                {
                    transform.Translate(0, 0, speed);
                }
            }
        }
        else transform.Translate(0, 0, speed);
    }
}
