using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using System;

public class RecognitionManager : HandMover
{
    private SavedData savedData;

    private List<Vector3> recPositons = new List<Vector3>();
    private List<Quaternion> recRotation = new List<Quaternion>();
    private List<Transform> localTransform = new List<Transform>();
    [SerializeField] RiggedHand rigged;
    private const int midPointRound = 2;


    // Start is called before the first frame update
    private void Start()
    {
        LoadData();
        RoundTransform();
        Debug.Log(rigged.JointList.Count);
        localTransform = rigged.JointList;
    }

    // Update is called once per frame
    int counter = 0;
    private void Update()
    {
        CheckCoincidence();
        counter++;
    }

    private void LoadData()
    {
        switch (handedness)
        {
            case Chirality.Left:
                loadData = new LoadData("LeftHand");
                break;
            case Chirality.Right:
                loadData = new LoadData("RightHand");
                break;
        }
        savedData = loadData.Load();
        recPositons = savedData._handPosition;
        recRotation = savedData._handRotation;
    }
    private void RoundTransform()
    {
        for (int i = 0; i < recRotation.Count; i++)
        {
            recPositons[i] = new Vector3((float)Math.Round(recPositons[i].x, midPointRound),
                                         (float)Math.Round(recPositons[i].y, midPointRound),
                                         (float)Math.Round(recPositons[i].z, midPointRound));
        }
    }
    private void CheckCoincidence()
    {
        float roundedPalmX = (float)Math.Round(localTransform[1].position.x, midPointRound);
        if (recPositons[27].x == roundedPalmX)
            Debug.Log("Success");
    }

    public override void MoveHand()
    {
        base.MoveHand();
    }
}