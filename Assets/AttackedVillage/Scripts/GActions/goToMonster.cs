using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToMonster : GAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveMonster();
        if (target == null)
            return false;
        
        resource = target;
        if (resource != null)
            inventory.AddItem(resource);
        else
        {
            //GWorld.Instance.AddMonster(target);
            //target = null;
            return false;
        }

        //GWorld.Instance.GetWorld().ModifyState("freeCubicle", -1);
        return true;
    }

    public override bool Perform()
    {
        if (target != null && target.activeSelf)
        {
            Debug.DrawLine(this.transform.position, target.transform.position);
            this.agent.destination = target.transform.position;
            return true;
        }
        else if (!target || !target.activeSelf)
        {
            return false;
        }

        return false;
    }

    public override bool PostPerform()
    {
        if (target == null || !target.activeSelf)
            return false;
        else
        {
            return true;
        }

    }
}
