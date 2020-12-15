using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRSceneButton : MonoBehaviour
{
    public int sceneID;
    public Color newColor;
    Color initColor;

    private void Start()
    {
        initColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Menu Selector"))
            GetComponent<SpriteRenderer>().color = newColor;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Menu Selector"))
        {
            if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0.5f)
                SceneManager.LoadScene(sceneID);

            if (Input.GetKey(KeyCode.Space)){
                SceneManager.LoadScene(sceneID);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Menu Selector"))
            GetComponent<SpriteRenderer>().color = initColor;
    }
}
