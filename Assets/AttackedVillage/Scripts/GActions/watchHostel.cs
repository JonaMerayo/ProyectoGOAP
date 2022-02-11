using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watchHostel : GAction
{
    public override bool PrePerform()
    {
        
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
