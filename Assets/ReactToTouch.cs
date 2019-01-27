using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactToTouch : MonoBehaviour
{
    PlayerGameController pgc;

    void Start()
    {
        pgc = GameObject.FindObjectOfType<PlayerGameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch (tag)
        {
            case "Slap":
                pgc.HandleGesture("Slap");
                transform.parent.Translate(Vector3.forward);
                Debug.Log("Slapped!");
                break;
            case "Pet":
                pgc.HandleGesture("Pet");
                Debug.Log("Pet!");
                break;
            default:
                Debug.Log("In default, what did you do wrong!?");
                return;
        }
        Destroy(transform.parent.gameObject, 3f);
    }
}
