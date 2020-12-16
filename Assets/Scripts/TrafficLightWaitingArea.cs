using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrafficLightWaitingArea : MonoBehaviour
{
    public TMP_Text stop;
    public TMP_Text go;
    public TMP_Text countdown;
    public GameObject verticalColliders, horizontalColliders;
    public int count = 10;

    TrafficLightManager tlm;
    BoxCollider[] stopColliders, goColliders;
    bool triggered = false;

    private void Start()
    {
        tlm = GetComponentInParent<TrafficLightManager>();
        if (verticalColliders) stopColliders = verticalColliders.GetComponentsInChildren<BoxCollider>();
        if (horizontalColliders) goColliders = horizontalColliders.GetComponentsInChildren<BoxCollider>();
        if (stopColliders != null) foreach (BoxCollider bc in stopColliders) bc.enabled = false;
        stop.text = "";
        go.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tlm.EnteringWaitingArea();
            //Debug.Log("Hit " + other.gameObject.name);
            if (!triggered)
            {
                StartCoroutine(StopAndGoText());
            }
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stop.text = "";
        tlm.LeavingWaitingArea();
    }

    IEnumerator StopAndGoText() 
    { 
        stop.text = "STOP!";
        tlm.ChangeTrafficLightColor(2);
        if (goColliders != null) foreach (BoxCollider bc in goColliders) bc.enabled = false;
        if (stopColliders != null) foreach (BoxCollider bc in stopColliders) bc.enabled = true;
        yield return new WaitForSeconds(10);

        stop.text = "";
        go.text = "GO!";
        tlm.ChangeTrafficLightColor(1);
        if (goColliders != null) foreach (BoxCollider bc in goColliders) bc.enabled = true;
        if (stopColliders != null) foreach (BoxCollider bc in stopColliders) bc.enabled = false;
        yield return new WaitForSeconds(5);
        go.text = "";
    }
}
