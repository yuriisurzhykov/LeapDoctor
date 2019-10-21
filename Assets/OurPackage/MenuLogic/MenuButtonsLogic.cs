using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsLogic : MonoBehaviour
{
    public void OnClick(int sceneIndex)
    {
        Debug.Log(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }
}
