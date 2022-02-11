using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goForDonuts : GAction
{
    public override bool PrePerform()
    {
        GameObject[] donutPoints = GameObject.FindGameObjectsWithTag("Donuts");
        target = donutPoints[Random.Range(0, donutPoints.Length)];
        return true;
    }
    public override bool Perform()
    {
        if (target && target.activeSelf)
        {
            Debug.DrawLine(this.transform.position, target.transform.position);
            return true;
        }
        else
        {
            return false;
        }

    }

    public override bool PostPerform()
    {        
        return true;
    }
}
