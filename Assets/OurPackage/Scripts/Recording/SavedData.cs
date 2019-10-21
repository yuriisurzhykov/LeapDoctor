using System.Collections.Generic;
using UnityEngine;
using System;
using Leap.Unity;

[Serializable]
public class SavedData
{
    public List<Vector3> _handPosition = new List<Vector3>();
    public List<Quaternion> _handRotation = new List<Quaternion>();
}