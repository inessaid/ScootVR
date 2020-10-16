using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScooterController : MonoBehaviour
{
    public GameObject lHand, rHand, pivot;
    private Vector3 lPos, rPos;

    // Update is called once per frame
    void Update()
    {
        lPos = lHand.transform.position;
        rPos = rHand.transform.position;
        pivot.transform.position = (lPos + rPos) / 2f;
        pivot.transform.rotation = rHand.transform.rotation;
    }
}
