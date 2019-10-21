using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using System;

public class CreateCollider : MonoBehaviour
{
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
            virtualPos.AddRange(haM[i].getLocalTransforms().ToArray());
        }
        int counter = 0;
        localPos = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<RiggedHand>().JointList;
        localPos.AddRange(GameObject.FindGameObjectWithTag("RightHand").GetComponent<RiggedHand>().JointList);
        foreach(var pos in localPos)
        {
            if (counter % 26 == 0)
            {
                counter++;
                continue;
            }
            var col = pos.gameObject.AddComponent<SphereCollider>();
            col.isTrigger = true;
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
            var col = pos.gameObject.AddComponent<SphereCollider>();
            col.isTrigger = true;
            col.radius = virtualFingerRadius;
            counter++;
        }
    }
}