using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData
{
    private string pathName;
    public LoadData(string pathName)
    {
        this.pathName = pathName;
    }

    public void Save(List<Vector3> loadedTransform, List<Quaternion> loadedRotation)
    {
        SavedData saveData = new SavedData();
        saveData._handPosition = loadedTransform;
        saveData._handRotation = loadedRotation;

        //Convert to Json
        string jsonData = JsonUtility.ToJson(saveData);
        //Save Json string
        PlayerPrefs.SetString(pathName, jsonData);
        PlayerPrefs.Save();
    }
    public SavedData Load()
    {
        //Load saved Json
        string jsonData = PlayerPrefs.GetString(pathName);
        if (jsonData == "")
            return null;
        //Convert to Class
        SavedData loadedData = JsonUtility.FromJson<SavedData>(jsonData);
        return loadedData;
    }
    public void Delete()
    {
        PlayerPrefs.DeleteKey(pathName);
    }
}
