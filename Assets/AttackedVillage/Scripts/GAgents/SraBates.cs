using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SraBates : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("killMonster", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("keepHostelSafe", 1, false);
        goals.Add(s2, 5);
        Invoke("SaveHostel", Random.Range(10, 20));

    }

    void SaveHostel()
    {
        beliefs.ModifyState("worriedAboutHostel", 0);
        Invoke("SaveHostel", Random.Range(20, 30));
    }


}
