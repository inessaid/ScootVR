using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour
{
    public StopSignInteraction parent;
    public bool left;

    public void LookEvent()
    {
        Debug.Log("Hit from LookRaycast!");
        if (left) parent.LookLeft();
        else parent.LookRight();
    }
}
