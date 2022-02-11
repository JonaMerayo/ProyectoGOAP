using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackMonster : GAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Monster");
        if (target == null)
            return false;
                
        return true;
    }

    public override bool Perform()
    {
        if (target != null && target.activeSelf)
        {
            Debug.DrawLine(this.transform.position, target.transform.position);
            this.gameObject.GetComponent<Animator>().Play("Combat");
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
        this.gameObject.GetComponent<Animator>().Play("Blend Tree");

        if (target == null)
        {                      

            return false;
        }            
        else
        {
            if (target == null || !target.activeSelf)

                return false;
            else
            {
                inventory.RemoveItem(target);
                Destroy(target.gameObject, 0);
                GWorld.Instance.GetWorld().ModifyState("existsMonster", -1);
                GWorld.Instance.GetWorld().ModifyState("killedMonsters", 1);
                this.gameObject.GetComponent<Animator>().Play("Blend Tree");
                

                return true;
            }
            
        }
        
    }
}