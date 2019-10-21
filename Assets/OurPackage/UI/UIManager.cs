using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool onTriggerStay = false;
    private bool enebleToActivate = false;
    private float curTimeToActive = 0.0f;

    [Range(0, 4)]
    [SerializeField] private float checkTime = 1f;

    protected void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Index_R":
                onTriggerStay = true;
                break;
            case "Index_L":
                onTriggerStay = true;
                break;
        }
    }

    protected void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Index_R":
                if (enebleToActivate)
                {
                    takeAction();
                }
                break;
            case "Index_L":
                if (enebleToActivate)
                {
                    takeAction();
                }
                break;
        }
    }

    private void Update()
    {
        if (onTriggerStay)
        {
            curTimeToActive += Time.deltaTime;
        }
        if (curTimeToActive >= checkTime)
        {
            enebleToActivate = true;
            curTimeToActive = 0f;
        }
    }

    public virtual void takeAction()
    {
        gameObject.transform.localScale = new Vector3(1.2f, 0.56f, 0.1f);
    }
}
