using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public abstract class HandRecordingManager : MonoBehaviour
{
    /*Ссылка на объект класса LoadData, в котором реализовано сохранение и выгрузка положений руки*/
    protected LoadData loadData;
    /*Ссылка на нужный объект класса RiggedHand в соответствии с хиральностью руки*/
    protected RiggedHand rigHand;
    /*Значение, которое определяет руки(правая или левая)*/
    [SerializeField] protected Chirality handedness;
}
