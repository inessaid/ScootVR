using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrafficLightWaitingArea : MonoBehaviour
{
    TrafficLightManager tlm;
    public TMP_Text stop;
    public TMP_Text go;
    public TMP_Text countdown;
    bool triggered = false;
    int count = 20;

    private void Start()
    {
        tlm = GetComponentInParent<TrafficLightManager>();
        stop.text = "";
        go.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tlm.EnteringWaitingArea();
            Debug.Log("Hit " + other.gameObject.name);
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
        yield return new WaitForSeconds(20);
        stop.text = "";
        go.text = "GO!";
        tlm.ChangeTrafficLightColor(1);
        yield return new WaitForSeconds(5);
        go.text = "";
    }
}
