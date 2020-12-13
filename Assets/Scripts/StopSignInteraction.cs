using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopSignInteraction : MonoBehaviour
{
    TMP_Text stopText;
    TMP_Text leftText;
    TMP_Text rightText;
    TMP_Text goText;

    public GameObject car;
    public float carSpeed, carDistance;
    bool leftFirst, rightSecond, moving;
    Vector3 initCarPos;

    void Start()
    {
        stopText = transform.Find("Cues").Find("Cue Text").Find("STOP!").GetComponent<TMP_Text>();
        leftText = transform.Find("Cues").Find("Cue Text").Find("LOOK LEFT!").GetComponent<TMP_Text>();
        rightText = transform.Find("Cues").Find("Cue Text").Find("LOOK RIGHT!").GetComponent<TMP_Text>();
        goText = transform.Find("Cues").Find("Cue Text").Find("GO!").GetComponent<TMP_Text>();
        if (car != null)
        {
            initCarPos = car.transform.localPosition;
        }
        ClearText();
    }

    void Update()
    {
        if (moving && car != null)
        {
            if ((car.transform.position.x - initCarPos.x) < carDistance)
                car.transform.position += car.transform.forward * carSpeed;
            else Destroy(car);
        }
    }

    IEnumerator StartInteraction()
    {
        Debug.Log("STOP!");
        stopText.enabled = true;
        yield return new WaitForSeconds(2);
        moving = true;
        ClearText();
        Debug.Log("LOOK LEFT!");
        leftText.enabled = true;
    }

    IEnumerator EndInteraction()
    {
        ClearText();
        Debug.Log("GO!");
        goText.enabled = true;
        yield return new WaitForSeconds(2);
        goText.enabled = false;
        this.enabled = false;
    }

    void ClearText()
    {
        stopText.enabled = false;
        leftText.enabled = false;
        rightText.enabled = false;
        goText.enabled = false;
    }

    public void LookLeft()
    {
        if (!leftFirst)
        {
            leftFirst = true;
            ClearText();
            Debug.Log("LOOK RIGHT!");
            rightText.enabled = true;
        }
        else if (rightSecond) StartCoroutine(EndInteraction());
    }

    public void LookRight()
    {
        if (leftFirst)
        {
            rightSecond = true;
            ClearText();
            Debug.Log("LOOK LEFT!");
            leftText.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartInteraction());
        }
    }
}
