using UnityEngine;

public class ScooterController : MonoBehaviour
{
    public GameObject lHand, rHand, pivot;
    public float initalVelocity = 0f, finalVelocity = 25f, currentVelocity = 0f, accelerationRate = 5f, decelerationRate = 10f;
    private Vector3 lPos, rPos;
    private float initYRot;

    private void Start()
    {
        pivot.transform.rotation = rHand.transform.rotation;
        initYRot = pivot.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePivot();
        UpdateScooterPosition();
        //UpdateScooterRotation();
    }

    void UpdatePivot()
    {
        lPos = lHand.transform.position;
        rPos = rHand.transform.position;
        pivot.transform.position = (lPos + rPos) / 2f;
        pivot.transform.rotation = rHand.transform.rotation;
    }

    void UpdateScooterPosition()
    {
        float rTriggerValue = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        float lTriggerValue = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);

        //Debug.Log("L: " + lTriggerValue + " R: " + rTriggerValue);

        // Accelerate by how hard the right index trigger is pressed
        if (rTriggerValue > 0f) currentVelocity += accelerationRate * Time.deltaTime * rTriggerValue;
        // Decelerate by how hard the left index trigger is pressed
        if (lTriggerValue > 0f) currentVelocity -= decelerationRate * Time.deltaTime * lTriggerValue;
        
        currentVelocity = Mathf.Clamp(currentVelocity, initalVelocity, finalVelocity);
        transform.Translate(0, 0, currentVelocity * Time.deltaTime);
    }

    void UpdateScooterRotation()
    {
        Vector3 pivotRot = pivot.transform.rotation.eulerAngles;
        //transform.rotation = Quaternion.Euler(new Vector3(pivotRot.x, pivotRot.y - initYRot, pivotRot.z));
        transform.Rotate(new Vector3(pivotRot.x, pivotRot.y - initYRot, pivotRot.z), Space.World);
    }
}
