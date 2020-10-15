using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScooterController : MonoBehaviour
{
    public GameObject rController, lController;
    private Vector3 rPos, lPos;
    // Start is called before the first frame update
    void Start()
    {
        //pivot = new GameObject("Pivot Point");
        //pivot.transform.position = (rPos + lPos) / 2f;
        //pivot.transform.SetParent(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        rPos = rController.transform.position;
        lPos = lController.transform.position;
        this.gameObject.transform.position = (rPos + lPos) / 2f;
        this.gameObject.transform.rotation = rController.transform.rotation;
    }
}
