using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSignal : MonoBehaviour
{
    public Animator turnSignal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            turnSignal.SetBool("Turning", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            turnSignal.SetBool("Turning", false);
        }
    }
}
