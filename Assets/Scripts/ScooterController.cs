using UnityEngine;
using TMPro;

public class ScooterController : MonoBehaviour
{
    public GameObject lHand, rHand, modelPivot, directionalPivot, straightRef;
    public float currentVelocity, initalVelocity, finalVelocity, accelerationRate, decelerationRate, frictionRate;
    public float rotationVelocity;
    public TMP_Text speedText;
    private Vector3 lPos, rPos;
    private Rigidbody rb;
   
    private void Start()
    {
        modelPivot.transform.rotation = rHand.transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePivot();
        UpdateScooterPosition();
        UpdateScooterRotation();
        UpdateSpeedometer();
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

        // Accelerate by how hard the right index trigger is pressed
        currentVelocity += accelerationRate * Time.deltaTime * rTriggerValue;
        // Decelerate by how hard the left index trigger is pressed
        currentVelocity -= decelerationRate * Time.deltaTime * lTriggerValue;
        // Adjust for friction
        currentVelocity -= currentVelocity * .09f * Time.deltaTime;
        // Set to be between min and max velocity
        currentVelocity = Mathf.Clamp(currentVelocity, initalVelocity, finalVelocity);
        Debug.Log("Velocity: " + currentVelocity);

        //rb.AddForce(Vector3.forward * currentVelocity);
        transform.Translate(Vector3.forward * currentVelocity);
    }

    void UpdateScooterRotation()
    {
        if (currentVelocity > 0.1f)
        {
            Vector2 s = new Vector2(straightRef.transform.forward.x, straightRef.transform.forward.z);
            Vector2 d = new Vector2(directionalPivot.transform.forward.x, directionalPivot.transform.forward.z);
            s.Normalize();
            d.Normalize();

            float angle = Vector2.SignedAngle(s, d);
            //rb.AddTorque(new Vector3(0, 1, 0), -angle * rotationVelocity * Time.deltaTime);
            transform.Rotate(new Vector3(0, 1, 0), -angle * rotationVelocity * Time.deltaTime);

            // 3D flying scooter (E.T. Mode)
            /*        
            Vector3 straightRefDirection = straightRef.transform.forward;
            Vector3 handlebarsDirection = directionalPivot.transform.forward;
            Vector3 scooterDirection = (straightRefDirection + (handlebarsDirection * rotationVelocity * Time.deltaTime)).normalized;
            transform.rotation = Quaternion.LookRotation(new Vector3(0, scooterDirection.y, 0));
            transform.rotation = Quaternion.LookRotation(scooterDirection);

            //Vector3.RotateTowards(transform.forward, scooterDirection, 180, 0.0f);
            //transform.rotation = Quaternion.Euler(new Vector3(0, (pivotRot.y - initYRot), 0));
            //transform.Rotate(new Vector3(0, (pivotRot.y - initYRot) * currentVelocity * Time.deltaTime, 0));
            */
        }
    }

    void UpdateSpeedometer()
    {
        speedText.text = "Current Speed:\n" + (int)(currentVelocity * 40) + " MPH";
    }
}
