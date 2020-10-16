using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drivingsimulatorrotate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftController;
    public GameObject rightController;
    public GameObject mycamera;
    Vector3 leftControllerPosition;
    Vector3 rightControllerPosition;
    Vector3 CameraPosition;
    //eulerAngle 


    Vector3 rightVector;
    Vector3 leftVector;

    Vector3 flyingDirection;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // get position of controllers
        leftControllerPosition = leftController.transform.position;
        rightControllerPosition = rightController.transform.position;

        // Get position of camera
        CameraPosition = mycamera.transform.position;

        // Get dimentions of right and left vectors
        rightVector = rightControllerPosition - CameraPosition;
        leftVector = leftControllerPosition - CameraPosition;

        // Get Vector of flying direction
        flyingDirection = rightVector + leftVector;

        // flying simulator
        transform.position += flyingDirection * speed;
        transform.Rotate(flyingDirection);


    }
}
