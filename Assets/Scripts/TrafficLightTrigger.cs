using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrafficLightTrigger : MonoBehaviour
{
    TrafficLightManager tlm;
    public TMP_Text slowDown;
    bool triggered = false;
    private void Start()
    {
        tlm = GetComponentInParent<TrafficLightManager>();
        slowDown.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit " + other.gameObject.name);
            if (!triggered)
            {
                StartCoroutine(SlowDownText());
            }
            triggered = true;
        }
    }

    IEnumerator SlowDownText()
    {
        slowDown.text = "SLOW DOWN!";
        tlm.ChangeTrafficLightColor(0);
        yield return new WaitForSeconds(2);
        slowDown.text = "";
    }
}
