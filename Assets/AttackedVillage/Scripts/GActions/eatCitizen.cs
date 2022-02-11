using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatCitizen : GAction
{
    public GameObject ghost;
    public GameObject myClone;
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Citizen");
        if (target == null)
            return false;

        this.gameObject.GetComponent<Animator>().Play("Combat");

        return true;
    }

    public override bool Perform()
    {
        if (target && target.activeSelf)
        {
            Debug.DrawLine(this.transform.position, target.transform.position);
            this.agent.destination = target.transform.position;
            return true;
        }
        else //if (!target || !target.activeSelf)
        {
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
            inventory.RemoveItem(target);
            instantiateGhost();//The spirit of the eaten citizen
            //If too big it divides itself
            if (this.gameObject.GetComponent<Transform>().localScale.x >= 2)
            {
                multiplyMyself(2);
            }
            Destroy(target.gameObject, 0);
            GWorld.Instance.GetWorld().ModifyState("existsCitizen", -1);
            GWorld.Instance.GetWorld().ModifyState("eatenCitizens", 1);
            this.gameObject.GetComponent<Animator>().Play("Blend Tree");
            this.gameObject.GetComponent<Transform>().localScale += new Vector3(0.2f, 0.2f, 0.2f);
            //target.gameObject.GetComponent<Animator>().Play("Death");
            //if (target)
            //    target.GetComponent<GAgent>().inventory.AddItem(resource);

            return true;
        }
        
    }
    private void instantiateGhost()
    {
        GameObject newGhost = Instantiate(ghost, this.transform.position, Quaternion.identity);
        GWorld.Instance.GetWorld().ModifyState("existsMonster", 1);
        GWorld.Instance.AddMonster(newGhost);
    }

    void multiplyMyself (int copies)
    {
        myClone = this.gameObject;

        for (int i = 0; i < copies; i++)
        {
            GameObject newGhost = Instantiate(myClone, this.transform.position, Quaternion.identity);
            GWorld.Instance.GetWorld().ModifyState("existsMonster", 1);
            GWorld.Instance.AddMonster(newGhost);
        }        
    }
}