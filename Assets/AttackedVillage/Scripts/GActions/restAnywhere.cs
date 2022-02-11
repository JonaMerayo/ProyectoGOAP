using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restAnywhere : GAction
{
    public override bool PrePerform()
    {
        this.gameObject.GetComponent<Animator>().Play("Death");
        if (GWorld.Instance.GetWorld().HasState("freeRoom"))
            return false;
        target = this.gameObject;
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
        this.gameObject.GetComponent<Animator>().Play("Blend Tree");
        beliefs.RemoveState("exhausted");
        beliefs.RemoveState("cantMoveMore");
        return true;
    }
}
