using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatch : MonoBehaviour
{
    private CheckZone[] checkZone;
    private bool isMatchWas = false;
    private int check;
    public static int thisHandCheck;
    public bool getMatchWas
    {
        get { return isMatchWas; }
    }
    private int g;
    // Start is called before the first frame update
    void Start()
    {
        check = 0;
        checkZone = GetComponentsInChildren<CheckZone>();
        Debug.Log(checkZone.Length);
    }

    // Update is called once per frame
    void Update()
    {
        // if(checkZone.Length==2)

        for (int i = 0; i < checkZone.Length; i++)
        {
         //   Debug.log()
            if (checkZone[i].getZoneCheck)
            {
                isMatchWas =true;
                continue;
            }else
            {
                isMatchWas = false;
                break;
            }
        }
        
if (isMatchWas)
            Debug.Log("true");
    }
}