using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRaycast : MonoBehaviour
{
    public float rayDistance;
    public GameObject ballPointPrefab;
    GameObject ballPoint;
    LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        Ray ray = new Ray(transform.position, transform.forward * rayDistance);
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
        hits = Physics.RaycastAll(ray);
        if (hits.Length > 0)
        {
            RaycastHit closestPoint = new RaycastHit();
            float closestDistance = 100000;
            foreach (RaycastHit hit in hits)
            {
                float pointDist = Vector3.Distance(transform.position, hit.point);
                if (pointDist < closestDistance)
                {
                    closestDistance = pointDist;
                    closestPoint = hit;
                }
            }
            if (closestPoint.collider != null)
            {
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, closestPoint.point);
                if (closestPoint.collider.CompareTag("Menu Button") || closestPoint.collider.CompareTag("Menu"))
                {
                    Vector3 ballPos = closestPoint.point;
                    if (ballPoint == null) ballPoint = Instantiate(ballPointPrefab, ballPos, Quaternion.identity);
                    else ballPoint.transform.position = ballPos;
                }
            }
        }
    }
}
