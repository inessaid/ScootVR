using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGainesville : MonoBehaviour
{
    public float speed, xOffset;

    Vector3 initPos, newPos;
    bool increasing;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        newPos = new Vector3(initPos.x + xOffset, initPos.y, initPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == initPos) increasing = true;
        else if (transform.position == newPos) increasing = false;

        if (increasing) transform.Translate(Vector2.right * speed * Time.deltaTime);
        else transform.Translate(-Vector2.right * speed * Time.deltaTime);
    }
}
