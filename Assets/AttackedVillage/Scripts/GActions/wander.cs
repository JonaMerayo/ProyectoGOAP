using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wander : GAction
{
    public override bool PrePerform()
    {
        GameObject[] scapePoints = GameObject.FindGameObjectsWithTag("Bounds");
        target = scapePoints[Random.Range(0, scapePoints.Length)];
        if (target == null)
            return false;

        return true;
    }
    public override bool Perform()
    {
        return true;
    }

    public override bool PostPerform()
    {

        return true;
    }
}
