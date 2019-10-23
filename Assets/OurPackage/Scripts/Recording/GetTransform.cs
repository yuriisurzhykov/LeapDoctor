using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class GetTransform : HandRecordingManager
{
    [SerializeField] float timeRecognition = 0.1f;

    /*Transform of real hand*/
    private List<Transform> recordingHand = new List<Transform>();

    private List<Vector3> recPos = new List<Vector3>();
    private List<Quaternion> recRot = new List<Quaternion>();
    private bool wasRecording = false;
    private bool isRecording = false;

    private float tempTime = 0f;

    void Awake()
    {
        if (handedness == Chirality.Left)
        {
            loadData = new LoadData("LeftHand.json");
            rigHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<RiggedHand>();
        }
        else
        {
            loadData = new LoadData("RightHand.json");
            rigHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<RiggedHand>();
        }
        recordingHand = rigHand.JointList;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isRecording = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            isRecording = false;
            if (recordingHand.Count != 0)
                wasRecording = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (wasRecording)
            {
                loadData.Save(recPos, recRot);
                wasRecording = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            loadData.Delete();
        }

        tempTime += Time.deltaTime;
        if (isRecording)
        {
            for (int i = 0; i < recordingHand.Count; i++)
            {
                recPos.Add(recordingHand[i].position);
                recRot.Add(recordingHand[i].rotation);
            }
            timeRecognition = 0;
        }
    }

}
