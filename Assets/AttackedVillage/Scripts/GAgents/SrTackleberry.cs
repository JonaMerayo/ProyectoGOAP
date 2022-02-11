using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrTackleberry : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("killMonster", 1, false);
        goals.Add(s1, 2);

        SubGoal s2 = new SubGoal("rested", 1, false);
        goals.Add(s2, 5);
        Invoke("GetTired", Random.Range(5,25));

        SubGoal s3 = new SubGoal("eatDonuts", 1, false);
        goals.Add(s3, 3);
        Invoke("DonutsFever", Random.Range(18, 35));
             
    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke("Inmovilized", 10);
        Invoke("GetTired", Random.Range(30, 50));
    }
    void Inmovilized()
    {
        if (beliefs.HasState("exhausted"))
            beliefs.ModifyState("cantMoveMore", 0);
    }

    void DonutsFever()
    {
        beliefs.ModifyState("needDonuts", 0);
        Invoke("DonutsFever", Random.Range(25, 35));
    }
}
