using UnityEngine;
using TMPro;

public class MenuScooterController : MonoBehaviour
{
    public GameObject lHand, rHand, modelPivot, directionalPivot;
    private Vector3 lPos, rPos;

    private void Start()
    {
        modelPivot.transform.rotation = rHand.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        lPos = lHand.transform.position;
        rPos = rHand.transform.position;
        modelPivot.transform.position = (lPos + rPos) / 2f;
        modelPivot.transform.rotation = rHand.transform.rotation;
    }
}
