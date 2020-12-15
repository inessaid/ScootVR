using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public List<GameObject> vehicles;
    public float minTimeOffset;
    public float maxTimeOffset;
    private float currentTime;

    private void Start()
    {
        currentTime = Random.Range(minTimeOffset, maxTimeOffset);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0 && vehicles.Count > 1)
        {
            int index = Random.Range(0, vehicles.Count - 1);
            GameObject vehicle = vehicles[index];
            Instantiate(vehicle, transform.position, transform.rotation);
            currentTime = Random.Range(minTimeOffset, maxTimeOffset);
        }
    }
}
