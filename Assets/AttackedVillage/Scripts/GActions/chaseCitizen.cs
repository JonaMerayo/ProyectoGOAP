using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseCitizen : GAction
{
    GameObject citizen;
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveCitizen();
        if (target == null)
            return false;

        citizen = target;
        if (citizen != null)
        {
            inventory.AddItem(citizen);
            //target.GetComponent<GAgent>().inventory.AddItem(this.gameObject);
        }            
        else
        {
            return false;
        }
              
        return true;
    }

    public override bool Perform()
    {
        if (target && target.activeSelf)
        {
            Debug.DrawLine(this.transform.position, citizen.transform.position);
            this.agent.destination = target.transform.position;
            return true;
        }
        else //if (!target || !target.activeSelf)
        {
            inventory.RemoveItem(citizen);
            return false;
        }

        //return false;
    }

    public override bool PostPerform()
    {
        if (target == null || !target.activeSelf)
            //    target.GetComponent<GAgent>().inventory.AddItem(resource);
            return false;
        else
        {
            return true;
        }
        
    }
}
