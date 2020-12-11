using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageBox : MonoBehaviour
{
    public TMP_Text message;

    private void Start()
    {
        message.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            message.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            message.enabled = false;
    }
}
