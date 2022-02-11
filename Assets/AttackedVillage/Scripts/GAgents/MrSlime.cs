using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrSlime : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("feedMyself", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("reachNextPoint", 1, true);
        goals.Add(s2, 3);



    }
     

}
