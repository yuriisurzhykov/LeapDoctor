using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject panelAdmin;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    
    public void SetActivePanel()
    {
        if (panelAdmin.activeSelf)
            panelAdmin.SetActive(false);
        else
            panelAdmin.SetActive(true);
     
    }
}
