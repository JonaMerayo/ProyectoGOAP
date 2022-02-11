using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restAtHostel : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveRoom();
        if (target == null)
            return false;

        GWorld.Instance.GetWorld().ModifyState("freeRoom", -1);
        inventory.AddItem(target);
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
            inventory.RemoveItem(target);
            return false;
        }

    }

    public override bool PostPerform()
    {
        GWorld.Instance.AddRoom(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("freeRoom", 1);
        beliefs.RemoveState("exhausted");
        beliefs.RemoveState("cantMoveMore");
        return true;
    }
}
