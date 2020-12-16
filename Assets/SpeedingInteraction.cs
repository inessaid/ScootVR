using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedingInteraction : MonoBehaviour
{
    public TMP_Text messageText;
    public string message;

    private void OnTriggerEnter(Collider other)
    {
        messageText.text = message;
    }

    private void OnTriggerExit(Collider other)
    {
        messageText.text = "";
    }
}
