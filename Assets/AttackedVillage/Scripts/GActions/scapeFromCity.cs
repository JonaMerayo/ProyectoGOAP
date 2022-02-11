using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scapeFromCity : GAction
{
    //GameObject persecutor;
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
        //persecutor = inventory.FindItemWithTag("Monster");
        //if (persecutor != null)
        //{
            //persecutor.GetComponent<GAction>().running = false;
            //persecutor.GetComponent<GAgent>().inventory.RemoveItem(this.gameObject);
            //inventory.RemoveItem(persecutor);
        //}
        this.gameObject.SetActive(false);
        GWorld.Instance.GetWorld().ModifyState("existsCitizen", -1);
        GWorld.Instance.GetWorld().ModifyState("savedCitizens", 1);
        //Destroy(this.gameObject, 2);
        
        return true;
    }
}
