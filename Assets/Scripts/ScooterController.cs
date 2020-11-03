using UnityEngine;

public class ScooterController : MonoBehaviour
{
    public GameObject lHand, rHand, modelPivot, directionalPivot, straightRef;
    public float initalVelocity = 0f, finalVelocity = 25f, currentVelocity = 0f, accelerationRate = 5f, decelerationRate = 10f;
    public float rotationVelocity = 1f;
    private Vector3 lPos, rPos;
    private float initYRot;

    private void Start()
    {
        modelPivot.transform.rotation = rHand.transform.rotation;
        initYRot = directionalPivot.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePivot();
        
        UpdateScooterRotation();
        UpdateScooterPosition();
    }

    void UpdatePivot()
    {
        lPos = lHand.transform.position;
        rPos = rHand.transform.position;
        modelPivot.transform.position = (lPos + rPos) / 2f;
        modelPivot.transform.rotation = rHand.transform.rotation;
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

        currentVelocity *= 0.91f; // Friction
        currentVelocity = Mathf.Clamp(currentVelocity, initalVelocity, finalVelocity);
        //transform.Translate(0, 0, currentVelocity * Time.deltaTime);
        // Direction, magnitude, rate
        transform.Translate(transform.forward * currentVelocity * Time.deltaTime);
    }

    void UpdateScooterRotation()
    {
        Vector3 straightRefDirection = straightRef.transform.forward;
        Vector3 handlebarsDirection = directionalPivot.transform.forward;
        Vector3 scooterDirection = (straightRefDirection + (handlebarsDirection * rotationVelocity * Time.deltaTime)).normalized;
        transform.rotation = Quaternion.LookRotation(new Vector3(0, scooterDirection.y, 0));
        //transform.rotation = Quaternion.LookRotation(scooterDirection);

        //Vector3.RotateTowards(transform.forward, scooterDirection, 180, 0.0f);
        //transform.rotation = Quaternion.Euler(new Vector3(0, (pivotRot.y - initYRot), 0));
        //transform.Rotate(new Vector3(0, (pivotRot.y - initYRot) * currentVelocity * Time.deltaTime, 0));

        Debug.Log("Position vector: " + transform.position + "\nRotation vector: " + transform.rotation);
        
    }
}
