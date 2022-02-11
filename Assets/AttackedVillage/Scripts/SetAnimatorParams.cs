using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetAnimatorParams : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Blend", agent.velocity.magnitude);

        //Debug.Log(agent.velocity.magnitude);
        //Debug.Log("Hello");
    }
}
