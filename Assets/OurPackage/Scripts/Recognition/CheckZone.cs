using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckZone : MonoBehaviour
{
    public bool getZoneCheck { get; private set; } = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == gameObject.name) {
            //Debug.Log("true " + name + "  " + col.gameObject.name);
            getZoneCheck = true;
            //CheckMatch.
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == gameObject.name) {
            //Debug.Log("false " + name + "  " + col.gameObject.name);
            getZoneCheck = false;
        }
    }
}
