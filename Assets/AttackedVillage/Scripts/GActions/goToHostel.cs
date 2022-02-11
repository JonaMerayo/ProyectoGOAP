using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToHostel : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveRoom();
        if (target == null)
            return false;
        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("freeRoom", -1);
        return true;
    }
    public override bool Perform()
    {
        
        return true;
    }

    public override bool PostPerform()
    {
        //this.gameObject.SetActive(false);
        return true;
    }
}
