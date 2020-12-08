using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrafficLightManager : MonoBehaviour
{
    public TrafficLight[] trafficLights;
    bool approachingLight;
    bool inWaitingArea;

    // Start is called before the first frame update
    void Start()
    {
        approachingLight = false;
        inWaitingArea = false;
    }

    public void ChangeTrafficLightColor(int color)
    {
        foreach (TrafficLight light in trafficLights)
        {
            light.UpdateLights(color);
        }
    }

    public void ApproachingLight()
    {
        approachingLight = true;
    }

    public void EnteringWaitingArea()
    {
        inWaitingArea = true;
    }

    public void LeavingWaitingArea()
    {
        inWaitingArea = false;
    }
}
