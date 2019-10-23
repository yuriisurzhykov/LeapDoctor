using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using System;

public class CreateCollider : MonoBehaviour
{

    [SerializeField] Chirality handedness;
    [SerializeField] private float realFingerRadius;
    [SerializeField] private float virtualFingerRadius;
    [SerializeField] private float palmRaduis;

    List<Transform> localPos = new List<Transform>();
    List<Transform> virtualPos = new List<Transform>();

    
    // Start is called before the first frame update
    void Awake()
    {
        HandMover[] haM = FindObjectsOfType<HandMover>();
        for(int i = 0; i < haM.Length; i++)
        {
            if(handedness == haM[i].getChirality())
            {
                virtualPos = haM[i].getLocalTransforms();
            }
        }
        int counter = 0;
        if(handedness == Chirality.Left)
            localPos = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<RiggedHand>().JointList;
        else
            localPos = GameObject.FindGameObjectWithTag("RightHand").GetComponent<RiggedHand>().JointList;
        foreach(var pos in localPos)
        {
            if (counter % 26 == 0)
            {
                counter++;
                continue;
            }
            var col = pos.gameObject.AddComponent<SphereCollider>();
            var rig = pos.gameObject.AddComponent<Rigidbody>();
            rig.isKinematic = true;
            col.isTrigger = false;
            col.radius = realFingerRadius;
            counter++;
        }
        counter = 0;
        foreach(var pos in virtualPos)
        {
            if (counter % 26 == 0)
            {
                counter++;
                continue;
            }
            pos.gameObject.AddComponent<CheckZone>();
            var col = pos.gameObject.AddComponent<SphereCollider>();
            col.isTrigger = true;
            col.radius = virtualFingerRadius;
            counter++;
        }
    }
}