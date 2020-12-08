using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public Material empty;
    public int light;
    Material[] materials;
    Material yellowLight;
    Material greenLight;
    Material redLight;

    // Start is called before the first frame update
    void Start()
    {
        materials = GetComponent<MeshRenderer>().materials;
        yellowLight = materials[0];
        greenLight = materials[1];
        redLight = materials[2];
        UpdateLights(1);
    }

    void Update()
    {
        GetComponent<MeshRenderer>().materials = materials;
    }

    public void UpdateLights(int color)
    {
        Debug.Log("Updating lights to color: " + color);
        // 0 is Yellow
        // 1 is Green
        // 2 is Red
        light = color;
        for(int i = 0; i < materials.Length; i++) materials[i] = empty;
        if (color == 0) materials[light] = yellowLight;
        else if (color == 1) materials[light] = greenLight;
        else if (color == 2) materials[light] = redLight;

    }
}
